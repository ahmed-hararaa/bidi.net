using System.Net.Mime;

namespace Harara.Bidi;

/// Represents a paragraph in text.
public class Paragraph {
  /// Constructor.
  public Paragraph(List<int> text, int separator)
  {
    _separator = separator;
    N = Normalization.Decompose(text); 
    _originalText.Clear();

    if (text.Count > 0) {
      _originalText.AddRange(text);
    }

    N.Compose();

    var embeddingLevel = Bidi.CalculateEmbeddingLevel(N);
    RecalculateCharactersEmbeddingLevels(N, embeddingLevel);

    RemoveBidiMarkers();
  }

  int _separator;
  List<int> _originalText = [];
  List<int> _bidiText = [];

  /// N
  public Normalization N { get; }

  List<int> _indices = [];

  /// Original text.
  public List<int> Text => _originalText;

  /// Bidi text.
  public List<int> BidiText {
    get
    {
      var ret = _bidiText.ToList();

      if (_separator != BidiChars.NotAChar) {
        ret.Add(_separator);
      }
      return ret;
    }
  }

 

  /// Indices of the bidi text.
  public List<int> indices => _indices;

  /// The paragraph separatpr.
  public int Separator => _separator;
  
  /// Removes Bidi markers from text.
  private void RemoveBidiMarkers() {
    List<int> controlChars = [
      0x200F,
      0x202B,
      0x202E,
      0x200E,
      0x202A,
      0x202D,
      0x202C,
    ];

    var sb = _bidiText.ToList();

    int i = 0;
    while (i < sb.Count) {
      if (controlChars.Contains(sb[i])) {
        sb.RemoveAt(i);
        _indices.RemoveAt(i);
      } else {
        ++i;
      }
    }

    _bidiText.Clear();
    _bidiText.AddRange(sb);
  }

  // 3.3.2 Explicit Levels and Directions
  void RecalculateCharactersEmbeddingLevels(Normalization n, int el) {
    // This method is implemented in such a way it handles the string in logical order,
    // rather than visual order, so it is easier to handle complex layouts. That is why
    // it is placed BEFORE ReorderString rather than AFTER it, as its number suggests.
    if (n.HasPersian) {
      var shaped = n.PerformShaping();
      n.Text.Clear();
      n.Text.AddRange(shaped);
    }
    int embeddingLevel = el;
    var text = n.Text;
    var lengths = n.Lengths;

    List<CharData> textData = new List<CharData>(n.Text.Count);
    for (int i = 0; i < n.Text.Count; i++)
    {
      textData.Add(new CharData());
    }


    // X1
    var dos = DirectionOverride.Neutral;
    var dosStack = new Stack<DirectionOverride>();
    var elStack = new Stack<int>();
    int idx = 0;
    for (int i = 0; i < text.Count; ++i) {
      bool x9Char = false;
      var c = text[i];
      textData[i].Type = Bidi.GetCharacterType(c);
      textData[i].Char = c;
      textData[i].Index = idx;
      idx += lengths[i];

      // X2. With each RLE, compute the least greater odd embedding level.
      // X4. With each RLO, compute the least greater odd embedding level.
      if (c == BidiChars.Rle || c == BidiChars.Rlo) {
        x9Char = true;
        if (embeddingLevel < 60) {
          elStack.Push(embeddingLevel);
          dosStack.Push(dos);

          ++embeddingLevel;
          embeddingLevel |= 1;

          if (c == BidiChars.Rle) {
            dos = DirectionOverride.Neutral;
          } else {
            dos = DirectionOverride.Rtl;
          }
        }
      }
      // X3. With each LRE, compute the least greater even embedding level.
      // X5. With each LRO, compute the least greater even embedding level.
      else if (c == BidiChars.Lre || c == BidiChars.Lro) {
        x9Char = true;
        if (embeddingLevel < 59) {
          elStack.Push(embeddingLevel);
          dosStack.Push(dos);

          embeddingLevel |= 1;
          ++embeddingLevel;

          if (c == BidiChars.Lre) {
            dos = DirectionOverride.Neutral;
          } else {
            dos = DirectionOverride.Ltr;
          }
        }
      }

      // X6. For all types besides RLE, LRE, RLO, LRO, and PDF: (...)
      else if (c != BidiChars.Pdf) {
        // a. Set the level of the current character to the current embedding level.
        textData[i].EmbeddingLevel = embeddingLevel;

        //b. Whenever the directional override status is not neutral,
        //reset the current character type to the directional override status.
        if (dos == DirectionOverride.Ltr) {
          textData[i].Type = CharacterType.Ltr;
        } else if (dos == DirectionOverride.Rtl) {
          textData[i].Type = CharacterType.Rtl;
        }
      }

      //Terminating Embeddings and Overrides
      // X7. With each PDF, determine the matching embedding or override code.
      // If there was a valid matching code, restore (pop) the last remembered (pushed)
      // embedding level and directional override.
      else if (c == BidiChars.Pdf) {
        x9Char = true;
        if (elStack.Count > 0) {
          embeddingLevel = elStack.Pop();
          dos = dosStack.Pop();
        }
      }

      // X8. All explicit directional embeddings and overrides are completely
      // terminated at the end of each paragraph. Paragraph separators are not
      // included in the embedding.

      if (x9Char || textData[i].Type == CharacterType.Bn) {
        textData[i].EmbeddingLevel = embeddingLevel;
      }
    }

    // X10. The remaining rules are applied to each run of characters at the same level.
    int prevLevel = embeddingLevel;
    int start = 0;
    while (start < text.Count) {
      var level = textData[start].EmbeddingLevel;
      var sor = Bidi.TypeForLevel(Math.Max(prevLevel, level));

      int limit = start + 1;
      while (limit < text.Count && textData[limit].EmbeddingLevel == level) {
        ++limit;
      }

      var nextLevel =
          limit < text.Count ? textData[limit].EmbeddingLevel : embeddingLevel;
      var eor = Bidi.TypeForLevel(Math.Max(nextLevel, level));

      Bidi.ResolveWeakTypes(
          textData, start, limit, sor, eor, n.HasPersian, n.HasNonspacingMark);
      Bidi.ResolveNeutralTypes(textData, start, limit, sor, eor, level);
      Bidi.ResolveImplicitTypes(textData, start, limit, level);

      prevLevel = level;
      start = limit;
    }

    Bidi.ReorderString(textData, el);
    Bidi.FixMirroredCharacters(textData);

    List<int> indexes = [];

    List<int> sb = [];
    foreach (var cd in textData) {
      sb.Add(cd.Char);
      indexes.Add(cd.Index);
    }

    _bidiText.Clear();
    _bidiText.AddRange(sb);

    _indices.Clear();
    _indices.AddRange(indexes);
  }
}

