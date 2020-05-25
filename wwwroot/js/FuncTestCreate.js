function CreateTest() {
    test.UserId = getUserId();
    console.log("POST-CREATE-TEST");
    if(isError()) {
        $.ajax({
                url: '/TestCreate/Create',
                type: 'POST',
                dataType: "json",
                data: test
            }
        );
        document.location.href = "../Home/Home";
    } else {
        alert("Заполните все поля.")
    }
}
function isError() {
    let noError = true;
    if(test.Title === ""){
        noError = false;
    }
    if(test.Description === ""){
        noError = false;
    }
    test.Results.forEach(item => {
        if(item.Text === ""){
            noError = false;
        }
    });
    test.Questions.forEach(item => {
        if(item.Text === ""){
            noError = false;
        }
        item.Answers.forEach(item => {
            if(item.Text === ""){
                noError = false;
            }
        });
    });
    return noError;
}
function Back(){
    history.back();
}

let test = {
    Title : "",
    Description : "",
    Questions  : [
        {
            Text : "",
            Answers : [
                {
                    Text : "",
                    Cost : 1
                },
                {
                    Text : "",
                    Cost : 0
                }
            ]
        }
    ],
    Results : [
        {
            Text : "",
            Min : 1,
            Max : 1
        }
    ],
    Comments : []
};
    
function Init() {
    console.log("CREATE-TEST-INIT");
    RedrawTitle();
    RedrawDescription();
    RedrawQuestions();
    RedrawResults();
}

function RedrawTitle() {
    let html = "<input class=\"Inp\" placeholder=\"Название\" oninput=\"onTitleChange(this.value)\" value=\""+ test.Title +"\">";
    let element = document.getElementById("Title");
    element.innerHTML = html;
}
function RedrawDescription() {
    let html = "<input class=\"Inp\" placeholder=\"Описание\" oninput=\"onDescriptionChange(this.value)\" value=\"" + test.Description + "\">";
    let element = document.getElementById("Description");
    element.innerHTML = html;
}
function RedrawQuestions() {
    let html = "";
    for(let i = 0; i < test.Questions.length; i++){
        html += htmlQuestion(test.Questions[i], i);
    }
    let element = document.getElementById("Questions");
    element.innerHTML = html;
}
function RedrawResults()    {
    let html = "";
    for(let i = 0; i < test.Results.length; i++){
        html += htmlResult(test.Results[i], i);
    }
    let element = document.getElementById("Results");
    element.innerHTML = html;
}

function htmlQuestion(element, index) {
    let html = '';
    html += '<li class="list-group-item">';
    html += '<table border="0" cellpadding="10">';
    html += "<tr align=\"top\"><td align=\"right\">Текст:</td><td align=\"left\">";
    html += '<input class="Inp" placeholder="Текст" oninput="questionTextChange(+ ' + index + ', this.value)" value=\"' + element.Text + '\">';
    html += "</td></tr>";
    html += "<tr align=\"top\"><td align=\"right\">Ответы:</td><td align=\"left\">";
    for (let i = 0; i < element.Answers.length; i++){
        html += '<input class="InpAnsw" placeholder="Ответ" oninput="answerTextChange( + ' + index + ',' + i + ', this.value)" value=\"' + element.Answers[i].Text + '\">';
        html += '<label class="label">Стоимость:</label>';
        html += '<input type="button" class="roundedButton" value="-" onclick="costDec( + ' + index + ',' + i + ')">';
        html += '<label class="label">' + element.Answers[i].Cost + '</label>';
        html += ' <input type="button" class="roundedButton" value="+" onclick="costInc( + ' + index + ',' + i + ')">';
    }
    html += "</td></tr>";
    html += "<tr><td></td><td><input type='button' class='new' value='Новый' onclick='addAnswer(" + index + ")'></td></td>";
    html += "</table>";
    html += '</li>';
    return html;
}

