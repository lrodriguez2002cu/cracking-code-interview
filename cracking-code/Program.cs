﻿// // See https://aka.ms/new-console-template for more information
// int[][] matrix = new int[][] { [1, 2, 3], [4, 5, 6], [7, 8, 9] };

// Console.WriteLine("Original:");
// StringsAndArrays.StringsAndArrays.PrintMatrix(matrix);

// StringsAndArrays.StringsAndArrays.RotateMatrixV1(matrix, 0);

// Console.WriteLine("Result rotated by 90 degrees:");
// //StringsAndArrays.StringsAndArrays.PrintMatrix(matrix);

using System.Diagnostics.CodeAnalysis;
using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;

public static class Example
{

    public static void Main()
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

