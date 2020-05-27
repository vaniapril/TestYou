using TestYou.Services.Models.Test;

namespace TestYou.Services.Models
{
    public static class DefaultModels
    {
        private static TestService _testService;
        private static UserService _userService;
        static DefaultModels()
        {
            _testService = new TestService();
            _userService = new UserService();
        }
        
        public static void Create()
        {
            CreateUsers();
            CreateTests();
        }
        static void CreateUsers()
        {
            var user1 = new User.User()
            {
                Login = "Cheater007",
                Password = "1234",
            };
            var user2 = new User.User()
            {
                Login = "Никита74",
                Password = "1234",
            };
            var user3 = new User.User()
            {
                Login = "Артем123123",
                Password = "1234",
            };
            _userService.Insert(user1);
            _userService.Insert(user2);
            _userService.Insert(user3);
        }
        static void CreateTests()
        {
            var DefualtTest1 = new Test.Test
            {
            Title = "Какой ты Овощ?",
            UserId =  0,
            Description = "Этот изумительный тест поможет вам определить ваши корни?",
            Comments = new []
            {
                new Comment()
                {
                 UserId   = 1,
                 Text = "Какой прекрасный тест, всегда знал что я та еще морковка.",
                 IsLike = true
                },
                new Comment()
                {
                    UserId   = 2,
                    Text = "Не согласен, мне кажется что я все таки баклажан.",
                    IsLike = false
                }
            },
            Results = new[]
            {
                new TestResult()
                {
                    Text = "Вы самый настояший Баклажан",
                    Max = 24,
                    Min = 17
                },
                new TestResult()
                {
                    Text = "Вы красивая Морковь!",
                    Max = 17,
                    Min = 9
                },
                new TestResult()
                {
                    Text = "Вы суровая Капуста!",
                    Max = 30,
                    Min = 24
                }
            },
            Questions  = new[]
                {
                    new Question()
                    {
                    Text = "У вас много разнообрахных Одежек?",
                    Answers = new[]
                    {
                        new Answer()
                        {
                            Text = "Да, целая куча!",
                            Cost = 3
                        },
                        new Answer()
                        {
                            Text = "Одна, Зато какая!",
                            Cost = 2
                        },
                        new Answer()
                        {
                            Text = "Хорошо что хоть одна есть",
                            Cost = 1
                        }
                    }
                    
                },
                    new Question()
                    {
                    Text = "Какого животного вы боитесь больше всего?",
                    Answers = new[]
                    {
                        new Answer()
                        {
                            Text = "Зайцев, ненавижу зайцев!",
                            Cost = 1
                        },
                        new Answer()
                        {
                            Text = "Насекомые, они такие мерзкие!",
                            Cost = 3
                        },
                        new Answer()
                        {
                            Text = "Парнокопытных, а то иш, с двумя копытами то на одной ноге!",
                            Cost = 2
                        }
                    }
                },   
                    new Question()
                    {
                    Text = "Вы любите Солнышко?",
                    Answers = new[]
                    {
                        new Answer()
                        {
                            Text = "Да мне как то все равно!",
                            Cost = 2
                        },
                        new Answer()
                        {
                            Text = "Тень, дайте мне тень!",
                            Cost = 1
                        },
                        new Answer()
                        {
                            Text = "Так бы и нежился в лучах солнца!",
                            Cost = 3
                        }
                    }
                },
                    new Question()
                    {
                    Text = "Сколько иностранных языков вы знаете?",
                    Answers = new[]
                    {
                        new Answer()
                        {
                            Text = "Ну так, парочка найдется!",
                            Cost = 1
                        },
                        new Answer()
                        {
                            Text = "Шо, я гавару тока на адном языке!",
                            Cost = 3
                        },
                        new Answer()
                        {
                            Text = "Je parle français aussi",
                            Cost = 2
                        }
                    }
                },
                    new Question()
                    {
                    Text = "Какой цвет из перечисленных вам наиболее симпатичен?",
                    Answers = new[]
                    {
                        new Answer()
                        {
                            Text = "Небесно зеленый!",
                            Cost = 3
                        },
                        new Answer()
                        {
                            Text = "Оранжевый как солнечный закат!",
                            Cost = 1
                        },
                        new Answer()
                        {
                            Text = "Как последний цвет радуги(Фиолетовый)!",
                            Cost = 2
                        }
                    }
                },
                    new Question()
                    {
                    Text = "Какой сок вам больше нравится?",
                    Answers = new[]
                    {
                        new Answer()
                        {
                            Text = "Вкусный!",
                            Cost = 1
                        },
                        new Answer()
                        {
                            Text = "Недорогой",
                            Cost = 2
                        },
                        new Answer()
                        {
                            Text = "Желудочный!",
                            Cost = 3
                        }
                    }
                },
                    new Question()
                    {
                    Text = "Какие формы вы предпочитаете?",
                    Answers = new[]
                    {
                        new Answer()
                        {
                            Text = "Большие и круглые!",
                            Cost = 3
                        },
                        new Answer()
                        {
                            Text = "Узкие и длинные!",
                            Cost = 1
                        },
                        new Answer()
                        {
                            Text = "Цилидры хорошего размера!",
                            Cost = 2
                        }
                    }
                },
                    new Question()
                    {
                    Text = "Как вы соблазняете окружаюших?",
                    Answers = new[]
                    {
                        new Answer()
                        {
                            Text = "Своей непревзойденной красотой!",
                            Cost = 3
                        },
                        new Answer()
                        {
                            Text = "Деньгами разумеется!",
                            Cost = 2
                        },
                        new Answer()
                        {
                            Text = "Просто прекрасным собой!",
                            Cost = 1
                        }
                    }
                },
                    new Question()
                    {
                    Text = "На сколько вы привередливый?",
                    Answers = new[]
                    {
                        new Answer()
                        {
                            Text = "Фу какая-та мусоринка попала!",
                            Cost = 1
                        },
                        new Answer()
                        {
                            Text = "Ай, не мешает же, а остальные потерпят!",
                            Cost = 3
                        },
                        new Answer()
                        {
                            Text = "Не ну, убираюсь иногда!",
                            Cost = 2
                        }
                    }
                },
                    new Question()
                    {
                    Text = "Стейк какой прожарки ты предпочитаешь?",
                    Answers = new[]
                    {
                        new Answer()
                        {
                            Text = "С кровью, чтобы вкус был тот самый!",
                            Cost = 2
                        },
                        new Answer()
                        {
                            Text = "Где то посерединке, так чтобы и мягко!",
                            Cost = 3
                        },
                        new Answer()
                        {
                            Text = "Исключительно хорошей прожарки!",
                            Cost = 1
                        }
                    }
                },
                }
            };
            _testService.Insert(DefualtTest1);
        }
    }
}