class CharData {
  public int Char { get; set; }
  public int Index { get; set; }
  public CharacterType Type { get; set; }
  public int EmbeddingLevel { get; set; }
}

/// Return the strong type (L or R) corresponding to the embedding level.
///
/// [level] The embedding level to check.


/// Contains a set of functions for bidi text
/// normalization (decomposition and composition).
public class Normalization {
  public Normalization(List<int> text,
    List<int> lengths,
    bool hasPersian,
    bool hasNonspacingMark)
  {
    Text = text;
    Lengths = lengths;
    HasPersian = hasPersian;
    HasNonspacingMark = hasNonspacingMark;
  }
  
  /// Calculates the internal decomposition of the input text.
  public static Normalization Decompose(List<int> characters) {
    List<int> text = [];
    List<int> lengths = [];

    var hasPersian = false;
    var hasNSMs = false;

    for (int i = 0; i < characters.Count; ++i) {
      var ct =Bidi.GetCharacterType(characters[i]);
      hasPersian |= ((ct == CharacterType.Al) || (ct == CharacterType.An));
      hasNSMs |= (ct == CharacterType.NonspacingMark);

      List<int> buffer = [];
      Bidi.GetRecursiveDecomposition(false, characters[i], buffer);
      lengths.Add(1 - buffer.Count);
      // add all of the characters in the decomposition.
      // (may be just the original character, if there was
      // no decomposition mapping)

      for (int j = 0; j < buffer.Count; ++j) {
        var character = buffer[j];
        var chClass = CanonicalClass.GetCanonicalClass(character);
        int k = text.Count; // insertion point
        if (chClass != CanonicalClass.NotReordered) {
          // bubble-sort combining marks as necessary
          int ch2;
          for (; k > 0; --k) {
            ch2 = text[k - 1];
            if (CanonicalClass.GetCanonicalClass(ch2).Value <= chClass.Value) break;
          }
        }

        text.Insert(k, character);
      }
    }

    return new Normalization(text, lengths, hasPersian, hasNSMs);
  }

