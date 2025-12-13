// 搜索表单提交处理
document.addEventListener('DOMContentLoaded', function () {
    const searchForm = document.getElementById('searchForm');
    const searchTerm = document.getElementById('searchTerm');

    if (searchForm && searchTerm) {
        // 按下Enter键提交表单
        searchTerm.addEventListener('keyup', function (e) {
            if (e.key === 'Enter') {
                searchForm.submit();
            }
        });

        // 搜索词清除功能
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

        // 清除搜索词
        clearBtn.addEventListener('click', function () {
            searchTerm.value = '';
            clearBtn.style.display = 'none';
        });

        // 输入时显示清除按钮
        searchTerm.addEventListener('input', function () {
            clearBtn.style.display = this.value ? 'inline-block' : 'none';
        });
    }
});