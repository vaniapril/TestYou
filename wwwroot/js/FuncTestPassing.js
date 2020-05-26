let test;

function Init(id) {
    console.log("POST-GET-TEST");
    $.ajax({
            url: '/TestPassing/Get?id=' + id,
            type: 'GET'
        }
    ).done(function(data) {
        console.log(data);
        test = data;
        let element1 = document.getElementById("title");
        element1.innerHTML = test.title;
        let html = htmlQuestionsList();
        let element = document.getElementById("questions");
        element.innerHTML = html;
    });
}

function htmlQuestionsList() {
    let html = "";
    for(let i = 0; i < test.questions.length; i++) {
        test.questions[i].chozen = test.questions[i].answers[test.questions[i].answers.length - 1].cost;
        html += htmlQuestion(test.questions[i], i);
    }
    return html
}

function htmlQuestion(element, index){
    let html = "";
    html += '<li width="100%" class="list-group-item">';
    html += '<table width="100%" border="0" cellpadding="10">';
    html += "<tr width=\"100%\" align=\"center\"><td width=\"100%\" align=\"center\">";
    html += element.text;
    html += "</td></tr>";
    for (let i = 0; i < element.answers.length; i++){
        html += "<tr align=\"left\"><td>";
        html += '<input lass="radio" type="radio" onclick="AnswerChange(' + index + ',' + element.answers[i].cost + ' )" checked name="'+ element.id +'"/><label class="label">' + element.answers[i].text + '</label>';
        html += "</td></tr>";
    }
    html += "</table></li>";
    return html;
}

function AnswerChange(id, answerCost) {
    test.questions[id].chozen = answerCost;
}

function end() {
    let i = 0;
    test.questions.forEach(e => {
        i += e.chozen;
    });
    let resId;
    test.results.forEach(result => {
       if(result.min <= i && result.max >= i){
           resId = result.id;
       } 
    });
    console.log(resId);
    console.log(i);
    if(resId !== undefined){
        let result = {
            UserId : getUserId(),
            TestId : test.id,
            ResultId : resId
        };
        console.log("POST-CREATE-RESULT");
        $.ajax({
            url: '/TestPassing/Pass',
            type: 'POST',
            dataType: "json",
            data: result,
            success: function (data) {
                document.location.href = "../TestResult/TestResult?testId="+ result.TestId + "&id=" + result.ResultId;
            }
        });
    } else {
        alert("Вы вышли за грань возможного. Ни один результат вам не подходит.")
    }
}

function SignOut() {
    deleteUserId();
    document.location.href = "../Login/Login";
}