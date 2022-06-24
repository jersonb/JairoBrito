// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('.toast-possition').show();

setTimeout(close, 10000);

$('.btn-close').click(close);

function close() {
    $('.toast-possition').hide();
}