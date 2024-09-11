namespace ThreadsAndLocks
{
    /*
      Cracking the coding interview)
    */
    public partial class ThreadsAndLocks
    {

        public static async Task DinningPhilosophersAsync(int numberOfPhilosophers, CancellationTokenSource ts, bool deadlock)
        {

            var shopSticks = new object[numberOfPhilosophers];

            for (int i = 0; i < numberOfPhilosophers; i++)
            {
                shopSticks[i] = new object();
            }

            var eatingTasks = new Task[numberOfPhilosophers];

            for (int i = 0; i < numberOfPhilosophers; i++)
            {
                Console.WriteLine($"Sitting philosopher {i}.");
                SitPhilosopher(numberOfPhilosophers, shopSticks, eatingTasks, ts, i, deadlock);

            }

            await Task.WhenAll(eatingTasks);
        }


        private static void SitPhilosopher(int numberOfPhilosophers, object[] shopSticks, Task[] eatingTasks, CancellationTokenSource ts, int ii, bool deadlock)
        {
            eatingTasks[ii] = Task.Run(async () =>
            {
                await Eat(ii, numberOfPhilosophers, shopSticks, ts.Token, deadlock);
            }, ts.Token);
        }



        //This implementation evidences the deadlock happening while taking the shopsticks
        private static async Task Eat(int philosopher, int numberOfPhilosophers, object[] shopSticks, CancellationToken ct, bool deadlock)
        {


            var leftShopstick = shopSticks[philosopher];
            var rightShopstick = shopSticks[(philosopher + 1) % numberOfPhilosophers];

            while (true && !ct.IsCancellationRequested)
            {

                if (deadlock)
                {
                    // this implementation finds easily a deadlock as it locks both resources carelessly
                    // a simple delay or even printing in the console might show the issue
                    lock (leftShopstick)
                    {
                        //Note that after a simple delay the deadlock is produced
                        Console.WriteLine($"Philosopher '{philosopher}' held left.");

                        lock (rightShopstick)
                        {
                            Console.WriteLine($"Philosopher {philosopher} held right.");
                            Console.WriteLine($"Philosopher {philosopher} is eating..using {Thread.CurrentThread.ManagedThreadId}");
                        }
                    }

                }
                else
                {
                    // This implementation avoids the deadlock by releasing the resources  in case can not obtain the next resource.
                    if (Monitor.TryEnter(leftShopstick))
                    {
                        try
                        {
                            Console.WriteLine($"Philosopher '{philosopher}' held left.");
                            if (Monitor.TryEnter(rightShopstick))
                            {

                                try
                                {
                                    Console.WriteLine($"Philosopher {philosopher} held right.");
                                    Console.WriteLine($"Philosopher {philosopher} is eating..using {Thread.CurrentThread.ManagedThreadId}");
                                }
                                finally { 
                                    Monitor.Exit(rightShopstick);
                                
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Occupied right chopstick {((philosopher + 1) % numberOfPhilosophers)}, leaving it ");
                            }
                        }
                        finally
                        {
                            Monitor.Exit(leftShopstick);
                        }
                    }
                }

                await Task.Delay(100);

            }
        }





    }

}

