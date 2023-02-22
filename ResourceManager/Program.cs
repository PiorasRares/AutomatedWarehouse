using DataAccess.DbAccess;

namespace ResourceManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AccessLayer access = new AccessLayer();
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapGet("/StorageType",(string description) => access.GetStorageTypes(description));

            app.Run();
        }
    }
}