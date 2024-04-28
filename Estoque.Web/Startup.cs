using Estoque.Infra;

namespace Estoque.Web
{
    public class Startup
    {
        public DatabaseConfiguration DatabaseConfiguration { get; } = null!;
        public IConfiguration Configuration { get; set; } = null!;

        public Startup(IConfiguration configuration)
        {
            DatabaseConfiguration = new DatabaseConfiguration(configuration);
            Configuration = configuration;
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCors();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseReDoc(options =>
            {
                options.DocumentTitle = "Estoque API";
                options.SpecUrl = "/swagger/v1/swagger.json";
            });
        }
    }
}
