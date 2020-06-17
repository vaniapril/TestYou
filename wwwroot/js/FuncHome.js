function Init() {
    console.log("POST-GET-TEST");
    $.ajax({
            url: '/Home/GetTests',
            type: 'GET'
        }
    ).done(function(data) {
        console.log(data);
        let html = htmlTestList(data);
        let element = document.getElementById("Tests");
        element.innerHTML = html;
    });
}

function htmlTestList(data) {
    let html = "";
    data.forEach(test => {
        html += "<li onclick='Description(" + test.id +")' class=\"list-group-item\" width='100%'>";
        html += "<table width='100%'><tr>";
        html += "<td style=\"width: 20%;\"><p class='TestTitle'>" + test.title + "</p></td>";
        html += "<td style=\"width: 60%;\"><p class='TestDescription'>" + test.description + "</p></td>";
        html += "<td  align='right' style=\"width: 20%;\"><p class='TestDescription'>";
        let like = 0;
        let dislike = 0;
        test.comments.forEach(comment => {
            if(comment.isLike){
                like++;
            } else {
                dislike++;
            }
        });
        html += "<i class='far fa-thumbs-up' style='font-size:20px;width: 50px;'>"+like+"</i>";
        html += "<i class='far fa-thumbs-down' style='font-size:20px;width: 50px;'>"+dislike+"</i>";
        
        html += "</p></td>";
        html += "</tr></table>";
        html +=  "</li>";
    });
    
    return html
}

function Description(id) {
    document.location.href = "../TestDescription/TestDescription?id=" + id;
}