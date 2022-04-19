using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Store_BE.Controllers
{
    public class DanhMucController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cho()
        {
            return NoContent();
        }
        public IActionResult Meo()
        {
            return NoContent();
        }
    }
}
