// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function showMessage(message, title, icon) {
    Swal.fire({
        icon: icon || "info",
        title: title || "Message",
        text: message,
        //footer: ''
    });
}
function showConfirm(message, title, onOk, OnCancel) {
    Swal.fire({
        icon: messageIcon.question,
        title: title || "Message",
        text: message,
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes"
        //footer: ''
    }).then((result) => {
        if (result.isConfirmed) {
            onOk();
        }
        else {
            OnCancel();
        }
    });

}
var messageIcon = {
    success: "success",
    error: "error",
    warning: 'warning',
    info: 'info',
    question: 'question'
}