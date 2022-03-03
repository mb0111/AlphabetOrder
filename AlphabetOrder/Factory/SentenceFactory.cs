using AlphabetOrder.Exceptions;
using AlphabetOrder.Extensions;
using AlphabetOrder.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphabetOrder.Factory
{
    public class SentenceFactory : IAlphabetOrder
    {
        private const char _splitSeparator = ' ';
        private const char _joinSeparator = ' ';

        /// <summary>
        /// Order alphabetically the words from a sentence. (all words are lower case)
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string OrderByAsc(string sentence)
        {
            if (sentence.IsNullOrWhiteSpace())
                throw new SentenceException("Sentence could not be null or empty", $"{nameof(SentenceFactory)}: NullOrWhiteSpace Sentence: {sentence}");

            try
            {
                string[] arrayOfWords = sentence.Split(_splitSeparator);
                Array.Sort(arrayOfWords);
                return String.Join(_joinSeparator, arrayOfWords);
            }
            catch (Exception ex)
            {
                Guid errorId = Guid.NewGuid();
                throw new SentenceException($"An error occured while ordering the sentence. Refer to this Error Id: {errorId} for further investigation with system administrator", $"{nameof(SentenceFactory)}: Sentence: {sentence}, Error Id: {errorId}, Exception Message: {ex.Message}", ex);
            }
        }
    }
}
