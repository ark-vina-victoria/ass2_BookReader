using System.Collections.Generic;

namespace ass2_BookReader.Models
{
    // 分页结果模型（支持分页功能实现）
    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; set; } // 当前页数据
        public int TotalItems { get; set; } // 总数据量
        public int CurrentPage { get; set; } // 当前页码
        public int TotalPages { get; set; } // 总页数
        public int PageSize { get; set; } // 每页条数
    }
}