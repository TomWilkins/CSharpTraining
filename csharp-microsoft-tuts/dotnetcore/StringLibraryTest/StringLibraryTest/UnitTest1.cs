using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtilityLibraries;

namespace StringLibraryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestStartsWithUpper()
        {
            // Tests that we expect to return true
            string[] words = { "Alphabet", "Zebra", "ABC", "Aasfa" };

            foreach (var w in words)
            {
                bool result = w.StartsWithUpper();
                Assert.IsTrue(result, $"Expected for '{w}': true, actual result: {result}");


            }

        }

        [TestMethod]
        public void TestDoesNotStartWithUpper(){
            // Tests that we expect to return false
            string[] words =  { "alphabet", "zebra", "abc", "αυτοκινητοβιομηχανία", "государство",
                               "1234", ".", ";", " " };

            foreach (var w in words)
            {
                bool result = w.StartsWithUpper();
                Assert.IsFalse(result, $"Expected for '{w}': false, actual result: {result}");
            }
        }

        [TestMethod]
        public void DirectCallWithNullOrEmpty(){
            // Tests that we expect to return false
            string[] words = { string.Empty, null };
            foreach (var w in words)
            {
                bool result = StringLibrary.StartsWithUpper(w);
                Assert.IsFalse(result, String.Format("Expected for {0}: false, actual {1}", w == null ? "<null>" : w, result));
            }
        }
    }
}
