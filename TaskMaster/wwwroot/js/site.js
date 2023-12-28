// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


//Admin panel section
$('#changerole').click(function () {
    $('#content').load('/AdminPanel/ChangeRole');
})

$('#removeuser').click(function () {
    $('#content').load('/AdminPanel/RemoveUser');
})
//End of Admin panel section

//Index panel section
$('#login').click(function () {
    $('#content').load('Identity/Account/Login');
})


$('#register').click(function () {
    $('#content').load('Identity/Account/Register');
})
//End of Inxed panel section