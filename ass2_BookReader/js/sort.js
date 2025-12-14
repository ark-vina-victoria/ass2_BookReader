document.addEventListener('DOMContentLoaded', function () {
    const sortBy = document.getElementById('sortBy');
    if (sortBy) {
        sortBy.addEventListener('change', function () {
            const form = document.createElement('form');
            form.method = 'get';
            form.action = window.location.pathname;

            const searchTerm = document.getElementById('searchTerm');
            if (searchTerm && searchTerm.value) {
                const searchInput = document.createElement('input');
                searchInput.type = 'hidden';
                searchInput.name = 'searchTerm';
                searchInput.value = searchTerm.value;
                form.appendChild(searchInput);
            }

            const sortInput = document.createElement('input');
            sortInput.type = 'hidden';
            sortInput.name = 'sortBy';
            sortInput.value = this.value;
            form.appendChild(sortInput);

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