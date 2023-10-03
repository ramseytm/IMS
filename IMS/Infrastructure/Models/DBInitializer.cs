using IMS.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace IMS.Infrastructure.Models;

public static class DbInitializer
{
    public static async Task SeedAsync(IApplicationBuilder applicationBuilder)
    {
        using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
        var serviceProvider = serviceScope.ServiceProvider;

        await using var dbContext = serviceProvider.GetRequiredService<IMSDbContext>();
        var productRepository = serviceProvider.GetRequiredService<IProductRepository>();
        var locationRepository = serviceProvider.GetRequiredService<ILocationRepository>();

        _ = await dbContext.Database.EnsureCreatedAsync();

        if (!dbContext.Product.Any())
        {
            await dbContext.AddRangeAsync
            (
                new Product { ProductName = "Apple", CategoryID = 1, ManufacturerID = 1, Description = "Its an Apple", UnitPrice = 0.50M, QuantityInStock = Random.Shared.Next(1, 100), MinimumQuantity = 1, MaximumQuantity = 1000, UPC = "055555000010" },
                new Product { ProductName = "Avocado", CategoryID = 1, ManufacturerID = 1, Description = "Its an Avocado", UnitPrice = 1, QuantityInStock = Random.Shared.Next(1, 100), MinimumQuantity = 1, MaximumQuantity = 1000, UPC = "055555000020" },
                new Product { ProductName = "Banana", CategoryID = 1, ManufacturerID = 1, Description = "Its a Banana", UnitPrice = 10, QuantityInStock = Random.Shared.Next(1, 100), MinimumQuantity = 1, MaximumQuantity = 1000, UPC = "055555000030" },
                new Product { ProductName = "Cherry", CategoryID = 1, ManufacturerID = 1, Description = "Its a Cherry", UnitPrice = 0.10M, QuantityInStock = Random.Shared.Next(1, 100), MinimumQuantity = 1, MaximumQuantity = 1000, UPC = "055555000040" },
                new Product { ProductName = "Tomato", CategoryID = 1, ManufacturerID = 1, Description = "Its a Tomato", UnitPrice = 0.75M, QuantityInStock = Random.Shared.Next(1, 100), MinimumQuantity = 1, MaximumQuantity = 1000, UPC = "055555000050" }
            );

            await dbContext.SaveChangesAsync();
        }

        if (!dbContext.Manufacturer.Any())
        {
            await dbContext.AddRangeAsync
            (
                new Manufacturer { ManufacturerName = "Produce Producer", Address = "123 Fake St.", ContactPerson = "Some guy", Email = "SomeGuy@ProduceProducer.net", Phone = "630-555-5555" }
            );

            await dbContext.SaveChangesAsync();
        }

        if (!dbContext.Category.Any())
        {
            await dbContext.AddRangeAsync
            (
                new Category { CategoryName = "Produce", ParentCategory = null, Description = "Produce like fruits and veggies and stuff" },
                new Category { CategoryName = "Kitchen", ParentCategory = null, Description = "Kitchen utensils, appliances and housewares." }
            );

            await dbContext.SaveChangesAsync();
        }

        if (!dbContext.Location.Any())
        {
            await dbContext.AddRangeAsync
            (
                new Location { LocationName = "Produce Producer Inc.", ParentLocation = null, Description = "Produce Producer Incorporated head office", MaxCapacity = 10000, CurrentOccupancy = 2000 }
            );

            await dbContext.SaveChangesAsync();
        }

        if (!dbContext.Inventory.Any())
        {
            var products = productRepository.GetProducts(1, 5);
            var location = locationRepository.GetLocations(1, 1).FirstOrDefault();

            foreach (var product in products)
            {
                _ = await dbContext.AddAsync(new Inventory { Product = product, Location = location, Quantity = 50 });
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
