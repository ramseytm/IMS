using IMS.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using  Microsoft.Extensions.DependencyInjection;

public static class DbInitializer{

    public static void Seed(IApplicationBuilder applicationBuilder)    {

        IMSDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IMSDbContext>();
        ProductRepository _productRepository = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ProductRepository>();
        LocationRepository _locationRepository = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<LocationRepository>();

        if (!context.Product.Any())
        {
            context.AddRange
            (
                new Product { ProductName = "Apple", CategoryID = 1, ManufacturerID = 1, Description = "Its an Apple", UnitPrice = 0.50M, QuantityInStock = Random.Shared.Next(1, 100), MinimumQuantity = 1, MaximumQuantity = 1000, UPC = "055555000010"},
                new Product { ProductName = "Avocado", CategoryID = 1, ManufacturerID = 1, Description = "Its an Avocado", UnitPrice = 1, QuantityInStock = Random.Shared.Next(1, 100), MinimumQuantity = 1, MaximumQuantity = 1000, UPC = "055555000020" },
                new Product { ProductName = "Banana", CategoryID = 1, ManufacturerID = 1, Description = "Its a Banana", UnitPrice = 10, QuantityInStock = Random.Shared.Next(1, 100), MinimumQuantity = 1, MaximumQuantity = 1000, UPC = "055555000030" },
                new Product { ProductName = "Cherry", CategoryID = 1, ManufacturerID = 1, Description = "Its a Cherry", UnitPrice = 0.10M, QuantityInStock = Random.Shared.Next(1, 100), MinimumQuantity = 1, MaximumQuantity = 1000, UPC = "055555000040" },
                new Product { ProductName = "Tomato", CategoryID = 1, ManufacturerID = 1, Description = "Its a Tomato", UnitPrice = 0.75M, QuantityInStock = Random.Shared.Next(1, 100), MinimumQuantity = 1, MaximumQuantity = 1000, UPC = "055555000050" }
            );
        }

        if (!context.Manufacturer.Any())
        {
            context.AddRange
            (
                new Manufacturer { ManufacturerName = "Produce Producer", Address = "123 Fake St.", ContactPerson = "Some guy", Email = "SomeGuy@ProduceProducer.net", Phone = "630-555-5555"}
            );
        }

        if (!context.Category.Any())
        {
            context.AddRange
            (
                new Category { CategoryName = "Produce", ParentCategory = null, Description = "Produce like fruits and veggies and stuff" }
            );
        }

        if (!context.Location.Any())
        {
            context.AddRange
            (
                new Location { LocationName = "Produce Producer Inc.", ParentLocation = null, Description = "Produce Producer Incorporated head office", MaxCapacity = 10000, CurrentOccupancy = 2000 }
            );
        }

        
        if (!context.Inventory.Any())        {

            IEnumerable<Product> products = _productRepository.GetProducts(1,5);
            IEnumerable<Location> locations = _locationRepository.GetLocations(1, 1);

            context.AddRange
            (
                new Inventory { Product = products.ElementAt(0), Location = locations.First(), Quantity = 50 },
                new Inventory { Product = products.ElementAt(1), Location = locations.First(), Quantity = 50 },
                new Inventory { Product = products.ElementAt(2), Location = locations.First(), Quantity = 50 },
                new Inventory { Product = products.ElementAt(3), Location = locations.First(), Quantity = 50 },
                new Inventory { Product = products.ElementAt(4), Location = locations.First(), Quantity = 50 }
            ); ;
        }

        context.SaveChanges();
    }
}