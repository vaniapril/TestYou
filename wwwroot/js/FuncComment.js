function Init(testId) {
    console.log("POST-GET-TEST");
    $.ajax({
            url: '/Comment/Get?id=' + testId,
            type: 'GET'
        }
    ).done(function(data) {
        console.log(data);
        let element = document.getElementById("title");
        element.innerHTML += ' "' + data.title + '"';
    });
    redrawLike();
}

let isLike = true;

function Comment(testId){
    let comment = {
      UserId : getUserId(),
      TestId : testId,
      isLike : isLike
    };
    let text = document.getElementById("comment").value;
    if(text === undefined){
        text = "";
    }
    comment.Text = text;
    console.log("POST-ADD-COMMENT ");
    console.log(comment);
    
    $.ajax({
        url: '/Comment/Add',
        type: 'POST',
        dataType: "json",
        data: comment,
        success: function (data) {
            Back();
        }
    });
}

function redrawLike() {
    let html = "";
    if(isLike){
        html += "<i class='far fa-thumbs-up' onclick='SetLike(" + true + ")' style='font-size:50px;width: 50px;color:#0f0;'></i>";
        html += "<i class='far fa-thumbs-down' onclick='SetLike(" + false + ")' style='font-size:30px;width: 50px;'></i>";
    } else {
        html += "<i class='far fa-thumbs-up'  onclick='SetLike(" + true + ")' style='font-size:30px;width: 50px;'></i>";
        html += "<i class='far fa-thumbs-down' onclick='SetLike(" + false + ")' style='font-size:50px;width: 50px;color:#f00;'></i>";
    }
    let element = document.getElementById("like");
    element.innerHTML = html;
}

function SetLike(state) {
    isLike = state;
    console.log(state);
    redrawLike();
}

function Back() {
    history.back();
}