  /// Compose.
  internal void Compose() {
    if (Text.Count == 0) {
      return;
    }

    int starterPos = 0;
    int compPos = 1;
    var starterCh = Text[0];

    Lengths[starterPos] = Lengths[starterPos] + 1;

    var lastClass = CanonicalClass.GetCanonicalClass(starterCh);

    if (lastClass != CanonicalClass.NotReordered) {
      lastClass = CanonicalClass.FromValue(
        256
      ); // fix for strings staring with a combining mark
    }

    int oldLen = Text.Count;

    // Loop on the decomposed characters, combining where possible
    int ch;
    for (int decompPos = compPos; decompPos < Text.Count; ++decompPos) {
      ch = Text[decompPos];
      var chClass = CanonicalClass.GetCanonicalClass(ch);
      var isShaddaPair = chClass.IsShaddaPair;
      var composite = Bidi.GetPairwiseComposition(starterCh, ch);
      var composeType = Bidi.GetDecompositionType(composite);

      if ((composeType == null || (isShaddaPair)) &&
          composite != BidiChars.NotAChar &&
          (lastClass.Value < chClass.Value ||
              lastClass == CanonicalClass.NotReordered)) {
        Text[starterPos] = composite;
        Lengths[starterPos] = Lengths[starterPos] + 1;
        // we know that we will only be replacing non-supplementaries by non-supplementaries
        // so we don't have to adjust the decompPos
        starterCh = composite;
      } else {
        if (chClass == CanonicalClass.NotReordered || (isShaddaPair)) {
          starterPos = compPos;
          starterCh = ch;
        }
        lastClass = chClass;
        Text[compPos] = ch;
        //char_lengths[compPos] = char_lengths[compPos] + 1;
        int chkPos = compPos;
        if (Lengths[chkPos] < 0) {
          while (Lengths[chkPos] < 0) {
            Lengths[chkPos] = Lengths[chkPos] + 1;
            Lengths.Insert(compPos, 0);
            chkPos++;
          }
        } else {
          Lengths[chkPos] = Lengths[chkPos] + 1;
        }

        if (Text.Count != oldLen) // MAY HAVE TO ADJUST!
        {
          decompPos += Text.Count - oldLen;
          oldLen = Text.Count;
        }
        ++compPos;
      }
    }

    void SetTextLength()
    {
      var diff = 0;
      if (Text.Count > compPos)
      {
        diff = Text.Count - compPos;
        Text.RemoveRange(Text.Count - diff, diff);
        return;
      }
      diff = compPos - Text.Count;
      for (var i = 0; i < diff; i++)
      {
        Text.Add(0);
      }
    }

    SetTextLength();
    //Text.Length = compPos;

    var taken = Lengths.Take(compPos).ToList();

    Lengths.Clear();
    Lengths.AddRange(taken);
  }

