let result;

function Init(id, testId) {
    console.log("POST-GET-TEST");
    $.ajax({
            url: '/TestResult/Get?testId=' + testId + "&id=" + id,
            type: 'GET'
        }
    ).done(function(data) {
        console.log(data);
        let result = data.text;
        let element = document.getElementById("result");
        element.innerHTML += '"' + result + '"';
    });
}

function Home() {
    document.location.href = "../Home/Home";
}

function Comment(id){
    document.location.href = "../Comment/Comment?id=" + id;
}