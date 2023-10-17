using Microsoft.AspNetCore.Cors;

namespace GateWay
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowSpecificOrigin", builder =>
				{
					builder.WithOrigins("http://localhost:7171"); // Allow requests from the main project
					builder.AllowAnyHeader();
					builder.AllowAnyMethod();
				});
			});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseAuthorization();
			//builder.Services.AddHttpClient();

			app.MapControllers();
			app.UseCors("AllowSpecificOrigin"); // Apply CORS policy to the app

			app.Run();
		}
	}
}
