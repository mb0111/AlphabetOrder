using System;
using System.Collections.Generic;
using System.Text;

namespace AlphabetOrder.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string item)
        {
            return string.IsNullOrEmpty(item);
        }

        public static bool IsNotNullOrEmpty(this string item)
        {
            return !string.IsNullOrEmpty(item);
        }

        public static bool IsNullOrWhiteSpace(this string item)
        {
            return string.IsNullOrWhiteSpace(item);
        }

        public static bool IsNotNullOrWhiteSpace(this string item)
        {
            return !string.IsNullOrWhiteSpace(item);
        }
    }
}
