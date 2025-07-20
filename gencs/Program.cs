using Microsoft.Extensions.Configuration;

namespace gencs
{
    internal class Program
    {
        static int Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile($"appsettings.json")
                 .Build();


            Version? version = typeof(Program).Assembly.GetName().Version;
            string title = $"C# Code Generation Command Line Interface v{version}";
            Console.Title = title;

            int result = -1;
            try
            {
                var mainMenu = new MainMenu(configuration);
                result = mainMenu.Run(args, title);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            return result;
        }
    }
}