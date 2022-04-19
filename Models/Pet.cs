using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pet_Store_BE.Models
{
    public class Pet
    {   
       
        public string Id { get; set; }
        [Display(Name = "Hình ảnh")]
        public string Img { get; set; }

        [Display(Name = "Chủng loại")]
        public string Species { get; set; }

        [Display(Name = "Thuần chủng")]
        public string Purebred { get; set; }

        [Display(Name = "Xuất xứ")]
        public string Origin { get; set; }

        [Display(Name = "Số lượng")]
        public int Amount { get; set; }

        [Display(Name = "Giá cả")]
        [Column(TypeName = "decimal(10, 1)")]
        public decimal Price { get; set; }
    }
}
