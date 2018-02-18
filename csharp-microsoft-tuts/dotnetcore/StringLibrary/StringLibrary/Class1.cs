using System;

namespace UtilityLibraries{

    public static class StringLibrary{

        // Extends string using the 'this' keyword 
        public static bool StartsWithUpper(this string str){
            if(String.IsNullOrWhiteSpace(str)){
                return false;
            }

            Char ch = str[0];
            return Char.IsUpper(ch);
        }

    }

}
