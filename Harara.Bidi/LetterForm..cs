namespace Harara.Bidi;

/// The four different available letter presentation forms.
public enum LetterForm {
    /// A presentation form of a letter that begins a sequence of connected letters.
    Initial,

    /// A presentation form of a letter that is connected to other letters on both sides.
    Medial,

    /// A presentation form of a letter that ends a sequence of connected letters.
    FinalForm,

    /// A presentation form of a letter that is not connected to other letters on either sides.
    Isolated
}