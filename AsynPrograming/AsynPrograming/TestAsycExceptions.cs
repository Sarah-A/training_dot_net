namespace AsynPrograming;

public class TestAsycExceptions
{

    public static void Test(bool throwBeforeAwait)
    {
        CatchSyncAndAsyncExceptions(throwBeforeAwait).GetAwaiter().GetResult();
    }

    public static async Task CatchSyncAndAsyncExceptions(bool throwBeforeAwait)
    {
        Task task = null;
        try
        {
            // The exception will be thrown in the sync part of the async method:
            task = AsyncMethodThrowInSync(throwBeforeAwait);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught exception when assigning the task: {ex.Message}");
            return;
        }

        try
        {
            await task;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught exception ON await: {ex.Message}");
        }
    }
    
    private static async Task AsyncMethodThrowInSync(bool throwBeforeAwait)
    {
        if (throwBeforeAwait)
        {
            throw new Exception("This is a Synchronous exception from BEFORE the await.");
        }
        await Task.Delay(1000);
        throw new Exception("This is an Asynchronous exception from AFTER the await.");
    }
}