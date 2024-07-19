using CampFes.Models;
using CampFes.Service.DataServices;
using CampFes.Service.Interfaces;
using CampFes.WebApi.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NLog.Extensions.Logging;
using NLog.Web;
using System.Reflection;

namespace CampFes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

            //�K�[�t�m
            builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                 .AddJsonFile($"appsettings.{environmentName}.json", optional: true);

            IConfiguration configuration = builder.Configuration;

            //�NNLog���U�즹�M�פ�
            builder.Logging.ClearProviders();
            //�]�wlog�������̤p����
            builder.Logging.SetMinimumLevel(LogLevel.Trace);
            builder.Logging.AddNLog(configuration);

            //JSON �ǦC�ƿﶵ
            builder.Services.AddMvc().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            builder.Services.AddControllers();

            //DB migration
            string? connectionStr = builder.Configuration.GetConnectionString("AzureConnStr");
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionStr, sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null);
                }));


            //�K�[ Swagger �A��
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

                //Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                option.IncludeXmlComments(xmlPath);

                option.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "JWT Authorization header without Bearer (Example: '12345abcdef')"
                    });

                option.AddSecurityRequirement(
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            builder.Services.AddControllers();

            #region DI
            builder.Services.AddScoped<AppDbContext>();
            builder.Services.AddSingleton<ICheckService, CheckService>();
            builder.Services.AddSingleton<IJwtService, JwtService>();
            builder.Services.AddSingleton<ILoginService, LoginService>();
            builder.Services.AddSingleton<IQuestService, QuestService>();
            #endregion

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.Migrate();
            }

            //app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            app.UseSwagger();
            app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();

            //�����h
            app.UseMiddleware<ApiLoggingMiddleware>(); //Log����

            app.UseAuthentication(); //�[�J����
            app.UseRouting();
            app.UseAuthorization(); //�[�J���v

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseStatusCodePages();

            app.Run();
        }
    }
}
