namespace Luxe.Models
{
    public static class DbIntializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            LuxeDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<LuxeDbContext>();
            if(!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if(!context.Products.Any())
            {
                context.AddRange(
                    new Product {
                        Name = "NIVEA Daily Essentials Refreshing Face Wash Gel 150ml",
                        Price = 4.55M,
                        ShortDescription = "NIVEA Refreshing Wash Gel deeply cleanses and hydrates your skin for a clean and refreshed look and feel.",
                        LongDescription = "NIVEA Refreshing Wash Gel deeply cleanses and hydrates your skin for a clean and refreshed look and feel. The formula combines deep cleansing properties with the moisturising benefits of Vitamin E.",
                        Category = Categories["Skin Care"],
                        ImageUrl = "https://media.superdrug.com//medias/sys_master/prd-images/hbc/h78/10752810844190/prd-front-457366_600x600/prd-front-457366-600x600.jpg",
                        ImageThumbnailUrl = "https://media.superdrug.com//medias/sys_master/prd-images/hbc/h78/10752810844190/prd-front-457366_600x600/prd-front-457366-600x600.jpg",
                        InStock = true
                    },

                    new Product
                    {
                        Name = "Maybelline Instant Perfector 4-In-1 Glow Light Cool",
                        Price = 13.99M,
                        ShortDescription = "Instant Anti Age Perfector 4-In-1 Glow is Maybelline's 1st 4-in-1 makeup for a glow look that primes, conceals, highligh...",
                        LongDescription = "Instant Anti Age Perfector 4-In-1 Glow is Maybelline's 1st 4-in-1 makeup for a glow look that primes, conceals, highlights, and evens skin tone with light coverage and self-adjusting shades.",
                        Category = Categories["Make Up"],
                        ImageUrl = "https://media.superdrug.com//medias/sys_master/prd-images/hf1/h24/9995563794462/prd-front-820962_600x600/prd-front-820962-600x600.jpg",
                        ImageThumbnailUrl = "https://media.superdrug.com//medias/sys_master/prd-images/hf1/h24/9995563794462/prd-front-820962_600x600/prd-front-820962-600x600.jpg",
                        InStock = true
                    },

                    new Product
                    {
                        Name = "Dove Relaxing Body Wash 225ml",
                        Price = 1.49M,
                        ShortDescription = "Whether first thing in the morning or just before bed, treat yourself to some ‘me time’ with Dove Relaxing Body Wash.",
                        LongDescription = "Whether first thing in the morning or just before bed, treat yourself to some ‘me time’ with Dove Relaxing Body Wash.",
                        ImageUrl = "https://media.superdrug.com//medias/sys_master/prd-images/h5c/h6f/10599543406622/prd-front-780419_600x600/prd-front-780419-600x600.jpg",
                        ImageThumbnailUrl = "https://media.superdrug.com//medias/sys_master/prd-images/h5c/h6f/10599543406622/prd-front-780419_600x600/prd-front-780419-600x600.jpg",
                        Category = Categories["Toiletries"],
                        InStock = true
                    });
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Category>? categories;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genreList = new Category[]
                    {
                        new Category { Name = "Skin Care" },
                        new Category { Name = "Make Up" },
                        new Category { Name = "Toiletries" }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genreList)
                    {
                        categories.Add(genre.Name, genre);
                    }
                }

                return categories;
            }
        }
    }
}
