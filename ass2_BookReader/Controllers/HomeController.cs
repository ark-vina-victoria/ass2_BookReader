using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ass2_BookReader.Models;

namespace ass2_BookReader.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<Book> _books = new List<Book>
        {
            new Book
    {
        Id = 9,
        Title = "三体",
        Author = "刘慈欣",
        Category = "科幻",
        Price = 29.80m,
        Description = "地球文明向宇宙发出了神秘信号，由此引发了一场人类文明和三体文明的惊心动魄的第一次接触。",
        PublishYear = 2008,
        CoverImage = "three_body_chn.jpg",
        Isbn = "978-7536692930",
        PageCount = 302,
        Language = "Chinese"
    },
    new Book
    {
        Id = 10,
        Title = "人类简史：从动物到上帝",
        Author = "尤瓦尔·赫拉利",
        Category = "历史",
        Price = 68.00m,
        Description = "讲述了人类如何从一个普通的非洲灵长类动物，一步步成为地球的主宰，探讨了认知革命、农业革命、科学革命对人类历史的影响。",
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

        public ActionResult Index()
        {
            var recommendedBooks = _books.Take(3).ToList();
            ViewBag.RecommendedBooks = recommendedBooks;
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