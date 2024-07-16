

using Microsoft.Extensions.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {

        var config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();

        var connstr = config["ConnectionStrings:SqServerCon"];
        Console.WriteLine("Conn = "+connstr);
    }
}