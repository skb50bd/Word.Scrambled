namespace Word.Scrambled.Shared;

public record Guess
{
    public List<(char letter, MatchType type)> Result { get; set; }

    public Guess(string word, string guess)
    {
        (word, guess) = CleanAndValidate(word, guess);
        Result        = new();

        for (var i = 0; i < word.Length; i++)
        {
            var letter = guess[i];

            if (word[i] == letter)
            {
                Result.Add((letter, MatchType.CorrectPosition));
                continue;
            }
            else if (word.Contains(letter) is false)
            {
                Result.Add((letter, MatchType.None));
                continue;
            }

            var countInGuess = guess.Count(ch => ch == letter);
            var countInWord  = word.Count(ch => ch == letter);

            var exactMatchCount =
                word.Zip(guess, (w, g) => (w, g))
                    .Count(wg => wg.w == wg.g && wg.g == letter);

            if (countInGuess <= countInWord
                && exactMatchCount < countInGuess)
            {
                Result.Add((letter, MatchType.IncorrectPosition));
            }
            else if (countInGuess > countInWord
                    && exactMatchCount < countInGuess)
            {
                Result.Add((letter, MatchType.None));
            }
            else
            {
                throw new InvalidDataException();
            }
        }
    }

    private static (string word, string guess)
        CleanAndValidate(string word, string guess)
    {
        word  = word.Trim().ToUpper();
        guess = guess.Trim().ToUpper();

        if (word.Length is 0)
        {
            throw new ArgumentException(
                $"{nameof(word)} is empty");
        }
        else if (guess.Length is 0)
        {
            throw new ArgumentException(
                $"{nameof(guess)} is empty");
        }
        else if (word.Any(ch => char.IsLetter(ch) is false))
        {
            throw new ArgumentException(
                $"{nameof(word)} contains non-alphabetic characters.");
        }
        else if (guess.Any(ch => char.IsLetter(ch) is false))
        {
            throw new ArgumentException(
                $"{nameof(guess)} contains non-alphabetic characters.");
        }
        else if (word.Length != guess.Length)
        {
            throw new ArgumentException(
                $"{nameof(word)} and {nameof(guess)} must have same legth.");
        }

        return (word, guess);
    }
}
