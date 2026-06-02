using WebAPI.Interfaces;
using WebAPI.Services;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular", policy =>
                {
                    policy.WithOrigins("http://localhost:4104")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            builder.Services.AddSingleton<RepozytoriumPamiecioweService>();
            builder.Services.AddSingleton<IGetDataService>(sp => sp.GetRequiredService<RepozytoriumPamiecioweService>());
            builder.Services.AddSingleton<IFormSubmitService>(sp => sp.GetRequiredService<RepozytoriumPamiecioweService>());

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAngular");
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}