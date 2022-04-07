using AutoMapper;
using ComidaEmCasa.Core.Data;
using ComidaEmCasa.Core.Mapper.MapperProfile;
using ComidaEmCasa.Core.Repository;
using ComidaEmCasa.Core.Repository.Interface;
using ComidaEmCasa.Core.Services;
using ComidaEmCasa.Core.Services.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ComidaEmCasa
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

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddHttpContextAccessor();
            var profile = new DefaultProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            IMapper mapper = new Mapper(configuration);
            services.AddSingleton(mapper);
            services.AddScoped<DbContext, ComidaEmCasaContext>();
            RegisterRepository(services);
            RegisterService(services);            
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
            services.AddDbContextPool<ComidaEmCasaContext>(options =>
            options.UseMySql(Configuration.GetConnectionString(ProjectVariables.ConnectionString), serverVersion));
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(sw =>
            {
                sw.SwaggerEndpoint("/swagger/v1/swagger.json", "Comida em casa API v1");
                sw.RoutePrefix = string.Empty;
            });
            app.UseHttpsRedirection();
            app.UseCors("AllowAllOrigins");

            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            //app.UseAuthenticationMiddleware();
            //app.UseHandleExceptionMiddleware();
            //app.UseGlobalExceptionHandler(loggerFactory);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<ComidaEmCasaContext>();
                dbContext.Database.Migrate();
            }
        }

        internal void RegisterService(IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
        }

        internal void RegisterRepository(IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}
