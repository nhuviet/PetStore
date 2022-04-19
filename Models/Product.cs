using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Store_BE.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Hình ảnh")]
        public byte Image { get; set; }

        [Display(Name = "Tên hàng")]
        public string Name { get; set; }

        [Display(Name = "Loại")]
        public string Type { get; set; }

        [Display(Name = "Số lượng")]
        public int Stock { get; set; }

        [Display(Name = "Giá cả")]
        public decimal Price { get; set; }




    }
}
