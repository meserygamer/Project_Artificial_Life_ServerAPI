
using Microsoft.OpenApi.Models;

namespace Project_Artificial_Life_ServerAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddHttpClient();
            builder.Services.AddCors();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1",
                    Title = "Project Artificial Life API",
                    Description = "промежуточное API проекта PAL, для взаимодействия с нейросетями"
                });
            });

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors(builder => builder.AllowAnyOrigin());


            app.MapControllers();

            app.Run();
        }
    }
}
