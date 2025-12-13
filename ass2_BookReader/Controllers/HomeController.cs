using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ass2_BookReader.Models; // 确保引入模型命名空间

namespace ass2_BookReader.Controllers
{
    public class HomeController : Controller
    {
        // 复用 BooksController 中的图书数据（或单独定义）
        private static readonly List<Book> _books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "C# Basics",
                Author = "John Smith",
                Category = "Programming",
                Price = 45.99m,
                Description = "A comprehensive guide to C# programming for beginners.",
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
                Description = "Learn to build modern web applications with ASP.NET MVC.",
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
                Description = "A Hugo Award-winning science fiction novel.",
                PublishYear = 2015,
                CoverImage = "three_body.jpg",
                Isbn = "978-7302399106",
                PageCount = 302,
                Language = "Chinese"
            }
        };

        // 首页 - 添加推荐图书数据
        public ActionResult Index()
        {
            // 筛选3本推荐图书（可自定义规则，比如最新出版/热门分类）
            var recommendedBooks = _books.Take(3).ToList();
            ViewBag.RecommendedBooks = recommendedBooks; // 关键：给ViewBag赋值
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "关于图书阅读网站";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "联系我们";
            return View();
        }
    }
}