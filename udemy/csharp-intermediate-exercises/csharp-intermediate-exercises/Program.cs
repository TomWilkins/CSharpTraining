using System;
using System.Threading;

namespace csharp_intermediate_exercises
{
    partial class Program
    {
        static void Main(string[] args)
        {
            //TestStopwatch();

            //TestPost();


            var logger = new Logger();
            var dbMigrator = new DbMigrator(logger);
            var installer = new Installer(logger);


            var stack = new Stack();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

            Console.ReadLine();
        }

        private static void TestPost()
        {
            Post post = new Post("Test Post", "This a model of a stackoverflow post");
            Console.WriteLine($"The post {post.Title} has {post.Votes} votes.");
            post.UpVote();
            post.UpVote();
            Console.WriteLine($"The post {post.Title} has {post.Votes} votes.");
            post.DownVote();
            Console.WriteLine($"The post {post.Title} has {post.Votes} votes.");
        }

        private static void TestStopwatch()
        {
            Stopwatch stopwatch = new Stopwatch();

            // stopwatch.Stop(); throws exception

            Console.WriteLine($"Current duration: {stopwatch.Duration}");
            stopwatch.Start();
            // stopwatch.Start(); throws exception
            Thread.Sleep(5000);
            stopwatch.Stop();
            Console.WriteLine($"Current duration: {stopwatch.Duration}");

            stopwatch.Start();
            Thread.Sleep(5000);
            stopwatch.Stop();
            Console.WriteLine($"Current duration: {stopwatch.Duration}");
        }
    }
}
