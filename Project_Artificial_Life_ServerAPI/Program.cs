
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
                    Description = "������������� API ������� PAL, ��� �������������� � �����������"
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
            }

            app.UseCors(builder => builder.AllowAnyOrigin());


            app.MapControllers();

            app.Run();
        }
    }
}
