using AlphabetOrder.Exceptions;
using AlphabetOrder.Extensions;
using AlphabetOrder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlphabetOrder.Factory
{
    public class LettersFactory : IAlphabetOrder
    {
        private const char _splitSeparator = ' ';
        private const char _joinSeparator = ' ';

        /// <summary>
        /// Create a function which takes every letter in every word, and puts it in alphabetical order.
        /// Note how the original word lengths must stay the same.
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string OrderByAsc(string sentence)
        {
            if (sentence.IsNullOrWhiteSpace())
                throw new LettersException("Sentence could not be null or empty", $"{nameof(LettersFactory)}: NullOrWhiteSpace Sentence: {sentence}");
            try
            {
                string[] arrayOfWords = sentence.Split(_splitSeparator);
                string sortedLetters = SortLetters(sentence);

                StringBuilder stringBuilder = new StringBuilder();
                int prevIndex = 0;
                int nextIndex = 0;
                for (int i = 0; i < arrayOfWords.Length; i++)
                {
                    nextIndex = prevIndex + arrayOfWords[i].Length;
                    stringBuilder.Append(sortedLetters[prevIndex..nextIndex] + _joinSeparator);
                    prevIndex = nextIndex;
                }

                return stringBuilder.ToString().TrimEnd(_joinSeparator);
            }
            catch (Exception ex)
            {
                Guid errorId = Guid.NewGuid();
                throw new LettersException($"An error occured while ordering the sentence. Refer to this Error Id: {errorId} for further investigation with system administrator", $"{nameof(LettersFactory)}: Sentence: {sentence}, Error Id: {errorId}, Exception Message: {ex.Message}", ex);
            }
        }

        private static string SortLetters(string sentence)
        {
            string letters = String.Concat(sentence.Where(c => !Char.IsWhiteSpace(c)));
            char[] arrayOfLetters = letters.ToCharArray();
            Array.Sort(arrayOfLetters);
            return String.Join("", arrayOfLetters);
        }
    }
}
