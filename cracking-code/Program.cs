
public static class Example
{

    public static async Task Main2()
    {
        CancellationTokenSource cts = new CancellationTokenSource();

        await ThreadsAndLocks.DinningPhilosophers.DinningPhilosophersAsync(4, cts, deadlock: true);

        var k = Console.ReadKey();
        if (k.Key == ConsoleKey.C)
        {
            Console.WriteLine("Cancelling dinner...");
            cts.Cancel();
        }
    }

    public static async Task Main3()
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        await ThreadsAndLocks.DinningPhilosophers.DinningPhilosophersAsync(4, cts, deadlock: false);

        var k = Console.ReadKey();
        if (k.Key == ConsoleKey.C)
        {
            Console.WriteLine("Cancelling dinner...");
            cts.Cancel();
        }
    }


    public static async Task Main()
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        await ThreadsAndLocks.FizzBuzz.FizzBuz(400, cts);

        var k = Console.ReadKey();
        if (k.Key == ConsoleKey.C)
        {
            
            //cts.Cancel();
        }
    }

    public static void Main1()
    {
        // Interrupt a sleeping thread.
        // var sleepingThread = new Thread(Example.SleepIndefinitely);
        // sleepingThread.Name = "Sleeping";
        // sleepingThread.Start();
        // Thread.Sleep(2000);
        // sleepingThread.Interrupt();

        // Thread.Sleep(1000);

        // sleepingThread = new Thread(Example.SleepIndefinitely);
        // sleepingThread.Name = "Sleeping2";
        // sleepingThread.Start();
        // Thread.Sleep(2000);

        CancellationTokenSource cts = new CancellationTokenSource();

        cts.CancelAfter(2000);

        var t1 = Task.Run(() =>
             {
                 Console.WriteLine("Hello World threaded.");
                 Console.WriteLine("I am making a delay.");
                 Task.Delay(5000);
                 Console.WriteLine("After a delay of 5 seconds.");

             }, cts.Token)
             .ContinueWith((Task t) =>
             {
                 if (t.IsCanceled)
                 {
                     Console.WriteLine("This is a continuation of cancelled Task...");
                 }
                 else
                 {
                     Console.WriteLine("This is a continuation of a NON cancelled task...");
                 }
             });

        var t2 = Task.Run(() => Console.WriteLine("This is another task."));

        Task.WaitAll(t1, t2);

        //sleepingThread.();
    }

    private static void SleepIndefinitely()
    {
        Console.WriteLine("Thread '{0}' about to sleep indefinitely.",
                          Thread.CurrentThread.Name);
        try
        {
            Thread.Sleep(Timeout.Infinite);
        }
        catch (ThreadInterruptedException)
        {
            Console.WriteLine("Thread '{0}' awoken.",
                              Thread.CurrentThread.Name);
        }
        catch (ThreadAbortException)
        {
            Console.WriteLine("Thread '{0}' aborted.",
                              Thread.CurrentThread.Name);
        }
        finally
        {
            Console.WriteLine("Thread '{0}' executing finally block.",
                              Thread.CurrentThread.Name);
        }
        Console.WriteLine("Thread '{0} finishing normal execution.",
                          Thread.CurrentThread.Name);
        Console.WriteLine();
    }

}

