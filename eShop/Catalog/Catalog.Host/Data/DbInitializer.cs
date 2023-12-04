using Catalog.Host.Data.Entities;

namespace Catalog.Host.Data;

public static class DbInitializer
{
    public static async Task Initialize(ApplicationDbContext context)
    {
        await context.Database.EnsureCreatedAsync();

        if (!context.CatalogCategory.Any())
        {
            await context.CatalogCategory.AddRangeAsync(GetPreconfiguredCatalogCategories());

            await context.SaveChangesAsync();
        }

        if (!context.CatalogItems.Any())
        {
            await context.CatalogItems.AddRangeAsync(GetPreconfiguredItems());

            await context.SaveChangesAsync();
        }
    }

    private static IEnumerable<CatalogCategory> GetPreconfiguredCatalogCategories()
    {
        return new List<CatalogCategory>()
        {
            new CatalogCategory() { Category = "All" },
            new CatalogCategory() { Category = "Rods" },
            new CatalogCategory() { Category = "Fishing line" },
            new CatalogCategory() { Category = "Floats" },
            new CatalogCategory() { Category = "Gigs" }
        };
    }

    private static IEnumerable<CatalogItem> GetPreconfiguredItems()
    {
        return new List<CatalogItem>()
        {
            new CatalogItem { CatalogCategoryId = 1, Description = "Winter fishing rod", Title = "Winter fishing rod", Price = 38M, PictureFileName = "1.png" },
            new CatalogItem { CatalogCategoryId = 1, Description = "Winter fishing rod", Title = "Winter fishing rod", Price = 040M, PictureFileName = "2.png" },
            new CatalogItem { CatalogCategoryId = 1, Description = "Winter fishing rod", Title = "Winter fishing rod", Price = 180M, PictureFileName = "3.png" },
            new CatalogItem { CatalogCategoryId = 1, Description = "Winter fishing rod", Title = "Winter fishing rod", Price = 960M, PictureFileName = "4.png" },
            new CatalogItem { CatalogCategoryId = 1, Description = "Winter fishing rod", Title = "Winter fishing rod", Price = 372M, PictureFileName = "5.png" },

            new CatalogItem { CatalogCategoryId = 2, Description = "Line ForMax Ice", Title = "Line ForMax Ice", Price = 64M, PictureFileName = "6.png" },
            new CatalogItem { CatalogCategoryId = 2, Description = "Line Colmic Xilo", Title = "Line Colmic Xilo", Price = 240M, PictureFileName = "7.png" },
            new CatalogItem { CatalogCategoryId = 2, Description = "Line Owner Broad", Title = "Line Owner Broad", Price = 185M, PictureFileName = "8.png" },
            new CatalogItem { CatalogCategoryId = 2, Description = "Line Owner Broad", Title = "Line Owner Broad", Price = 215M, PictureFileName = "9.png" },

            new CatalogItem { CatalogCategoryId = 3, Description = "Flagman Uralka", Title = "Flagman Uralka", Price = 52M, PictureFileName = "12.png" },
            new CatalogItem { CatalogCategoryId = 3, Description = "Tungsten jig", Title = "Tungsten jig", Price = 36M, PictureFileName = "13.png" },
            new CatalogItem { CatalogCategoryId = 3, Description = "Tungsten jig", Title = "Tungsten jig", Price = 60M, PictureFileName = "14.png" },

            new CatalogItem { CatalogCategoryId = 4, Description = "Winter float PZ1", Title = "Winter float PZ1", Price = 12M, PictureFileName = "10.png" },
            new CatalogItem { CatalogCategoryId = 4, Description = "Winter float PZ2", Title = "Winter float PZ2", Price = 13M, PictureFileName = "11.png" },
        };
    }
}