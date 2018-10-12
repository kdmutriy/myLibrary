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
        public async Task<IActionResult> Index(SortState sortState=SortState.NameBookAsc)
        {
            /*var libs = db.Books.Include(l => l.Lib).ThenInclude(a => a.Author).ToList();
            if (!String.IsNullOrEmpty(name))
                libs = libs.Where(p => EF.Functions.Like(p.NameBook, "%" + name + "%")).ToList();*/
            IQueryable<Book> books = db.Books.Include(b => b.Author);
            ViewData["NameBookSort"] = sortState == SortState.NameBookAsc ? SortState.NameBookDesc : SortState.NameBookAsc;
            ViewData["YearPublish"] = sortState == SortState.YearPublishAsc ? SortState.YearPublishDesc : SortState.YearPublishAsc;
            ViewData["CountPage"] = sortState == SortState.CountPageAsc ? SortState.CountPageDesc : SortState.CountPageAsc;
            ViewData["Author"] = sortState == SortState.AuthorAsc ? SortState.AuthorDesc : SortState.AuthorAsc;
            switch (sortState)
            {
                case SortState.NameBookDesc:
                    books = books.OrderByDescending(s => s.NameBook);
                    break;
                case SortState.YearPublishDesc:
                    books = books.OrderByDescending(s => s.YearPublish);
                    break;
                case SortState.CountPageDesc:
                    books = books.OrderByDescending(s => s.CountPage);
                    break;
                case SortState.AuthorDesc:
                    books = books.OrderByDescending(s => s.Author);
                    break;
                default:
                    books = books.OrderBy(s => s.NameBook);
                    break;
            }
            return View(await books.AsNoTracking().ToListAsync());
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
           
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            
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
