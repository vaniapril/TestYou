function AddTest() {
    console.log("POST-ADD-TEST");
    $.ajax({
        url:'/Tests/AddTest',
        type:'POST'
    });
}