using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pet_Store_BE.Models
{
    public class PetPureViewModel
    {
        public List<Pet>? Pets { get; set; }
        public SelectList? Purebred { get; set; }
        public string? PetPure { get; set; }
        public string? s { set; get; }
    }
}
