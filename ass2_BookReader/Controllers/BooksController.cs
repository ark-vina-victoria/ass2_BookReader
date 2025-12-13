using ass2_BookReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ass2_BookReader.Controllers
{
    public class BooksController : Controller
    {
        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "C# Basics", Author = "John Smith", Category = "Tech", Price = 45, Description = "Introduction to C#" },
            new Book { Id = 2, Title = "ASP.NET MVC", Author = "Jane Brown", Category = "Tech", Price = 55, Description = "Web development with ASP.NET" },
            new Book { Id = 3, Title = "The Three-Body Problem", Author = "Liu Cixin", Category = "Novel", Price = 60, Description = "Science fiction novel" }
        };

        public ActionResult Index(string search, string category, string sort, int page = 1)
        {
            int pageSize = 2;
            var result = books.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                result = result.Where(b => b.Title.Contains(search));

            if (!string.IsNullOrEmpty(category))
                result = result.Where(b => b.Category == category);

            if (sort == "price")
                result = result.OrderBy(b => b.Price);

            var pagedBooks = result
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.TotalPages = Math.Ceiling(result.Count() / (double)pageSize);
            ViewBag.CurrentPage = page;

            return View(pagedBooks);
        }

        public ActionResult Details(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            return View(book);
        }
    }
}