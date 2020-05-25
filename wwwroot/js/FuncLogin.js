function Init() {
    console.log(getUserId());
    if(getUserId() !== ""){
        document.location.href = "../Home/Home";
    }
}

function Login() {
    var login = document.getElementById("email1").value;
    var password = document.getElementById("password").value;
    if(login !== "" && password !== ""){
        console.log("POST-LOGIN");
        $.ajax({
            url:'/Login/SignIn?login=' + login + '&password=' + password,
            type:'POST',
            error: function (jqXHR, exp) {
                switch (jqXHR.status) {
                    case 401:
                        alert("Пользователь не найден");
                        break;
                    case 409:
                        alert("Неверный пароль");
                        break;
                }
            }
        }).done(data =>{
            setUserId(data);
            document.location.href = "../Home/Home";
        });
    } else {
        alert("Заполниет поля");
    }
}