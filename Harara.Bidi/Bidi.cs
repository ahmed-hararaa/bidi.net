namespace Harara.Bidi;

class BidiString {
    private BidiString(List<Paragraph> paragraphs)
    {
        Paragraphs = paragraphs;
    }

    /// Implementation of the BIDI algorithm, as described in http://www.unicode.org/reports/tr9/tr9-17.html
    /// [text] is the original logical-ordered string. Returns the visual representation of the string.
    public static BidiString FromLogical(string text)
    {
        var paragraphs = new List<Paragraph>();
        var codeUnits = text.ToArray();

        var next = new List<int>();
        for (var i = 0; i < codeUnits.Length; ++i) {
            var c = codeUnits[i];
            var type = Bidi.GetCharacterType(c);
            if (type == CharacterType.Separator) {
                var paragraph = new Paragraph(next, c);
                paragraphs.Add(paragraph);
                next = [];
            } else {
                next.Add(c);
            }
        }

        if (next.Count > 0) // string ended without a paragraph separator
        {
            paragraphs.Add(new Paragraph(next, BidiChars.NotAChar));
        }

        return new BidiString(paragraphs);
    }

    /// Paragraphs.
    public List<Paragraph> Paragraphs { get; }
}

public partial class Bidi
{
    /// <summary>
    /// Implementation of the BIDI algorithm, as described in http://www.unicode.org/reports/tr9/tr9-17.html
    /// </summary>
    /// <param name="logicalString">is the original logical-ordered string. Returns the visual representation of the string.</param>
    /// <returns></returns>
    public static List<int> LogicalToVisual(string logicalString) {
        var paragraphs = BidiString.FromLogical(logicalString).Paragraphs;
        var sb = new List<int>();
        foreach (var p in paragraphs) {
            sb.AddRange(p.bidiText);
        }

        return sb;
    }
    
    /// <summary>
    /// Implementation of the BIDI algorithm, as described in http://www.unicode.org/reports/tr9/tr9-17.html
    /// </summary>
    /// <param name="logicalString">Is the original logical-ordered string.</param>
    /// <param name="indexes">Implies where the original characters are.</param>
    /// <param name="lengths">Implies how many characters each original character occupies.</param>
    /// <returns>Returns the visual representation of the string.</returns>
    public static string LogicalToVisual2(
        String logicalString,
        List<int> indexes,
        List<int> lengths
    ) {
        //Section 3:
        //1. seperate text into paragraphs
        //2. resulate each paragraph to its embeding levels of text
        //2.1 find the first character of type L, AL, or R.
        //3. reorder text elements

        //Section 3.3: Resolving Embedding Levels:
        //(1) determining the paragraph level.
        //(2) determining explicit embedding levels and directions.
        //(3) resolving weak types.
        //(4) resolving neutral types.
        //(5) resolving implicit embedding levels.

        var paragraphs = BidiString.FromLogical(logicalString).Paragraphs;

        var sb = new List<int>();
        foreach (var p in paragraphs) {
            sb.AddRange(p.bidiText);
            indexes.AddRange(p.indices);
        }

        return new string(sb.Select(c => (char)c).ToArray());
    }
}