  /// 3.5 Shaping
  /// Implements rules R1-R7 and rules L1-L3 of section 8.2 (Persian) of the Unicode standard.
  // TODO - this code is very special-cased.
  internal List<int> PerformShaping() {
    var lastJt = ShapeJoiningType.NonJoining;
    var lastForm = LetterForm.Isolated;
    int lastPos = 0;
    var lastChar = BidiChars.NotAChar;
    var letterForms = Enumerable.Repeat(LetterForm.Initial, Text.Count).ToList();
       

    for (int i = 0; i < Text.Count; ++i) {
      var ch = Text[i];
      //string chStr = (ch).ToString("X4");

      var jt = Bidi.GetShapeJoiningType(ch);

      if ((jt == ShapeJoiningType.Right ||
              jt == ShapeJoiningType.Dual ||
              jt == ShapeJoiningType.Causing) &&
          (lastJt == ShapeJoiningType.Left ||
              lastJt == ShapeJoiningType.Dual ||
              lastJt == ShapeJoiningType.Causing)) {
        if (lastForm == LetterForm.Isolated &&
            (lastJt == ShapeJoiningType.Dual ||
                lastJt == ShapeJoiningType.Left)) {
          letterForms[lastPos] = LetterForm.Initial;
        } else if (lastForm == LetterForm.FinalForm &&
            lastJt == ShapeJoiningType.Dual) {
          letterForms[lastPos] = LetterForm.Medial;
        }
        letterForms[i] = LetterForm.FinalForm;
        lastForm = LetterForm.FinalForm;
        lastJt = jt;
        lastPos = i;
        lastChar = ch;
      } else if (jt != ShapeJoiningType.Transparent) {
        letterForms[i] = LetterForm.Isolated;
        lastForm = LetterForm.Isolated;
        lastJt = jt;
        lastPos = i;
        lastChar = ch;
      } else {
        letterForms[i] = LetterForm.Isolated;
      }
    }

    lastChar = BidiChars.NotAChar;
    lastPos = 0;
    int insertPos = 0;

    List<int> sb = [];

    for (int i = 0; i < Text.Count; ++i) {
      var ch = Text[i];
      //string chStr = (ch).ToString("X4");
      var jt = Bidi.GetShapeJoiningType(ch);

      if (lastChar == BidiChars.ArabicLam &&
          ch != BidiChars.ArabicAlef &&
          ch != BidiChars.ArabicAlefMaddaAbove &&
          ch != BidiChars.ArabicAlefHamzaAbove &&
          ch != BidiChars.ArabicAlefHamzaBelow &&
          jt != ShapeJoiningType.Transparent) {
        lastChar = BidiChars.NotAChar;
      } else if (ch == BidiChars.ArabicLam) {
        lastChar = ch;
        lastPos = i;
        insertPos = sb.Count;
      }

      if (lastChar == BidiChars.ArabicLam) {
        if (letterForms[lastPos] == LetterForm.Medial) {
          switch (ch) {
            case BidiChars.ArabicAlef:
              sb[insertPos] = BidiChars.ArabicLamAlefFinal;
              Lengths.RemoveAt(insertPos);
              continue;

            case BidiChars.ArabicAlefMaddaAbove:
              sb[insertPos] = BidiChars.ArabicLamAlefMaddaAboveFinal;
              Lengths.RemoveAt(insertPos);
              Lengths[insertPos] = Lengths[insertPos] + 1;
              continue;

            case BidiChars.ArabicAlefHamzaAbove:
              sb[insertPos] = BidiChars.ArabicLamAlefHamzaAboveFinal;
              Lengths.RemoveAt(insertPos);
              continue;

            
            case BidiChars.ArabicAlefHamzaBelow:
              sb[insertPos] = BidiChars.ArabicLamAlefHamzaBelowFinal;
              Lengths.RemoveAt(insertPos);
              continue;
          }
        } else if (letterForms[lastPos] == LetterForm.Initial) {
          switch (ch) {
            case BidiChars.ArabicAlef:
              sb[insertPos] = BidiChars.ArabicLamAlefIsolated;
              Lengths.RemoveAt(insertPos);
              continue;
            
            case BidiChars.ArabicAlefMaddaAbove:
              sb[insertPos] = BidiChars.ArabicLamAlefMaddaAboveIsolated;
              Lengths.RemoveAt(insertPos);
              Lengths[insertPos] = Lengths[insertPos] + 1;
              continue;
            
            case BidiChars.ArabicAlefHamzaAbove:
             
              sb[insertPos] = BidiChars.ArabicLamAlefHamzaAboveIsolated;
              Lengths.RemoveAt(insertPos);
              continue;
            
            case BidiChars.ArabicAlefHamzaBelow:
             
              sb[insertPos] = BidiChars.ArabicLamAlefHamzaBelowIsolated;
              Lengths.RemoveAt(insertPos);
              continue;
          }
        }
      }

      sb.Add(Bidi.GetCharacterByLetterForm(ch, letterForms[i]));
    }

    return sb;
  }

  /// Target.
 public List<int> Text { get; }

  /// Lengths.
  public List<int> Lengths { get; }

  /// Has Persian Characters.
  public bool HasPersian { get; set; }

  /// Has Nonspacing Mark.
  public bool HasNonspacingMark { get; set; }
}





public partial class Bidi
{
  // 3.3.1 The Paragraph Level
// P2 - In each paragraph, find the first character of type L, AL, or R.
// P3 - If a character is found in P2 and it is of type AL or R, then
// set the paragraph embedding level to one; otherwise, set it to zero.
  internal static int CalculateEmbeddingLevel(Normalization n) {
    int embeddingLevel = 0;
    foreach (var c in n.Text) {
      var cType = GetCharacterType(c);
      if (cType == CharacterType.Rtl || cType == CharacterType.Al) {
        embeddingLevel = 1;
        break;
      } else if (cType == CharacterType.Ltr) {
        break;
      }
    }

    return embeddingLevel;
  }
  
