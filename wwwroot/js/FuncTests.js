function AddTest() {
    console.log("POST");
    $.ajax({
        url:'/Tests/AddTest',
        type:'POST'
    });
}