namespace Harara.Bidi;

/// Used to determine current letter direction (Table 2 in the Unicode BiDi algorithm).
public enum DirectionOverride {
    /// No override is currently active.
    Neutral,

    /// Characters are to be reset to R.
    Rtl,

    /// Characters are to be reset to L.
    Ltr
}