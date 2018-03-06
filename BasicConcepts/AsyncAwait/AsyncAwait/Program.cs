using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Timers;
using System.Diagnostics;

namespace AsyncAwait
{
    class Program
    {

        // Async and await are markers which mark code positions from where control should resume after a task completes
        static void Main(string[] args)
        {
            Stopwatch s = new Stopwatch();

            Console.WriteLine("Please wait...");
            //int count = StartCount();
            Task<int> count = StartCount2();
            s.Start();
            while (s.Elapsed < TimeSpan.FromMilliseconds(5000))
            {
                Thread.Sleep(1000);
                Console.WriteLine("Processing....");
            }
            Console.WriteLine($"Number of characters: {count.Result}");
        }

        // Mark method as async so we can call this method asynchronisly
        public static async Task<int> StartCount2()
        {
            Console.WriteLine("Async count");
            Task<int> task = new Task<int>(CountCharacters);
            task.Start(); // Starts this unit of work in another thread, meaing the UI is free

            int count = await task; // waits for task to complete, while returning to main thread execution.
            return count;
        }

        // This is the static verion which blocks the main thread...
        public static int StartCount(){
            int count = CountCharacters(); // we have to wait for this to finish...
            return count;
        }

        // This is the blocking method
        private static int CountCharacters(){
            Console.WriteLine("Starting to count characters");
            int count = 0;
            string path = Path.Combine(Environment.CurrentDirectory, "test.txt");

            if (File.Exists(path))
            {

                using (StreamReader reader = new StreamReader(path))
                {
                    string content = reader.ReadToEnd();
                    count = content.Length;
                    Thread.Sleep(5000);
                }
            }else{
                throw new Exception($"File '{path}' does not exist");
            }
            Console.WriteLine("Counted Characters");
            return count;
        }

    }
}
