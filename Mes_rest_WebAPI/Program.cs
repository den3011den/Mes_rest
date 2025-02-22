namespace Mes_rest_WebAPI.WebHost
{
    /// <summary>
    /// ����� �������� ���������
    /// </summary>
    public class Program
    {
        /// <summary>
        /// ����� ������� ����������
        /// </summary>
        /// <param name="args">��������� �������</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// IHostBuilder
        /// </summary>
        /// <param name="args">��������� ������� ����������</param>
        /// <returns>IHostBuilder</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}