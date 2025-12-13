// 排序下拉框变化时保持搜索状态
document.addEventListener('DOMContentLoaded', function () {
    const sortBy = document.getElementById('sortBy');
    if (sortBy) {
        // 为排序下拉框添加表单提交事件
        sortBy.addEventListener('change', function () {
            const form = document.createElement('form');
            form.method = 'get';
            form.action = window.location.pathname;

            // 添加搜索词参数
            const searchTerm = document.getElementById('searchTerm');
            if (searchTerm && searchTerm.value) {
                const searchInput = document.createElement('input');
                searchInput.type = 'hidden';
                searchInput.name = 'searchTerm';
                searchInput.value = searchTerm.value;
                form.appendChild(searchInput);
            }

            // 添加排序参数
            const sortInput = document.createElement('input');
            sortInput.type = 'hidden';
            sortInput.name = 'sortBy';
            sortInput.value = this.value;
            form.appendChild(sortInput);

            // 添加页码参数（回到第一页）
            const pageInput = document.createElement('input');
            pageInput.type = 'hidden';
            pageInput.name = 'page';
            pageInput.value = 1;
            form.appendChild(pageInput);

            document.body.appendChild(form);
            form.submit();
        });
    }
});