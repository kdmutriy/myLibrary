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
            var libs = db.Books.Include(l => l.Lib).ThenInclude(a => a.Author).ToList();
            if (!String.IsNullOrEmpty(name))
                libs = libs.Where(p => EF.Functions.Like(p.NameBook, "%" + name + "%")).ToList();
            return View(libs);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IndexViewModel lib)
        {
            db.Books.Add(lib.Books);
            db.Authors.Add(lib.Authors);
            db.SaveChanges();
            lib.Books.Lib.Add(new Lib { BookId = lib.Authors.Id, AuthorId = lib.Books.Id });

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                var libs = db.Books.Include(l => l.Lib).ThenInclude(a => a.Author).FirstOrDefault(b => b.Id == id);
                if (libs != null)
                    return View(libs);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Book lib)
        {
            db.Entry(lib).State = EntityState.Modified;
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
