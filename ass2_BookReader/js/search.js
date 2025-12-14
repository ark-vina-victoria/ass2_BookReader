document.addEventListener('DOMContentLoaded', function () {
    const searchForm = document.getElementById('searchForm');
    const searchTerm = document.getElementById('searchTerm');

    if (searchForm && searchTerm) {
        searchTerm.addEventListener('keyup', function (e) {
            if (e.key === 'Enter') {
                searchForm.submit();
            }
        });

        const clearBtn = document.createElement('button');
        clearBtn.type = 'button';
        clearBtn.textContent = '×';
        clearBtn.className = 'clear-btn';
        clearBtn.style.display = searchTerm.value ? 'inline-block' : 'none';
        clearBtn.style.position = 'absolute';
        clearBtn.style.right = '120px';
        clearBtn.style.top = '50%';
        clearBtn.style.transform = 'translateY(-50%)';
        clearBtn.style.background = 'transparent';
        clearBtn.style.border = 'none';
        clearBtn.style.fontSize = '20px';
        clearBtn.style.cursor = 'pointer';
        clearBtn.style.color = var(--text - gray);

        searchForm.style.position = 'relative';
        searchForm.appendChild(clearBtn);

        clearBtn.addEventListener('click', function () {
            searchTerm.value = '';
            clearBtn.style.display = 'none';
        });

        searchTerm.addEventListener('input', function () {
            clearBtn.style.display = this.value ? 'inline-block' : 'none';
        });
    }
});