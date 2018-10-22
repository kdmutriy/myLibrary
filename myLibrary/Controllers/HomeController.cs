using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myLibrary.Models;
using myLibrary.Repository;
using myLibrary.ViewModel;

namespace myLibrary.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork unitOfWork;
        public HomeController(LibraryContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }
        public IActionResult Index()
        {
            IEnumerable<Book> book = unitOfWork.Books.GetAll();
           
            return View(book);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            unitOfWork.Books.Create(book);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Book lib)
        {
            return View();
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
