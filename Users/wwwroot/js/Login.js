$(document).ready(function () {
    $('#btnSubmit').click(function (e) {
        Login();
    });
})

function Login() {
    var obj = new Object();

    obj.email = $("#email").val();
    obj.password = $("#password").val();

    console.log(obj);
}