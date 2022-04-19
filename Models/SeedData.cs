using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pet_Store_BE.Data;

namespace Pet_Store_BE.Models
{
    public class SeedData
    {
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new Pet_Store_BEContext(serviceProvider.GetRequiredService<DbContextOptions<Pet_Store_BEContext>>()))
            {
                //Check exist info
                if (context.Pet.Any()) { return; }//not add
                context.Pet.AddRange(
                    new Pet
                    {
                        Id = "Cat001",
                        Img = "~/Img/Image/meo-anh-long-ngan/meo-anh-long-ngan-1.jpg",
                        Species = "Mèo anh lông ngắn",
                        Purebred = "Thuần chủng",
                        Origin = "Anh Quốc",
                        Amount = 12,
                        Price = 600
                    },
                    new Pet
                    {
                        Id = "Cat002",
                        Img = "~/Img/Image/meo-anh-long-dai/meo-anh-long-ngan-2.jpg",
                        Species = "Mèo anh lông ngắn",
                        Purebred = "Không thuần chủng",
                        Origin = "Việt Nam",
                        Amount = 12,
                        Price = 250
                    },
                    new Pet
                    {
                        Id = "Dog003",
                        Img = "~/Img/Image/cho-poodle.jpg",
                        Species = "Chó Alaska",
                        Purebred = "Thuần chủng",
                        Origin = "Alaska",
                        Amount = 12,
                        Price = 1500
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
