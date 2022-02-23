namespace Word.Scrambled.Shared;

public enum MatchType
{
    /// <summary>
    /// Match In Correct Position
    /// </summary>
    CorrectPosition,

    /// <summary>
    /// Match In Incorrect Position
    /// </summary>
    IncorrectPosition,

    /// <summary>
    /// No Match
    /// </summary>
    /// <remarks>
    /// Letter is not found in the word
    /// </remarks>
    None
}