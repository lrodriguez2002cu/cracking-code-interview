
namespace cracking_code_tests;

using ThreadsAndLocks;


[TestClass]
public class ThreadsAndLocksTests
{

    [TestMethod]
    
    public async Task TestDinningPhilosophers()
    {
        var cts = new CancellationTokenSource();
        await ThreadsAndLocks.DinningPhilosophersAsync(4, cts, false);
        await Task.Delay(1000);
        cts.Cancel();
        await Task.Delay(1000);        
    }

}