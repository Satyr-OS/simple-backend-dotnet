using Supabase;

namespace simple_backend_dotnet.Helpers
{
    public static class Database
    {
        public static async Task<Client> Initialize()
        {
            var url = Settings.DatabaseConfig.Url;
            var key = Settings.DatabaseConfig.Key;

            if (url is null || key is null)
            {
                throw new DatabaseConnectionFailed("Database Connection Error");
            }

            var options = new SupabaseOptions
            {
                AutoConnectRealtime = true
            };

            var supabase = new Supabase.Client(url, key, options);
            await supabase.InitializeAsync();

            return supabase;
        }

        public class Config
        {
            public string Url { get; set; }
            public string Key { get; set; }
        }
    }
}