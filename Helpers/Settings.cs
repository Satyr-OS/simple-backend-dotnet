namespace simple_backend_dotnet.Helpers
{
    public static class Settings
    {
        private static IConfiguration AppSettings { get; } = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables()
        .Build();

        public static Database.Config DatabaseConfig
        {
            get
            {
                var conf = new Database.Config();
                AppSettings.GetSection("Database").Bind(conf);

                return conf;
            }
        }
    }
}