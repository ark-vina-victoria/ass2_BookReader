using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ass2_BookReader.Models;

namespace ass2_BookReader.Controllers
{
    /// <summary>
    /// Controller for handling book-related operations including listing, detail view, and reading functionality
    /// </summary>
    public class BooksController : Controller
    {
        // In-memory book database (simulates a real database like SQL Server/EF Core)
        private static readonly List<Book> _books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "C# Basics",
                Author = "John Smith",
                Category = "Programming",
                Price = 45.99m,
                Description = "A comprehensive guide to C# programming for beginners. Covers all core concepts with practical examples.",
                PublishYear = 2022,
                CoverImage = "csharp_basics.jpg",
                Isbn = "978-1234567890",
                PageCount = 320,
                Language = "English"
            },
            new Book
            {
                Id = 2,
                Title = "ASP.NET MVC Fundamentals",
                Author = "Jane Brown",
                Category = "Web Development",
                Price = 55.50m,
                Description = "Learn to build modern web applications with ASP.NET MVC. Includes routing, controllers, views, and data access.",
                PublishYear = 2023,
                CoverImage = "aspnet_mvc.jpg",
                Isbn = "978-0987654321",
                PageCount = 410,
                Language = "English"
            },
            new Book
            {
                Id = 3,
                Title = "The Three-Body Problem",
                Author = "Liu Cixin",
                Category = "Science Fiction",
                Price = 39.99m,
                Description = "A Hugo Award-winning science fiction novel that explores humanity's first contact with an alien civilization.",
                PublishYear = 2015,
                CoverImage = "three_body.jpg",
                Isbn = "978-7302399106",
                PageCount = 302,
                Language = "Chinese"
            },
            new Book
            {
                Id = 4,
                Title = "Python for Data Science",
                Author = "Michael Lee",
                Category = "Data Science",
                Price = 59.99m,
                Description = "Master Python for data analysis, machine learning, and visualization with real-world datasets.",
                PublishYear = 2021,
                CoverImage = "python_ds.jpg",
                Isbn = "978-1122334455",
                PageCount = 450,
                Language = "English"
            },
            new Book
            {
                Id = 5,
                Title = "Professional JavaScript for Web Developers",
                Author = "Nicholas C. Zakas",
                Category = "Web Development",
                Price = 79.00m,
                Description = "Deeply understand JavaScript language features, master advanced programming skills, suitable for intermediate and advanced developers to improve their technical abilities.",
                PublishYear = 2020,
                CoverImage = "js_advanced.jpg",
                Isbn = "978-7115545381",
                PageCount = 685,
                Language = "Chinese"
            },
            new Book
            {
                Id = 6,
                Title = "Machine Learning Crash Course",
                Author = "Google AI Team",
                Category = "Artificial Intelligence",
                Price = 49.99m,
                Description = "A beginner-friendly introduction to machine learning concepts with hands-on exercises using TensorFlow.",
                PublishYear = 2022,
                CoverImage = "ml_crash.png",
                Isbn = "978-5678901234",
                PageCount = 380,
                Language = "English"
            },
            new Book
            {
                Id = 7,
                Title = "To Kill a Mockingbird",
                Author = "Harper Lee",
                Category = "Fiction",
                Price = 15.99m,
                Description = "A timeless novel about racial injustice and loss of innocence in the American South.",
                PublishYear = 1960,
                CoverImage = "mockingbird.jpg",
                Isbn = "978-0061120084",
                PageCount = 336,
                Language = "English"
            },
            new Book
            {
                Id = 8,
                Title = "1984",
                Author = "George Orwell",
                Category = "Dystopian",
                Price = 12.99m,
                Description = "A classic dystopian novel depicting a totalitarian regime and the dangers of government surveillance.",
                PublishYear = 1949,
                CoverImage = "1984.jpg",
                Isbn = "978-0451524935",
                PageCount = 328,
                Language = "English"
            },
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
        /// Displays paginated, searchable and sortable book list
        /// </summary>
        /// <param name="searchTerm">Search keyword (title/author/category)</param>
        /// <param name="sortBy">Sorting criteria (title_asc/title_desc/price_asc/price_desc/year_desc)</param>
        /// <param name="page">Current page number (default: 1)</param>
        /// <returns>Book list view with pagination model</returns>
        public ActionResult Index(string searchTerm, string sortBy, int page = 1)
        {
            const int pageSize = 3; // Number of books displayed per page
            var query = _books.AsQueryable();

            // Apply search filter if search term is provided
            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.Trim().ToLower();
                query = query.Where(b =>
                    b.Title.ToLower().Contains(searchTerm) ||
                    b.Author.ToLower().Contains(searchTerm) ||
                    b.Category.ToLower().Contains(searchTerm));
            }

            // Set default sorting if no sort criteria is specified
            sortBy = string.IsNullOrEmpty(sortBy) ? "title_asc" : sortBy;
            switch (sortBy)
            {
                case "title_asc":
                    query = query.OrderBy(b => b.Title); // Sort by title ascending
                    break;
                case "title_desc":
                    query = query.OrderByDescending(b => b.Title); // Sort by title descending
                    break;
                case "price_asc":
                    query = query.OrderBy(b => b.Price); // Sort by price ascending
                    break;
                case "price_desc":
                    query = query.OrderByDescending(b => b.Price); // Sort by price descending
                    break;
                case "year_desc":
                    query = query.OrderByDescending(b => b.PublishYear); // Sort by publication year newest first
                    break;
                default:
                    query = query.OrderBy(b => b.Title); // Default sort by title ascending
                    break;
            }

            // Calculate pagination parameters
            var totalItems = query.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            // Ensure page number is within valid range
            page = Math.Max(1, Math.Min(page, totalPages));

            // Get paginated books
            var pagedBooks = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // Create pagination model
            var model = new PagedResult<Book>
            {
                Items = pagedBooks,
                TotalItems = totalItems,
                CurrentPage = page,
                TotalPages = totalPages,
                PageSize = pageSize
            };

            // Pass search and sort parameters to view
            ViewBag.SearchTerm = searchTerm;
            ViewBag.SortBy = sortBy;

            return View(model);
        }

        /// <summary>
        /// Displays detailed information for a specific book
        /// </summary>
        /// <param name="id">Book ID</param>
        /// <returns>Book detail view or 404 if book not found</returns>
        public ActionResult Detail(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return HttpNotFound("Book not found"); // Replace Chinese error message with English
            }
            return View(book);
        }

        /// <summary>
        /// Displays reading interface for a specific book
        /// </summary>
        /// <param name="id">Book ID</param>
        /// <returns>Book reading view or 404 if book not found</returns>
        public ActionResult Read(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return HttpNotFound("Book not found"); // Replace Chinese error message with English
            }
            ViewBag.BookTitle = book.Title;
            return View(book);
        }
    }
}