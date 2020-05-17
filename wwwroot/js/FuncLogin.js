function Login() {
    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;
    console.log("POST-LOGIN");
    $.ajax({
        url:'/Login/LoginPost?login=' + email + '&password=' + password,
        type:'POST',
    });
}