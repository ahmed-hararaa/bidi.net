namespace Harara.Bidi;

/// A set of common Unicode characters, including BiDi control characters, and some Persian letters used mainly for testing purposes.
class BidiChars {
  /// Right-to-Left Mark
  /// Right-to-left zero-width non-Persian character.
  // public const int RLM = 0x200F;

  /// Start of Right-to-Left Embedding
  /// Treat the following text as embedded right-to-left.
  public const int Rle = 0x202B;

  /// Start of Right-to-Left Override
  /// Force following characters to be treated as strong right-to-left characters.

  public const int Rlo = 0x202E;

  /// Start of Right-to-Left Isolate
  /// Treat the following text as isolated and right-to-left.
  // public const int RLI = 0x2067;

  /// Left-to-Right Mark
  /// Left-to-right zero-width character.
  // public const int LRM = 0x200E;

  /// Start of Left-to-Right Embedding
  /// Treat the following text as embedded left-to-right.
  public const int Lre = 0x202A;

  /// Start of Left-to-Right Override
  /// Force following characters to be treated as strong left-to-right characters.
  public const int Lro = 0x202D;

  /// Start of Left-to-Right Isolate
  /// Treat the following text as isolated and left-to-right.
  // public const int LRI = 0x2066;

  /// Pop Directional Formatting
  /// End the scope of the last LRE, RLE, RLO, or LRO.
  public const int Pdf = 0x202C;

  /// Pop Directional Isolate
  /// End the scope of the last LRI, RLI, or FSI.
  // public const int PDI = 0x2069;

  /// First Strong Isolate
  /// Treat the following text as isolated and in the direction of its first strong directional character
  /// that is not inside a nested isolate.
  // public const int FSI = 0x2068;

  /// A Dummy Character Indicating None.
  public const int NotAChar = 0xFFFF;

  /// Persian Letter Lam
  public const int ArabicLam = 0x0644;

  /// Persian Letter Alef With Madda Above
  public const int ArabicAlefMaddaAbove = 0x0622;

  /// Persian Letter Alef With Hamza Above
  public const int ArabicAlefHamzaAbove = 0x0623;

  /// Persian Letter Alef With Hamza Below
  public const int ArabicAlefHamzaBelow = 0x0625;

  /// Persian Letter Alef
  public const int ArabicAlef = 0x0627;

  /// Persian Ligature Lam With Alef With Madda Above Isolated Form
  public const int ArabicLamAlefMaddaAboveIsolated = 0xFEF5;

  /// Persian Ligature Lam With Alef With Madda Above Final Form
  public const int ArabicLamAlefMaddaAboveFinal = 0xFEF6;

  /// Persian Ligature Lam With Alef With Hamza Above Isolated Form
  public const int ArabicLamAlefHamzaAboveIsolated = 0xFEF7;

  /// Persian Ligature Lam With Alef With Hamza Above Final Form
  public const int ArabicLamAlefHamzaAboveFinal = 0xFEF8;

  /// Persian Ligature Lam With Alef With Hamza Below Isolated Form
  public const int ArabicLamAlefHamzaBelowIsolated = 0xFEF9;

  /// Persian Ligature Lam With Alef With Hamza Below Final Form
  public const int ArabicLamAlefHamzaBelowFinal = 0xFEFA;

  /// Persian Ligature Lam With Alef Isolated Form
  public const int ArabicLamAlefIsolated = 0xFEFB;

  /// Persian Ligature Lam With Alef Final Form
  public const int ArabicLamAlefFinal = 0xFEFC;
}