using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ass2_BookReader.Models;

namespace ass2_BookReader.Controllers
{
    public class BooksController : Controller
    {
        // 模拟数据库（实际项目可替换为EF Core）
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
                Title = "JavaScript高级程序设计",
                Author = "Nicholas C. Zakas",
                Category = "Web Development",
                Price = 79.00m,
                Description = "深入理解JavaScript语言特性，掌握高级编程技巧，适合中高级开发者提升技术能力。",
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
                CoverImage = "ml_crash.jpg",
                Isbn = "978-5678901234",
                PageCount = 380,
                Language = "English"
            }
        };

        // 图书列表页（支持搜索、排序、分页）
        public ActionResult Index(string searchTerm, string sortBy, int page = 1)
        {
            const int pageSize = 3; // 每页显示3本图书
            var query = _books.AsQueryable();

            // 1. 搜索功能实现
            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.Trim().ToLower();
                query = query.Where(b =>
                    b.Title.ToLower().Contains(searchTerm) ||
                    b.Author.ToLower().Contains(searchTerm) ||
                    b.Category.ToLower().Contains(searchTerm));
            }

            // 2. 排序功能实现
            sortBy = string.IsNullOrEmpty(sortBy) ? "title_asc" : sortBy;
            switch (sortBy)
            {
                case "title_asc":
                    query = query.OrderBy(b => b.Title);
                    break;
                case "title_desc":
                    query = query.OrderByDescending(b => b.Title);
                    break;
                case "price_asc":
                    query = query.OrderBy(b => b.Price);
                    break;
                case "price_desc":
                    query = query.OrderByDescending(b => b.Price);
                    break;
                case "year_desc":
                    query = query.OrderByDescending(b => b.PublishYear);
                    break;
                default:
                    query = query.OrderBy(b => b.Title);
                    break;
            }

            // 3. 分页功能实现
            var totalItems = query.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            page = Math.Max(1, Math.Min(page, totalPages)); // 防止页码越界
            var pagedBooks = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // 封装分页结果
            var model = new PagedResult<Book>
            {
                Items = pagedBooks,
                TotalItems = totalItems,
                CurrentPage = page,
                TotalPages = totalPages,
                PageSize = pageSize
            };

            // 传递搜索词和排序方式到视图（保持状态）
            ViewBag.SearchTerm = searchTerm;
            ViewBag.SortBy = sortBy;

            return View(model);
        }

        // 图书详情页
        public ActionResult Detail(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return HttpNotFound("图书不存在"); // 404页面
            }
            return View(book);
        }

        // 阅读图书（模拟功能）
        public ActionResult Read(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return HttpNotFound("图书不存在");
            }
            ViewBag.BookTitle = book.Title;
            return View(book);
        }
    }
}