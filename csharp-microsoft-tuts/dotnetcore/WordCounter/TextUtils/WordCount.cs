using System;
using System.Linq;

namespace TextUtils
{
    public static class WordCount
    {
        public static int GetWordCount(string searchWord, string inputString){
            // Null check 
            if (String.IsNullOrEmpty(searchWord) || string.IsNullOrEmpty(inputString)){
                return 0;
            }

            // convert string into array of words
            var source = inputString.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' },
                                           StringSplitOptions.RemoveEmptyEntries);

            // create query 
            var matchQuery = from word in source
                             where word.ToLowerInvariant() == searchWord.ToLowerInvariant()
                             select word;

            return matchQuery.Count();
        }

    }
}
