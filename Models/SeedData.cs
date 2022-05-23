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
                        Id = "C001",
                        Img = "https://petmaster.vn/petroom/wp-content/uploads/2020/04/meo-anh-1.jpg",
                        Species = "Mèo anh lông ngắn",
                        Purebred = "Thuần chủng",
                        Origin = "Anh Quốc",
                        Amount = 12,
                        Price = 600
                    },
                    new Pet
                    {
                        Id = "C002",
                        Img = "https://image-us.eva.vn/upload/4-2020/images/2020-10-12/1602497338-38-thumbnail-width640height480.jpg",
                        Species = "Mèo anh lông dài",
                        Purebred = "Không thuần chủng",
                        Origin = "Việt Nam",
                        Amount = 12,
                        Price = 250
                    },
                    new Pet
                    {
                        Id = "C003",
                        Img = "https://traichomeo.com/wp-content/uploads/2022/02/meo-ba-tu-7.jpg",
                        Species = "Mèo ba tư",
                        Purebred = "Không thuần chủng",
                        Origin = "Việt Nam",
                        Amount = 3,
                        Price = 250
                    },
                    new Pet
                    {
                        Id = "D001",
                        Img = "https://image-us.eva.vn/upload/3-2021/images/2021-09-10/image6-1631238960-626-width650height490.jpg",
                        Species = "Chó Husky",
                        Purebred = "Không thuần chủng",
                        Origin = "Việt Nam",
                        Amount = 8,
                        Price = 250
                    },
                    new Pet
                    {
                        Id = "D002",
                        Img = "https://petviet.vn/wp-content/uploads/2018/04/hinh-anh-cho-toy-poodle-07-600x521.jpg",
                        Species = "Chó Poodle",
                        Purebred = "Thuần chủng",
                        Origin = "Pháp",
                        Amount = 12,
                        Price = 1500
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