function htmlResult(element, index) {
    let html = '';
    html += '<li class="list-group-item">';
    html += '<table border="0" cellpadding="10">';
    html += "<tr align=\"top\"><td align=\"right\">Текст:</td><td align=\"left\">";
    html += '<input class="Inp" placeholder="Текст" oninput="resultTextChange(+ ' + index + ', this.value)" value=\"' + element.Text + '\">';
    html += "</td></tr>";
    html += "<tr align=\"top\"><td align=\"right\">Интервал:</td><td align=\"left\">";

    html += '<label class="label">Min:</label>';
    html += '<input type="button" class="roundedButton" value="-" onclick="minDec( + ' + index + ')">';
    html += '<label class="label">' + element.Min + '</label>';
    html += ' <input type="button" class="roundedButton" value="+" onclick="minInc( + ' + index + ')">';

    html += '<label class="label">Max:</label>';
    html += '<input type="button" class="roundedButton" value="-" onclick="maxDec( + ' + index + ')">';
    html += '<label class="label">' + element.Max + '</label>';
    html += ' <input type="button" class="roundedButton" value="+" onclick="maxInc( + ' + index + ')">';
    
    html += "</td></tr>";
    html += "</table>"; 
    html += '</li>';
    return html;
}

function costInc(questionId, id) {
    test.Questions[questionId].Answers[id].Cost += 1;
    RedrawQuestions();
}
function costDec(questionId, id) {
    if(test.Questions[questionId].Answers[id].Cost > 0){
        test.Questions[questionId].Answers[id].Cost -= 1;
    }
    RedrawQuestions();
}
function onTitleChange(text) {
    test.Title = text;
}
function onDescriptionChange(text) {
    test.Description = text;
}
function questionTextChange(id, text) {
    test.Questions[id].Text = text;
}
function resultTextChange(id, text) {
    test.Results[id].Text = text;
}
function answerTextChange(questionId, id, text) {
    test.Questions[questionId].Answers[id].Text = text;
}

function minInc(resultId) {
    test.Results[resultId].Min += 1;
    if(resultId !== 0){
        test.Results[resultId - 1].Max += 1;
    }
    if(test.Results[resultId].Min > test.Results[resultId].Max){
        maxInc(resultId);
    }
    RedrawResults();
}
function minDec(resultId) {
    if(test.Results[resultId].Min !== resultId + 1) {
        test.Results[resultId].Min -= 1;
        if (resultId !== 0) {
            test.Results[resultId - 1].Max -= 1;
            if (test.Results[resultId - 1].Min > test.Results[resultId - 1].Max) {
                minDec(resultId - 1);
            }
        }
        RedrawResults();
    }
}
function maxInc(resultId) {
    test.Results[resultId].Max += 1;
    if(resultId !== test.Results.length - 1){
        test.Results[resultId + 1].Min += 1;
        if(test.Results[resultId + 1].Min > test.Results[resultId + 1].Max){
            maxInc(resultId + 1 );
        }
    }
    RedrawResults();
}
function maxDec(resultId) {
    if(test.Results[resultId].Min !== resultId + 1 || test.Results[resultId].Min !== test.Results[resultId].Max) {
        test.Results[resultId].Max -= 1;
        if (resultId !== test.Results.length - 1) {
            test.Results[resultId + 1].Min -= 1;
        }
        if (test.Results[resultId].Min > test.Results[resultId].Max) {
            minDec(resultId);
        }
        RedrawResults();
    }
}

function addQuestion() {
    test.Questions.push(
        {
            Text : "",
            Answers : [
                {
                    Text : "",
                    Cost : 0
                },
                {
                    Text : "",
                    Cost : 0
                }
            ]
        }
    );
    RedrawQuestions();
}
function addAnswer(id) {
    test.Questions[id].Answers.push(
        {
            Text : "",
            Cost : 0
        }
    );
    RedrawQuestions();
}
function addResult() {
    if(test.Results.length !== 0){
        test.Results.push(
            {
                Text : "",
                Min : test.Results[test.Results.length - 1].Max + 1,
                Max : test.Results[test.Results.length - 1].Max + 1
            }
        );
    } else {
        test.Results.push(
            {
                Text : "",
                Min : 1,
                Max : 1
            }
        );
    }
    RedrawResults();
}