using System.Collections.Generic;
using System.Linq;
using TestYou.Database;
using TestYou.Database.DbModels;
using TestYou.Services.Models.User;

namespace TestYou.Services
{
    public class UserService
    {
        private readonly AppContext _appContext;
        public UserService()
        {
            _appContext = new AppContext();
        }
        public void AddUser(User user)
        {    
            _appContext.Users.Add(User.ToDbModel(user));
        }

        public User GetUserById(int Id)
        {
            return _appContext.Users.Select(User.FromDbModel).First(user => user.Id == Id);
        }
            
        public List<User> GetUsers()
        {
            return _appContext.Users.Select(User.FromDbModel).ToList();
        }
    }
}