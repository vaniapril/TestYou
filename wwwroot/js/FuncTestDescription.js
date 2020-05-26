function Back(){
    history.back();
}

function Pass(id) {
    document.location.href = "../TestPassing/TestPassing?id=" + id;
}

let comments;
let users;

function Init(id) {
    console.log("POST-GET-TEST");
    $.ajax({
            url: '/TestDescription/Get?id=' + id,
            type: 'GET'
        }
    ).done(function(data) {
        console.log(data);
        comments = data.comments;
        $.ajax({
                url: '/TestDescription/GetUsers',
                type: 'GET'
            }
        ).done(function(data) {
            console.log(data);
            users = data;
            let html = htmlCommentList();
            let element = document.getElementById("Comments");
            element.innerHTML = html;
        });
    });
}

function htmlCommentList() {
    let html = "";
    comments.forEach(comment => {
        html += "<li width='100%' class='list-group-item'> ";
        html += "<table width='100%'>";
        html += "<tr width='100%'>";
        html += "<td width='100%'>";
            users.forEach(user => {
            if(user.id === comment.userId){
                html += user.login;
            }
        });
        html += "</td><td></td>";
        html += "</tr>";

        html += "<tr>";
        html += "<td>" + comment.text + "</td>";
        html += "<td align=\"right\">";
        
        if(comment.isLike){
            html += "<i class='far fa-thumbs-up' style='font-size:20px;width: 50px;'></i>";
        } else {
            html += "<i class='far fa-thumbs-down' style='font-size:20px;width: 50px;'></i>";
        }
        
        html += "</td>";
        html += "</tr>";

        html += "</table>";
        html += "</li>"; 
    });
    return html;
}