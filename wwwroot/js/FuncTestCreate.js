function CreateTest() {
    console.log("POST-CREATE-TEST");
    $.ajax({
            url:'/TestCreate/CreateTestPost',
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
                            {
                                Id : 1,
                                QuestionId : 1,
                                Text : "Answ1",
                                Cost : 1
                            },
                            {
                                Id : 2,
                                QuestionId : 1,
                                Text : "Answ2",
                                Cost : 2
                            }
                        ] 
                    },
                    {
                        Id : 2,
                        TestId : 1,
                        Text : "Question1",
                        Answers : [
                            {
                                Id : 3,
                                QuestionId : 2,
                                Text : "Answ1",
                                Cost : 1
                            },
                            {
                                Id : 4,
                                QuestionId : 2,
                                Text : "Answ2",
                                Cost : 2
                            }
                        ]
                    }
                ],
                Results : [],
                Comments : []
            }
        }
    );
}