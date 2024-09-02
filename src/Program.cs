namespace DotnetDocker;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello Docker");

        await Task.Run(async () =>
        {
            int i=0;
            while (true)
            {
                Console.WriteLine($"Hello from docker {i++}");
                await Task.Delay(1000);
            }
        });
    }
}
