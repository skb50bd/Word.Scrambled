namespace Word.Scrambled.Shared;

public class Game
{
    public string Word { get; init; }
    public DateOnly Date { get; init; }
    public List<Guess> Guesses { get; init; }

}