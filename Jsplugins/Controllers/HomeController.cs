using Jsplugins.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Jsplugins.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.data = new SelectList( Tree.GetData().Where(x => x.ParentId == null),"Id","Name");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult LoadTree(int id)
        {
            return Json(Tree.GetData().Where(x=>x.ParentId==id));
        }
    }
   public class Tree
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public string CodeType { get; set; }

        public static List<Tree> GetData()
        {
            return new List<Tree>
            {
                new Tree{ Id =1, Name="Sciense" , ParentId=null },
                new Tree{ Id =6, Name="Sciense 6" , ParentId=null },
                new Tree{ Id =2, Name="Sciense 2" , ParentId=1 },
                new Tree{ Id =3, Name="Sciense 3" , ParentId=1 },
                new Tree{ Id =4, Name="Sciense 2-2" , ParentId=2 },
                new Tree{ Id =5, Name="Sciense 3-3" , ParentId=3 },
                new Tree{ Id =7, Name="Sciense 6-7" , ParentId=6 },
                 new Tree{ Id =8, Name="Sciense 5-8" , ParentId=5  },
                 new Tree{ Id =9, Name="Sciense 8-9" , ParentId=8,CodeType="SUB" },

            };
        }
    }
}
