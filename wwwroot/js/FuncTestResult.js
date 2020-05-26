let result;

function Init(id, testId) {
    console.log("POST-GET-TEST");
    $.ajax({
            url: '/TestResult/Get?testId=' + id + "&id=" + testId,
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