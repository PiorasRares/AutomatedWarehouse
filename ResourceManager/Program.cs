using DataAccess.DataContext;
using DataAccess.Model;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace ResourceManager
{
    public class Program
    {

        public static void Main(string[] args)
        {
            StorageTypeRepository storageType = new StorageTypeRepository(new DataAccess.DataContext.Context());
            StorageLocationRepository storageLocation = new StorageLocationRepository(new DataAccess.DataContext.Context());
            ContainerRepository container = new ContainerRepository(new DataAccess.DataContext.Context());
            MaterialRepository material = new MaterialRepository(new DataAccess.DataContext.Context());
            TransferOrderRepository transferOrder = new TransferOrderRepository(new Context());

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


            app.MapGet("/StorageType",(string description) => storageType.GetStorageTypes(description));
            app.MapGet("/StorageLocation",(int storageTypeId)=> storageLocation.GetStorageLocations(storageTypeId));
            app.MapGet("/Container",(int storageLocationId)=>container.GetContainers(storageLocationId));
            app.MapGet("/Material",(int containerId)=>material.GetMaterials(containerId));
            app.MapGet("/TransferOrder",(int containerId)=>transferOrder.GetTransferOrders(containerId));
            app.MapGet("/Material/All", material.GetAllMaterials);
            app.MapPost("/TransferOrder/AddTransferOrder",transferOrder.AddTransferOrder);

            app.Run();
        }
    }
}