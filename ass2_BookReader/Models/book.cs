using System;

namespace ass2_BookReader.Models
{
    // 自定义图书模型（满足"创建自己的模型类"要求）
    public class Book
    {
        public int Id { get; set; } // 图书ID（主键）
        public string Title { get; set; } // 书名
        public string Author { get; set; } // 作者
        public string Category { get; set; } // 分类
        public decimal Price { get; set; } // 价格
        public string Description { get; set; } // 描述
        public int PublishYear { get; set; } // 出版年份
        public string CoverImage { get; set; } // 封面图片路径
        public string Isbn { get; set; } // ISBN编号
        public int PageCount { get; set; } // 页数
        public string Language { get; set; } // 语言
    }
}