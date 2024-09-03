using System.IO.Ports;

namespace DotnetDocker;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello Docker");

        var port = new SerialPort("/dev/ttyUSB0");
        var msg = "";

        try
        {
            port.Open();
        }
        catch (System.Exception ex)
        {
           Console.WriteLine(ex.Message);
        }

        await Task.Run(async () =>
        {
            int i=0;
            while (true)
            {
                msg = $"Hello from docker {i++}";
                Console.WriteLine(msg);
                port.WriteLine(msg);
                await Task.Delay(1000);
            }
        });
    }
}
