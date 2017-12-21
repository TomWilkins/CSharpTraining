using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton.RealWorld
{

    //http://www.dofactory.com/net/singleton-design-pattern
    class Program
    {
        static void Main(string[] args)
        {
            LoadBalancer b1 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b2 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b3 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b4 = LoadBalancer.GetLoadBalancer();

            if(b1 == b2 && b2 == b3 && b3 == b4)
            {
                Console.WriteLine("same instance");
            }

            // load balance 15 requests
            LoadBalancer balancer = LoadBalancer.GetLoadBalancer();

            for (int i = 0; i < 15; i++)
            {
                string server = balancer.Server;
                Console.WriteLine("Dispatch Request to: " + server);
            }

            Console.ReadKey();
        }

        class LoadBalancer
        {
            private static LoadBalancer _instance;
            private List<String> _servers = new List<String>();
            private Random _random = new Random();

            // Lock synchronization object
            private static object syncLock = new object();

            protected LoadBalancer()
            {
                _servers.Add("Server1");
                _servers.Add("Server2");
                _servers.Add("Server3");
                _servers.Add("Server4");
            }

            public static LoadBalancer GetLoadBalancer()
            {
                // support multithreading through double checked locking pattern
                if(_instance == null)
                {
                    lock (syncLock)
                    {
                        if(_instance == null)
                        {
                            _instance = new LoadBalancer();
                        }
                    }
                }
                return _instance;
            }

            public string Server
            {
                get
                {
                    int r = _random.Next(_servers.Count);
                    return _servers[r].ToString();
                }
            }
        }
    }
}

namespace Singleton.Structural
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton s1 = Singleton.Instance();
            Singleton s2 = Singleton.Instance();

            if(s1 == s2)
            {
                Console.WriteLine("Objects are the same instance");
            }

            Console.ReadKey();
        }

        class Singleton
        {
            private static Singleton _instance;

            protected Singleton() { }

            public static Singleton Instance()
            {
                if(_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;
            }

        }
    }
}