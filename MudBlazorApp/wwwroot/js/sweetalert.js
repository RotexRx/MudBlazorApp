window.SwalHelper = {
    ShowSuccess: function (title, text) {
        Swal.fire({
            icon: 'success',
            title: title,
            text: text
        });
    },
    ShowError: function (title, text) {
        Swal.fire({
            icon: 'error',
            title: title,
            text: text
        });
    },
    ShowConfirm: function (title, text, dotNetHelper) {
        Swal.fire({
            title: title,
            text: text,
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Yes',
            cancelButtonText: 'Cancel'
        }).then((result) => {
            if (result.isConfirmed) {
                dotNetHelper.invokeMethodAsync("OnConfirm");
            }
        });
    }
};
