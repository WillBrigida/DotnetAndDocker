using Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration) => _configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var host = _configuration["DBHOST"] ?? "localhost";
            var port = _configuration["DBPORT"] ?? "3306";
            var password = _configuration["DBPASSWORD"] ?? "000000";
            var dbName = _configuration["DBNAME"] ?? "PlanetsDB";

            var connectionString = $"server={host};port={port};database={dbName};user=root;password={password}";

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));

            services.AddDbContext<AppDbContext>(
           dbContextOptions => dbContextOptions
               .UseMySql(connectionString, serverVersion)
               // The following three options help with debugging, but should
               // be changed or removed for production.
               .LogTo(Console.WriteLine, LogLevel.Information)
               .EnableSensitiveDataLogging()
               .EnableDetailedErrors());

            services.AddOptions();
            services.AddAuthorizationCore();

            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
            });

            services.AddControllers();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));

                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
                //endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
