document.addEventListener('DOMContentLoaded', function () {
    const paginationLinks = document.querySelectorAll('.pagination .page-link');

    paginationLinks.forEach(link => {

        link.addEventListener('mouseover', function () {
            this.style.transform = 'scale(1.1)';
        });

        link.addEventListener('mouseout', function () {
            this.style.transform = 'scale(1)';
        });

        if (link.parentElement.classList.contains('disabled')) {
            link.addEventListener('click', function (e) {
                e.preventDefault();
            });
        }
    });
});