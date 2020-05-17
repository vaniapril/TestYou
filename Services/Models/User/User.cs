using TestYou.Database.DbModels;

namespace TestYou.Services.Models.User

{
    public class User
    {
        public string Password { set; get;}
        public string Login { set; get; }
        public int Id { set; get; }
        public static User FromDbModel(UserDbModel model)
        {
            return new User
            {
                Id = model.Id,
                Password = model.Password,
                Login = model.Login
            };
        }
        public static UserDbModel ToDbModel(User item)
        {
            return new UserDbModel
            {
                Id = item.Id,
                Password = item.Password,
                Login = item.Login
            };
        }
        public override string ToString()
        {
            return "User {\nId: " + Id + ", \nLogin: " + Login + ", \nPassword: " + Password + "\n}";
        }
    }
}