  internal static int GetPairwiseComposition(int first, int second) {
    if (first < 0 || first > 0xFFFF || second < 0 || second > 0xFFFF) {
      return BidiChars.NotAChar;
    }

    return Compose(new string(new char[] { (char)first, (char)second }));
  }
  /// 3.3.3 Resolving Weak Types
  internal static void ResolveWeakTypes(
    List<CharData> textData,
    int start,
    int limit,
    CharacterType sor,
    CharacterType eor,
    bool hasPersian,
    bool hasNSMs
  )
  {
    // TODO - all these repeating runs seems somewhat unefficient...
    // TODO - rules 2 and 7 are the same, except for minor parameter changes...

    // W1. Examine each nonspacing mark (NSM) in the level run, and change the type of the NSM to the type of the previous character. If the NSM is at the start of the level run, it will get the type of sor.
    if (hasNSMs)
    {
      CharacterType preceedingCharacterType = sor;
      for (int i = start; i < limit; ++i)
      {
        CharacterType t = textData[i].Type;
        if (t == CharacterType.NonspacingMark)
        {
          textData[i].Type = preceedingCharacterType;
        }
        else
        {
          preceedingCharacterType = t;
        }
      }
    }

    // W2. Search backward from each instance of a European number until the first strong type (R, L, AL, or sor) is found. If an AL is found, change the type of the European number to Persian number.

    var tW2 = CharacterType.En;
    for (int i = start; i < limit; ++i)
    {
      if (textData[i].Type == CharacterType.Ltr ||
          textData[i].Type == CharacterType.Rtl)
      {
        tW2 = CharacterType.En;
      }
      else if (textData[i].Type == CharacterType.Al)
      {
        tW2 = CharacterType.An;
      }
      else if (textData[i].Type == CharacterType.En)
      {
        textData[i].Type = tW2;
      }
    }

    // W3. Change all ALs to R.
    if (hasPersian)
    {
      for (int i = start; i < limit; ++i)
      {
        if (textData[i].Type == CharacterType.Al)
        {
          textData[i].Type = CharacterType.Rtl;
        }
      }
    }

    // W4. A single European separator between two European numbers changes to a European number. A single common separator between two numbers of the same type changes to that type.

    // Since there must be values on both sides for this rule to have an
    // effect, the scan skips the first and last value.
    //
    // Although the scan proceeds left to right, and changes the type values
    // in a way that would appear to affect the computations later in the scan,
    // there is actually no problem.  A change in the current value can only
    // affect the value to its immediate right, and only affect it if it is
    // ES or CS.  But the current value can only change if the value to its
    // right is not ES or CS.  Thus either the current value will not change,
    // or its change will have no effect on the remainder of the analysis.

    for (int i = start + 1; i < limit - 1; ++i)
    {
      if (textData[i].Type == CharacterType.Es ||
          textData[i].Type == CharacterType.CommonNumberSeparator)
      {
        CharacterType prevSepType = textData[i - 1].Type;
        CharacterType succSepType = textData[i + 1].Type;
        if (prevSepType == CharacterType.En && succSepType == CharacterType.En)
        {
          textData[i].Type = CharacterType.En;
        }
        else if (textData[i].Type == CharacterType.CommonNumberSeparator &&
                 prevSepType == CharacterType.An &&
                 succSepType == CharacterType.An)
        {
          textData[i].Type = CharacterType.An;
        }
      }
    }

    // W5. A sequence of European terminators adjacent to European numbers changes to all European numbers.
    for (int i = start; i < limit; ++i)
    {
      if (textData[i].Type == CharacterType.Et)
      {
        // locate end of sequence
        int runstart = i;
        int runlimit =
          FindRunLimit(textData, runstart, limit, [CharacterType.Et]);

        // check values at ends of sequence
        CharacterType t = runstart == start ? sor : textData[runstart - 1].Type;

        if (t != CharacterType.En)
        {
          t = runlimit == limit ? eor : textData[runlimit].Type;
        }

        if (t == CharacterType.En)
        {
          SetTypes(textData, runstart, runlimit, CharacterType.En);
        }

        // continue at end of sequence
        i = runlimit;
      }
    }

    // W6. Otherwise, separators and terminators change to Other Neutral.
    for (int i = start; i < limit; ++i)
    {
      CharacterType t = textData[i].Type;
      if (t == CharacterType.Es ||
          t == CharacterType.Et ||
          t == CharacterType.CommonNumberSeparator)
      {
        textData[i].Type = CharacterType.OtherNeutrals;
      }
    }

    // W7. Search backward from each instance of a European number until the first strong type (R, L, or sor) is found.
    //     If an L is found, then change the type of the European number to L.

    CharacterType tW7 =
      sor == CharacterType.Ltr ? CharacterType.Ltr : CharacterType.En;
    for (int i = start; i < limit; ++i)
    {
      if (textData[i].Type == CharacterType.Rtl)
      {
        tW7 = CharacterType.En;
      }
      else if (textData[i].Type == CharacterType.Ltr)
      {
        tW7 = CharacterType.Ltr;
      }
      else if (textData[i].Type == CharacterType.En)
      {
        textData[i].Type = tW7;
      }
    }
  }

