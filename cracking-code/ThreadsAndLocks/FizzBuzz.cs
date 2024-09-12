using System.Collections.Concurrent;

namespace ThreadsAndLocks
{
    /*
      Cracking the coding interview)
    */
    public partial class FizzBuzz
    {

        public static async Task FizzBuz(int n, CancellationTokenSource cts)
        {
            ConcurrentQueue<int> integerQueue = new ();
            CancellationToken ct = cts.Token;

            //This thread will put numbers in a queue            
            var numProducer = Task.Run(() =>
            {
                Console.WriteLine("Number producer started...");
                for (int i = 1; i <= n && !ct.IsCancellationRequested; i++)
                {
                    if ((i % 3 == 0) || (i % 5 == 0))
                    {
                        Console.WriteLine($"Produced number {i}");
                        integerQueue.Enqueue(i);
                        Task.Delay(500).Wait();
                    }
                }
                
                Console.WriteLine("Cancelling number production for FizzBuzz...");
                cts.Cancel();
            }, ct);

            //Others will remove the numbers and process them
            var taskFizz = Task.Run(() =>
            {
                Console.WriteLine("Fizz started...");
                while (!ct.IsCancellationRequested) {
                    if (integerQueue.TryPeek(out int i))
                    {
                        Console.WriteLine($"Fizz picked {i}...");
                        if (i % 3 == 0 && !(i % 5 == 0))
                        {
                            if (integerQueue.TryDequeue(out int j))
                            {
                                Console.WriteLine($"Fizz({i}) from {Thread.CurrentThread.ManagedThreadId}");
                            }
                        }

                    }
                   Task.Delay(200).Wait();
                }

                Console.WriteLine("Fizz finished...");

            }, ct);

            var taskBuzz = Task.Run(() =>
            {
                Console.WriteLine("Buzz started...");
                while (!ct.IsCancellationRequested) 
                {
                    if (integerQueue.TryPeek(out int i))
                    {
                        Console.WriteLine($"Buzz picked {i}...");
                        if (!(i % 3 == 0) && (i % 5 == 0))
                        {
                            if (integerQueue.TryDequeue(out int j))
                            {
                                Console.WriteLine($"Buzz({i}) from {Thread.CurrentThread.ManagedThreadId}");
                            }
                        }

                    }

                    Task.Delay(200).Wait();
                }
                Console.WriteLine("Buzz finished...");

            }, ct);

            var taskFizzBuzz = Task.Run(() =>
            {
                Console.WriteLine("FizzBuzz started...");

                while (!ct.IsCancellationRequested)
                {
                    if (integerQueue.TryPeek(out int i))
                    {
                        Console.WriteLine($"FizzBuzz picked {i}...");
                        if ((i % 3 == 0) && (i % 5 == 0))
                        {
                            if (integerQueue.TryDequeue(out int j))
                            {
                                Console.WriteLine($"FizzBuzz({i}) from {Thread.CurrentThread.ManagedThreadId}");
                            }
                        }

                    }
                    Task.Delay(200).Wait();
                }

                Console.WriteLine("FizzBuzz finished...");

            }, ct);


            await Task.WhenAll(numProducer, taskFizz, taskBuzz, taskFizzBuzz);
        }


    }

}

