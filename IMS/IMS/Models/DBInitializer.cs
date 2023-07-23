using IMS.Models;

public static class DbInitializer
{
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
        IMSDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IMSDbContext>();

        if (!context.InventoryItems.Any())
        {
            context.AddRange
            (
                new InventoryItem { Description = "Apple", Date = DateTime.Now.AddDays(Random.Shared.Next(0, 5)), Quantity = Random.Shared.Next(1, 100) },
                new InventoryItem { Description = "Avocado", Date = DateTime.Now.AddDays(Random.Shared.Next(0, 5)), Quantity = Random.Shared.Next(1, 100) },
                new InventoryItem { Description = "Banana", Date = DateTime.Now.AddDays(Random.Shared.Next(0, 5)), Quantity = Random.Shared.Next(1, 100) },
                new InventoryItem { Description = "Cherry", Date = DateTime.Now.AddDays(Random.Shared.Next(0, 5)), Quantity = Random.Shared.Next(1, 100) },
                new InventoryItem { Description = "Tomato", Date = DateTime.Now.AddDays(Random.Shared.Next(0, 5)), Quantity = Random.Shared.Next(1, 100) }
            );
        }

        context.SaveChanges();
    }
}