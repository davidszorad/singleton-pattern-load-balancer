using System;

namespace SingletonPatternLoadBalancer
{
    /*
    The .NET optimized code demonstrates the same code as above but uses more modern, built-in .NET features.
    Here an elegant .NET specific solution is offered. The Singleton pattern simply uses a private constructor 
    and a static readonly instance variable that is lazily initialized. Thread safety is guaranteed by the compiler.

    This real-world code demonstrates the Singleton pattern as a LoadBalancing object. Only a single instance (the singleton) 
    of the class can be created because servers may dynamically come on- or off-line and every request must go throught 
    the one object that has knowledge about the state of the (web) farm.
    */


    /// <summary>
    /// MainApp startup class for .NET optimized 
    /// Singleton Design Pattern.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main(string[] args)
        {
            LoadBalancer b1 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b2 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b3 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b4 = LoadBalancer.GetLoadBalancer();

            // Confirm these are the same instance
            if (b1 == b2 && b2 == b3 && b3 == b4)
            {
                Console.WriteLine("Same instance\n");
            }

            // Next, load balance 15 requests for a server
            LoadBalancer balancer = LoadBalancer.GetLoadBalancer();
            for (int i = 0; i < 15; i++)
            {
                string serverName = balancer.NextServer.Name;
                Console.WriteLine("Dispatch request to: " + serverName);
            }

            // Wait for user
            Console.ReadKey();
        }
    }
}