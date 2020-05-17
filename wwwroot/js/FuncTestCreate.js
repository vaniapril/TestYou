function CreateTest() {
    console.log("POST-CREATE-TEST");
    $.ajax({
            url:'/TestCreate/Create',
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
                Results : [],
                Comments : []
            }
        }
    );
}