using AlphabetOrder.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphabetOrder.Provider
{
    public class AlphabetProvider
    {
        IAlphabetOrder _alphabetOrder;

        public AlphabetProvider(IAlphabetOrder alphabetOrder)
        {
            _alphabetOrder = alphabetOrder ?? throw new ArgumentNullException(nameof(alphabetOrder));
        }

        public string OrderByAsc(string sentence)
        {
            return _alphabetOrder.OrderByAsc(sentence);
        }
    }
}
