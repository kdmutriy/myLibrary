using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myLibrary.Models;
using myLibrary.ViewModel;

namespace myLibrary.Controllers
{
    public class HomeController : Controller
    {
        private LibraryContext db;
        public HomeController(LibraryContext context)
        {
            db = context;
        }
        public IActionResult Index(string name)
        {
            IQueryable<Lib> libs = db.Libs.Include(a => a.Author).Include(b => b.Book);
           if (!String.IsNullOrEmpty(name))
                libs = libs.Where(p => EF.Functions.Like(p.Book.NameBook,"%"+name+"%"));
            //var lib = db.Libs.Include(a => a.Author).Include(b => b.Book).ToList();     
           
            return View(libs);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Lib library)
        {
            db.Libs.Add(library);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                Lib library = db.Libs.Include(a => a.Author).Include(b => b.Book).FirstOrDefault(b=>b.BookId==id);
              
                if (library != null)
                    return View(library);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Lib lib)
        {
            db.Libs.Update(lib);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
