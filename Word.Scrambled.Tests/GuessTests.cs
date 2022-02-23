using System.Collections;
using System.Collections.Generic;
using Word.Scrambled.Shared;
using Xunit;

namespace Word.Scrambled.Tests;

public class GuessTests
{
    [Theory]
    [ClassData(typeof(GuessTestData))]
    public void TestGuessClass(
        string gameWord!!,
        string guessWord!!,
        List<(char letter, MatchType type)> result!!)
    {
        var guess = new Guess(gameWord, guessWord);

        Assert.Equal(result, guess.Result);
    }
}

internal class GuessTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            "nice",
            "nice",
            new List<(char letter, MatchType type)>
            {
                ('N', MatchType.CorrectPosition),
                ('I', MatchType.CorrectPosition),
                ('C', MatchType.CorrectPosition),
                ('E', MatchType.CorrectPosition),
            }
        };

        yield return new object[]
        {
            "nice",
            "noce",
            new List<(char letter, MatchType type)>
            {
                ('N', MatchType.CorrectPosition),
                ('O', MatchType.None),
                ('C', MatchType.CorrectPosition),
                ('E', MatchType.CorrectPosition),
            }
        };

        yield return new object[]
        {
            "nice",
            "cipe",
            new List<(char letter, MatchType type)>
            {
                ('C', MatchType.IncorrectPosition),
                ('I', MatchType.CorrectPosition),
                ('P', MatchType.None),
                ('E', MatchType.CorrectPosition),
            }
        };

        yield return new object[]
        {
            "nnnice",
            "nnnnce",
            new List<(char letter, MatchType type)>
            {
                ('N', MatchType.CorrectPosition),
                ('N', MatchType.CorrectPosition),
                ('N', MatchType.CorrectPosition),
                ('N', MatchType.None),
                ('C', MatchType.CorrectPosition),
                ('E', MatchType.CorrectPosition),
            }
        };


        yield return new object[]
        {
            "nnnice",
            "nnicen",
            new List<(char letter, MatchType type)>
            {
                ('N', MatchType.CorrectPosition),
                ('N', MatchType.CorrectPosition),
                ('I', MatchType.IncorrectPosition),
                ('C', MatchType.IncorrectPosition),
                ('E', MatchType.IncorrectPosition),
                ('N', MatchType.IncorrectPosition),
            }
        };

        yield return new object[]
        {
            "cling",
            "stock",
            new List<(char letter, MatchType type)>
            {
                ('S', MatchType.None),
                ('T', MatchType.None),
                ('O', MatchType.None),
                ('C', MatchType.IncorrectPosition),
                ('K', MatchType.None)
            }
        };

        yield return new object[]
        {
            "cling",
            "mmmmm",
            new List<(char letter, MatchType type)>
            {
                ('M', MatchType.None),
                ('M', MatchType.None),
                ('M', MatchType.None),
                ('M', MatchType.None),
                ('M', MatchType.None)
            }
        };

        yield return new object[]
        {
            "tone",
            "none",
            new List<(char letter, MatchType type)>
            {
                ('N', MatchType.None),
                ('O', MatchType.CorrectPosition),
                ('N', MatchType.CorrectPosition),
                ('E', MatchType.CorrectPosition)
            }
        };

        yield return new object[]
        {
            "tone",
            "note",
            new List<(char letter, MatchType type)>
            {
                ('N', MatchType.IncorrectPosition),
                ('O', MatchType.CorrectPosition),
                ('T', MatchType.IncorrectPosition),
                ('E', MatchType.CorrectPosition)
            }
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}