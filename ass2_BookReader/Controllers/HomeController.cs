using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ass2_BookReader.Models;

namespace ass2_BookReader.Controllers
{
    /// <summary>
    /// Controller for handling home page, about page and contact page operations
    /// </summary>
    public class HomeController : Controller
    {
        // In-memory book data for recommended books on home page
        // (In production, this should be shared with BooksController or retrieved from a shared data source)
        private static readonly List<Book> _books = new List<Book>
        {
            new Book
            {
                Id = 9,
                Title = "The Three-Body Problem",
                Author = "Liu Cixin",
                Category = "Science Fiction",
                Price = 29.80m,
                Description = "Earth civilization sent a mysterious signal to the universe, which triggered a thrilling first contact between human civilization and the Trisolaran civilization.",
                PublishYear = 2008,
                CoverImage = "three_body_chn.jpg",
                Isbn = "978-7536692930",
                PageCount = 302,
                Language = "Chinese"
            },
            new Book
            {
                Id = 10,
                Title = "Sapiens: A Brief History of Humankind",
                Author = "Yuval Noah Harari",
                Category = "History",
                Price = 68.00m,
                Description = "It tells how humans evolved from an insignificant ape to become the dominant species on Earth, exploring the impact of the Cognitive Revolution, Agricultural Revolution, and Scientific Revolution on human history.",
                PublishYear = 2014,
                CoverImage = "sapiens.jpg",
                Isbn = "978-7508647357",
                PageCount = 452,
                Language = "Chinese"
            },
            new Book
            {
                Id = 11,
                Title = "Sapiens: A Brief History of Humankind",
                Author = "Yuval Noah Harari",
                Category = "History",
                Price = 19.99m,
                Description = "Explores how Homo sapiens evolved from an insignificant ape to become the dominant species on Earth.",
                PublishYear = 2011,
                CoverImage = "sapiens_en.jpg",
                Isbn = "978-0062316097",
                PageCount = 440,
                Language = "English"
            }
        };

        /// <summary>
        /// Displays the home page with recommended books
        /// </summary>
        /// <returns>Home page view with recommended books in ViewBag</returns>
        public ActionResult Index()
        {
            // Get first 3 books as recommended books for home page
            var recommendedBooks = _books.Take(3).ToList();
            ViewBag.RecommendedBooks = recommendedBooks;
            return View();
        }

        /// <summary>
        /// Displays the about page of the book reading website
        /// </summary>
        /// <returns>About page view with page title in ViewBag</returns>
        public ActionResult About()
        {
            // Update ViewBag message to English (replace Chinese text)
            ViewBag.Message = "About the Book Reading Website";
            return View();
        }

        /// <summary>
        /// Displays the contact page with contact information and message form
        /// </summary>
        /// <returns>Contact page view with page title in ViewBag</returns>
        public ActionResult Contact()
        {
            // Update ViewBag message to English (replace Chinese text)
            ViewBag.Message = "Contact Us";
            return View();
        }
    }
}