  /// 3.3.4 Resolving Neutral Types
  internal static void ResolveNeutralTypes(
    List<CharData> textData,
    int start,
    int limit,
    CharacterType sor,
    CharacterType eor,
    int level 
  )
  {
    // N1. A sequence of neutrals takes the direction of the surrounding strong text if the text on both sides has the same direction.
    //     European and Persian numbers act as if they were R in terms of their influence on neutrals.
    //     Start-of-level-run (sor) and end-of-level-run (eor) are used at level run boundaries.
    // N2. Any remaining neutrals take the embedding direction.

    for (int i = start; i < limit; ++i)
    {
      CharacterType t = textData[i].Type;
      if (t == CharacterType.Whitespace ||
          t == CharacterType.OtherNeutrals ||
          t == CharacterType.Separator ||
          t == CharacterType.SegmentSeparator)
      {
        // find bounds of run of neutrals
        int runstart = i;
        int runlimit = FindRunLimit(
          textData,
          runstart,
          limit,
          [
            CharacterType.Separator,
            CharacterType.SegmentSeparator,
            CharacterType.Whitespace,
            CharacterType.OtherNeutrals
          ]
        );

        // determine effective types at ends of run
        CharacterType leadingType;
        CharacterType trailingType;

        if (runstart == start)
        {
          leadingType = sor;
        }
        else
        {
          leadingType = textData[runstart - 1].Type;
          if (leadingType == CharacterType.An ||
              leadingType == CharacterType.En)
          {
            leadingType = CharacterType.Rtl;
          }
        }

        if (runlimit == limit)
        {
          trailingType = eor;
        }
        else
        {
          trailingType = textData[runlimit].Type;
          if (trailingType == CharacterType.An ||
              trailingType == CharacterType.En)
          {
            trailingType = CharacterType.Rtl;
          }
        }

        CharacterType resolvedType;
        if (leadingType == trailingType)
        {
          // Rule N1.
          resolvedType = leadingType;
        }
        else
        {
          // Rule N2.
          // Notice the embedding level of the run is used, not
          // the paragraph embedding level.
          resolvedType = Bidi.TypeForLevel(level);
        }

        SetTypes(textData, runstart, runlimit, resolvedType);

        // skip over run of (former) neutrals
        i = runlimit;
      }
    }
  }

  /// 3.3.5 Resolving Implicit Levels
  internal static void ResolveImplicitTypes(
    List<CharData> textData,
    int start,
    int limit,
    int level 
  )
  {
    // I1. For all characters with an even (left-to-right) embedding direction, those of type R go up one level and those of type AN or EN go up two levels.
    // I2. For all characters with an odd (right-to-left) embedding direction, those of type L, EN or AN go up one level.

    if ((level & 1) == 0) // even level
    {
      for (int i = start; i < limit; ++i)
      {
        CharacterType t = textData[i].Type;
        // Rule I1.
        if (t == CharacterType.Rtl)
        {
          textData[i].EmbeddingLevel += 1;
        }
        else if (t == CharacterType.An || t == CharacterType.En)
        {
          textData[i].EmbeddingLevel += 2;
        }
      }
    }
    else // odd level
    {
      for (int i = start; i < limit; ++i)
      {
        CharacterType t = textData[i].Type;
        // Rule I2.
        if (t == CharacterType.Ltr ||
            t == CharacterType.An ||
            t == CharacterType.En)
        {
          textData[i].EmbeddingLevel += 1;
        }
      }
    }
  }

