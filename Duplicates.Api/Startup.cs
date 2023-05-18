using System.Reflection;
using Duplicates.Core.Interfaces;
using Duplicates.Data;
using Duplicates.Data.Entities;
using Duplicates.Data.Repositories;
using Duplicates.Services.Json;
using Duplicates.Services.Logs;
using Duplicates.Services.Statistics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Duplicates.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddVersionedApiExplorer(o =>
            {
                o.GroupNameFormat = "'v'VVV";
                o.SubstituteApiVersionInUrl = true;
            });
            services.AddApiVersioning();
            services.AddSwaggerGen();
            
            services.AddDbContext<DuplicatesContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"),
                    npgsqlOptions =>
                    {
                        npgsqlOptions.MigrationsAssembly(typeof(Statistic).GetTypeInfo().Assembly.GetName().Name);
                    }
                );
            });

            services.AddTransient<IFileService, JsonFileService>();
            services.AddTransient<IStatisticsService, StatisticsService>();

            services.AddTransient<ILogsService, LogsService>();
            services.AddTransient<ILogsRepository, LogsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "Duplicates.Api");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetService<DuplicatesContext>();
            context.Database.Migrate();
        }
    }
}