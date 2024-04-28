using Microsoft.Extensions.Configuration;

namespace Estoque.Infra
{
    public class DatabaseConfiguration
    {
        public string ConnectionString { get; set; } = null!;
        public IConfiguration Configuration { get; set; } = null!;

        public DatabaseConfiguration(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDb");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException($"String de conexão inválida!");
            }
        }
    }
}
