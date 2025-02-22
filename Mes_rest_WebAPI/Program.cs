namespace Mes_rest_WebAPI.WebHost
{
    /// <summary>
    /// Класс основной программы
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка запуска приложения
        /// </summary>
        /// <param name="args">Аргументы запуска</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// IHostBuilder
        /// </summary>
        /// <param name="args">Аргументы запуска приложения</param>
        /// <returns>IHostBuilder</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}