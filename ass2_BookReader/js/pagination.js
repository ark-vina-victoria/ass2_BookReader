// 分页交互增强
document.addEventListener('DOMContentLoaded', function () {
    const paginationLinks = document.querySelectorAll('.pagination .page-link');

    paginationLinks.forEach(link => {
        // 为分页链接添加悬停效果
        link.addEventListener('mouseover', function () {
            this.style.transform = 'scale(1.1)';
        });

        link.addEventListener('mouseout', function () {
            this.style.transform = 'scale(1)';
        });

        // 禁用的分页链接移除点击事件
        if (link.parentElement.classList.contains('disabled')) {
            link.addEventListener('click', function (e) {
                e.preventDefault();
            });
        }
    });
});