function deleteItem(itemId) {
            if (confirm('Are you sure you want to delete this item?')) {
                fetch(`/delete/${itemId}`, {
                    method: 'DELETE',
                }).then(response => {
                    if (!response.ok) {
                        window.location.reload();
                    }
                });
            }
        }
