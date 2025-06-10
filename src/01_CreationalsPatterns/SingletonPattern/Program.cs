using System;
using System.Threading.Tasks;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Singleton Pattern!");


            LoadBalancerTest();

            MessageService messageService = new MessageService();
            messageService.Send("a");

            PrintService printService = new PrintService();
            printService.Print("b", 2);

            if (object.ReferenceEquals(messageService.logger, printService.logger))
            {
                Console.WriteLine("The same instances");
            }
            else
            {
                Console.WriteLine("Not the same instances");
            }


          //  StateMonitorTest();

            // StateMonitorMultiThreadTest();

            Console.ReadKey();
        }

        private static void StateMonitorTest()
        {
            for (int i = 0; i < 3; i++)
            {
                var state = new MonitorState(); // 🔴 każda iteracja = nowy obiekt

                state.IncrementEnqueued();
                state.IncrementProcessed();
                state.IncrementSent();

                Console.WriteLine($"[Iteracja {i + 1}] Stan:");
                state.PrintStatus(); // pokazuje zawsze 1, 1, 1
            }

            Console.WriteLine("\nKoniec programu – ale stan nie był zachowany między iteracjami!");
        }

        private static void StateMonitorMultiThreadTest()
        {
            var state = new MonitorState();

            int iterations = 1_000_000;

            Parallel.For(0, iterations, i =>
            {
                state.IncrementEnqueued();
            });

            Console.WriteLine($"Oczekiwano: {iterations} enqueued");
            state.PrintStatus(); // Będzie mniej niż 1_000_000
        }

        private static void LoadBalancerTest()
        {
            Task.Run(() => LoadBalanceRequestTest(15));
            Task.Run(() => LoadBalanceRequestTest(15));
        }

        private static void LoadBalanceRequestTest(int numberOfRequests)
        {
            LoadBalancer loadBalancer = LoadBalancer.Instance;

            for (int i = 0; i < numberOfRequests; i++)
            {
                Server server = loadBalancer.NextServer;
                Console.WriteLine($"Send request to: {server.Name} {server.IP}");
            }
        }

        

        
    }




  
}
