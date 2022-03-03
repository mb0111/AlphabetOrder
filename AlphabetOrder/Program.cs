using AlphabetOrder.Exceptions;
using AlphabetOrder.Factory;
using AlphabetOrder.Interfaces;
using AlphabetOrder.Provider;
using System;

namespace AlphabetOrder
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello AlphabetOrder\n\n");
            try
            {
                SentenceOperation();
                Console.WriteLine();
                LettersOperation();
            }
            catch (Exception exception)
            {
                HandleException(exception);
            }
            Console.ReadKey();
        }

        private static void SentenceOperation()
        {
            Console.WriteLine($"{nameof(SentenceOperation)}");

            IAlphabetOrder alphabetOrder = new SentenceFactory();
            string sentence = "write the alphabet";
            Console.WriteLine($"Input: {sentence}");
            AlphabetProvider alphabetProvider = new AlphabetProvider(alphabetOrder);
            string orderedSentence = alphabetProvider.OrderByAsc(sentence);
            Console.WriteLine($"Ordered output: {orderedSentence}");
        }

        private static void LettersOperation()
        {
            Console.WriteLine($"{nameof(LettersOperation)}");

            IAlphabetOrder alphabetOrder = new LettersFactory();
            string sentence = "have a nice day";
            Console.WriteLine($"Input: {sentence}");
            AlphabetProvider alphabetProvider = new AlphabetProvider(alphabetOrder);
            string orderedSentence = alphabetProvider.OrderByAsc(sentence);
            Console.WriteLine($"Ordered output: {orderedSentence}");
        }

        private static void HandleException(Exception exception)
        {
            switch (exception)
            {
                case SentenceException sentenceException:
                    HandleSentenceException(sentenceException);
                    break;
                case LettersException lettersException:
                    HandleLettersException(lettersException);                    
                    break;
                default:
                    HandleGenericException(exception);
                    break;
            }

            void HandleSentenceException(SentenceException sentenceException)
            {
                // Save log... sentenceException.LogMessage 
                Console.WriteLine(sentenceException.Message);
            }

            void HandleLettersException(LettersException lettersException)
            {
                // Save log... lettersException.LogMessage 
                Console.WriteLine(lettersException.Message);
            }

            void HandleGenericException(Exception exception)
            {
                Guid errorId = Guid.NewGuid();
                // Save log... exception.Message
                Console.WriteLine($"Internal Error. Refer to this Error Id: {errorId} for further investigation with system administrator");
            }
        }

    }
}
