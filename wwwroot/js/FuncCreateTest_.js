function CreateTest() {
    console.log("POST-CREATE-TEST");
    $.ajax({
            url:'/CreateTest/CreateTestPost',
            type:'POST',
            dataType: "json",
            data: {
                Title : "Title1",
                Id : 1,
                UserId : 1,
                Description : "Desc1",
                Questions  : [
                    {
                        Id : 1,
                        TestId : 1, 
                        Text : "Question1",
                        Answers : [
                            "Answ1",
                            "Answ2",
                            "Answ3"
                        ] 
                    },
                    {
                        Id : 2,
                        TestId : 1,
                        Text : "Question1",
                        Answers : [
                            "Answ1",
                            "Answ2",
                            "Answ3"
                        ]
                    }
                ],
                Results : [],
                Comments : []
            }
        }
    );
}