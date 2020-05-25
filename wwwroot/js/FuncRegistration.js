function CreateAccount (){
    console.log("POST-CREATE-USER");
    var password1 = document.getElementById("password1").value;
    var password2 = document.getElementById("password2").value;
    var login = document.getElementById("email1").value;
    if (password1 !== "" && password2 !== "" && login !== ""){
        if(password1 === password2) {
            $.ajax({
                url: '/Registration/Register?login=' + login + '&password=' + password1,
                type: 'POST',
                success: function (response) {
                    console.log(response)
                },
                error: function (jqXHR, exp) {
                    switch (jqXHR.status) {
                        case 404:
                            alert("Такой пользователь уже соществует");
                            break;
                    }
                }
            }).done(data => {
                setUserId(data);
                document.location.href = "../Home/Home";
            });
        } else {
            alert("Пароли не совпадают")
        }
    } else {
        alert("Заполните поля");
    }
}