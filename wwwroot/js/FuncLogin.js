function Login() {
    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;
    document.location.href = "../Home/Home";
    console.log("POST-LOGIN");
    $.ajax({
        url:'/Login/LoginPost?login=' + email + '&password=' + password,
        type:'POST',
    });
}