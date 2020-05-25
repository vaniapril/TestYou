function CreateTest() {
    console.log("POST-CREATE-TEST");
    $.ajax({
            url:'/TestCreate/Create',
            type:'POST',
            dataType: "json",
            data: test
        }
    );
}

let test = {
    Title : "Title1",
    Id : 1,
    UserId : 1,
    Description : "Desc1",
    Questions  : [
        {
            Id : 1,
            TestId : 1,
            Text : "What is you name?",
            Answers : [
                {
                    Id : 1,
                    QuestionId : 1,
                    Text : "Answer 1",
                    Cost : 1
                },
                {
                    Id : 2,
                    QuestionId : 1,
                    Text : "Answer 2",
                    Cost : 2
                }
            ]
        },
        {
            Id : 2,
            TestId : 1,
            Text : "Question 2",
            Answers : [
                {
                    Id : 3,
                    QuestionId : 2,
                    Text : "Answer 3",
                    Cost : 1
                },
                {
                    Id : 4,
                    QuestionId : 2,
                    Text : "Answer 3",
                    Cost : 2
                }
            ]
        }
    ],
    Results : [
        {
            Id : 1,
            TestId : 1,
            Text : "tttttt",
            Min : 1,
            Max : 4
        },
        {
            Id : 2,
            TestId : 1,
            Text : "rerretttttt",
            Min : 5,
            Max : 23
        }
    ],
    Comments : []
};
    
function Init() {
    console.log("CREATE-TEST-INIT");
    Redraw();
}
    
function Redraw() {
    console.log("CREATE-TEST-REDRAW");
    let ddl = '<table border="0" cellpadding="10">';

    ddl += "<tr align=\"top\"><td align=\"right\">Title:</td><td align=\"left\">";
    ddl += '<input class="Inp" placeholder="Title" oninput="onTitleChange(this.value)" value=\"' + test.Title + '\">';
    ddl += "</td></tr>";

    ddl += "<tr align=\"top\"><td align=\"right\">Description:</td><td align=\"left\">";
    ddl += '<input class="Inp" placeholder="Description" oninput="onDescriptionChange(this.value)" value=\"' + test.Description + '\">';
    ddl += "</td></tr>";

    ddl += "<tr align=\"top\"><td align=\"right\">Questions:</td><td align=\"left\">";
    for(let i = 0; i < test.Questions.length; i++){
        let html = htmlQuestion(test.Questions[i], i);
        ddl += html;   
    }
    ddl += "</td></tr>";
    ddl += "<tr><td></td><td><input type='button' class='new' value='New' onclick='addQuestion()'></td></td>";


    ddl += "<tr align=\"top\"><td align=\"right\">Results:</td><td align=\"left\">";
    for(let i = 0; i < test.Results.length; i++){
        let html = htmlResult(test.Results[i], i);
        ddl += html;
    }
    ddl += "</td></tr>";
    ddl += "<tr><td></td><td><input type='button' class='new' value='New' onclick='addResult()'></td></td>";

    //ddl += '<li class="list-group-item">' + test.Title + '</li>';
    ddl += "</table>";

    let element = document.getElementById("question");
    element.innerHTML = ddl;
}

function htmlQuestion(element, index) {
    let html = '';
    html += '<li class="list-group-item">';
    html += '<table border="0" cellpadding="10">';
    html += "<tr align=\"top\"><td align=\"right\">Text:</td><td align=\"left\">";
    html += '<input class="Inp" placeholder="Text" oninput="questionTextChange(+ ' + index + ', this.value)" value=\"' + element.Text + '\">';
    html += "</td></tr>";
    html += "<tr align=\"top\"><td align=\"right\">Answers:</td><td align=\"left\">";
    
    for (let i = 0; i < element.Answers.length; i++){
        html += '<input class="InpAnsw" placeholder="Answer" oninput="answerTextChange( + ' + index + ',' + i + ', this.value)" value=\"' + element.Answers[i].Text + '\">';
        html += '<label class="label">Cost:</label>';
        html += '<input type="button" class="roundedButton" value="-" onclick="costDec( + ' + index + ',' + i + ')">';
        html += '<label class="label">' + element.Answers[i].Cost + '</label>';
        html += ' <input type="button" class="roundedButton" value="+" onclick="costInc( + ' + index + ',' + i + ')">';
    }
    html += "</td></tr>";
    html += "<tr><td></td><td><input type='button' class='new' value='New' onclick='addAnswer(" + index + ")'></td></td>";
    html += "</table>";
    html += '</li>';
    return html;
}

function htmlResult(element, index) {
    let html = '';
    html += '<li class="list-group-item">';
    html += '<table border="0" cellpadding="10">';
    html += "<tr align=\"top\"><td align=\"right\">Text:</td><td align=\"left\">";
    html += '<input class="Inp" placeholder="Text" oninput="resultTextChange(+ ' + index + ', this.value)" value=\"' + element.Text + '\">';
    html += "</td></tr>";
    html += "<tr align=\"top\"><td align=\"right\">Range:</td><td align=\"left\">";

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
    Redraw();
}
function costDec(questionId, id) {
    test.Questions[questionId].Answers[id].Cost -= 1;
    Redraw();
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
    Redraw();
}
function minDec(resultId) {
    test.Results[resultId].Min -= 1;
    Redraw();
}
function maxInc(resultId) {
    test.Results[resultId].Max += 1;
    Redraw();
}
function maxDec(resultId) {
    test.Results[resultId].Max -= 1;
    Redraw();
}

function addQuestion() {
    test.Questions.push(
        {
            Text : "",
            Answers : []
        }
    );
    Redraw();
}
function addAnswer(id) {
    test.Questions[id].Answers.push(
        {
            Text : "",
            Cost : 0
        }
    );
    Redraw();
}
function addResult() {
    test.Results.push(
        {
            Text : "",
            Min : 1,
            Max : 1
        }
    );
    Redraw();
}