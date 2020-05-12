function Login() {
    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;
    console.log("POST");
    $.ajax({
        url:'/Login/LoginPost',
        type:'POST'
    });
}