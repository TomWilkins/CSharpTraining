using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Unshuffled deck");

            var startingDeck = (from s in Suits()
                                from r in Ranks()
                                select new {Suit = s, Rank = r}).ToArray();

            foreach(var c in startingDeck){
                Console.WriteLine(c);
            }



            var top = startingDeck.Take(26);
            var bottom = startingDeck.Skip(26);
            var times = 0;
            var shuffle = startingDeck;
            do
            {
                shuffle = shuffle.Take(26).InterleaveSequenceWith(shuffle.Skip(26)).ToArray();

                Console.WriteLine("");
                Console.WriteLine("Shuffled deck {0}", times);
                foreach (var c in shuffle)
                {
                    Console.WriteLine(c);
                }
                times++;
            } while (!startingDeck.SequenceEqual(shuffle));

            Console.WriteLine("It took {0} times", times);
            

        }

        

        static IEnumerable<string> Suits()
        {
            yield return "clubs";
            yield return "diamonds";
            yield return "hearts";
            yield return "spades";
        }

        static IEnumerable<string> Ranks()
        {
            yield return "two";
            yield return "three";
            yield return "four";
            yield return "five";
            yield return "six";
            yield return "seven";
            yield return "eight";
            yield return "nine";
            yield return "ten";
            yield return "jack";
            yield return "queen";
            yield return "king";
            yield return "ace";
        }

    }

    public static class Extensions
    {
        // extension method that will become avaliable on an IEnumerable type... 
        public static IEnumerable<T> InterleaveSequenceWith<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            var firstIter = first.GetEnumerator();
            var secondIter = second.GetEnumerator();

            while (firstIter.MoveNext() && secondIter.MoveNext())
            {
                yield return firstIter.Current;
                yield return secondIter.Current;
            }
        }


        public static bool SequenceEquals<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            var firstIter = first.GetEnumerator();
            var secondIter = second.GetEnumerator();

            while (firstIter.MoveNext() && secondIter.MoveNext())
            {
                if (!firstIter.Current.Equals(secondIter.Current))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
