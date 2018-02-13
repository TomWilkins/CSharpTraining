using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;

namespace RESTClient
{
    class Program
    {

        static void Main(string[] args)
        {
            string user = "dotnet";
            if(args.Length > 0)
            {
                user = args[0];
            }


            Console.WriteLine("Finding Github repos for {0}", user);

            var repositories = ProcessRepositories(user).Result;

            foreach (var repo in repositories)
            {
                Console.WriteLine(repo.Name);
                Console.WriteLine(repo.Description);
                Console.WriteLine(repo.GitHubHomeUrl);
                Console.WriteLine(repo.Homepage);
                Console.WriteLine(repo.Watchers);
                Console.WriteLine(repo.LastPush);
                Console.WriteLine();
            }
        }

        private static async Task<List<Repository>> ProcessRepositories(string user)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            

            var serializer = new DataContractJsonSerializer(typeof(List<Repository>));


            var streamTask = client.GetStreamAsync(string.Format("https://api.github.com/orgs/{0}/repos", user));
            var repositories = serializer.ReadObject(await streamTask) as List<Repository>;

            return repositories;
        }

       
    }
}
