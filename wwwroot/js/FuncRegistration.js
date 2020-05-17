function CreateAccount (){
    console.log("POST-CREATE-USER");
    var password1 = document.getElementById("password1").value;
    var password2 = document.getElementById("password2").value;
    var Login = document.getElementById("email").value;
    document.location.href = "../Home/Home";
    /*if (password1 ==null || password2 ==null){
        alert()
    }
    if(password1 != password2 || password1 == "" || password2 == "" || Login == ""){
       alert("Passwords or Email are not equeal  or unvalid");
    }else {
       */ 
        //пароль совпадает а это значит тут уже надо проверить нет ли пользователя с таким же логином и как бы опять идет связь с базой данных и т.д.
    //}
}