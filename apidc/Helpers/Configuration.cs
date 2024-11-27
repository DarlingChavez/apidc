namespace apidc.Helpers
{
    public class Configuration
    {
        private static Configuration _instance;
        private static readonly object _lock = new();
        private readonly IConfigurationRoot _configuration;

        // Propiedad pública para acceder a la instancia única
        public static Configuration Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Configuration();
                        }
                    }
                }
                return _instance;
            }
        }

        // Constructor privado para evitar instanciación directa
        private Configuration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();
        }

        // Método para obtener la cadena de conexión
        public string GetConnectionString(string name = "DefaultConnectionString")
        {
            return _configuration.GetConnectionString(name);
        }
    }
}