  /// 3.4 Reordering Resolved Levels
  internal static void ReorderString(List<CharData> textData, int embeddingLevel)
  {
    //L1. On each line, reset the embedding level of the following characters to the paragraph embedding level:
    //    1. Segment separators,
    //    2. Paragraph separators,
    //    3. Any sequence of whitespace characters preceding a segment separator or paragraph separator, and
    //    4. Any sequence of white space characters at the end of the line.

    int l1Start = 0;
    for (int i = 0; i < textData.Count; ++i)
    {
      if (textData[i].Type == CharacterType.SegmentSeparator ||
          textData[i].Type == CharacterType.Separator)
      {
        for (int j = l1Start; j <= i; ++j)
        {
          textData[j].EmbeddingLevel = embeddingLevel;
        }
      }

      if (textData[i].Type != CharacterType.Whitespace)
      {
        l1Start = i + 1;
      }
    }

    for (int j = l1Start; j < textData.Count; ++j)
    {
      textData[j].EmbeddingLevel = embeddingLevel;
    }

    // L2. From the highest level found in the text to the lowest odd level on each
    //     line, including intermediate levels not actually present in the text,
    //     reverse any contiguous sequence of characters that are at that level or
    //     higher.
    int highest = 0;
    int lowestOdd = 63;
    foreach (CharData cd in textData)
    {
      if (cd.EmbeddingLevel > highest) highest = cd.EmbeddingLevel;
      if ((cd.EmbeddingLevel & 1) == 1 && cd.EmbeddingLevel < lowestOdd)
      {
        lowestOdd = cd.EmbeddingLevel;
      }
    }

    for (var el = highest; el >= lowestOdd; --el)
    {
      for (int i = 0; i < textData.Count; ++i)
      {
        if (textData[i].EmbeddingLevel >= el)
        {
          // find range of text at or above this level
          int l2Start = i;
          int limit = i + 1;
          while (
            limit < textData.Count && textData[limit].EmbeddingLevel >= el)
          {
            ++limit;
          }

          // reverse run
          for (int j = l2Start, k = limit - 1; j < k; ++j, --k)
          {
            CharData tempCd = textData[j];
            textData[j] = textData[k];
            textData[k] = tempCd;
          }

          // skip to end of level run
          i = limit;
        }
      }
    }

    // TODO - L3. Combining marks applied to a right-to-left base character will at this point precede their base
    // character. If the rendering engine expects them to follow the base characters in the var display process,
    // then the ordering of the marks and the base character must be reversed.
  }

  /// L4. A character is depicted by a mirrored glyph if and only if (a) the resolved directionality of that character is R, and (b) the Bidi_Mirrored property value of that character is true.
  internal static void FixMirroredCharacters(List<CharData> textData)
  {
    for (int i = 0; i < textData.Count; ++i)
    {
      if ((textData[i].EmbeddingLevel & 1) == 1)
      {
        textData[i].Char = Bidi.GetCharacterMirror(textData[i].Char);
      }
    }
  }

  /// Return the limit of the run, starting at index, that includes only resultTypes in [validSet].
  /// This checks the value at index, and will return index if that value is not in [validSet].
  private static int FindRunLimit(
    List<CharData> textData,
    int index,
    int limit,
    List<CharacterType> validSet
  )
  {
    --index;
    bool found = false;
    while (++index < limit)
    {
      var t = textData[index].Type;
      found = false;
      for (int i = 0; i < validSet.Count && !found; ++i)
      {
        if (t == validSet[i]) found = true;
      }

      if (!found) return index; // didn't find a match in validSet
    }

    return limit;
  }

  /// Set resultTypes from start up to (but not including) limit to newType.
  private static void SetTypes(
    List<CharData> textData,
    int start,
    int limit,
    CharacterType newType
  )
  {
    for (int i = start; i < limit; ++i)
    {
      textData[i].Type = newType;
    }
  }

  internal static CharacterType TypeForLevel(int level)
  {
    return ((level & 1) == 0) ? CharacterType.Ltr : CharacterType.Rtl;
  }
}
