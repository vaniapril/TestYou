using System;
using System.Collections.Generic;
using System.Linq;
using TestYou.Services.Models.User;
using AppContext = TestYou.Database.AppContext;

namespace TestYou.Services
{
    public class UserService
    {
        private readonly AppContext _appContext;
        private int _userMaxId;
        public UserService()
        {
            _appContext = new AppContext();
            _userMaxId = 0;
            foreach (var model in _appContext.users)
            {
                if (model.Id > _userMaxId)
                {
                    _userMaxId = model.Id;
                }
            }

            var user = new User()
            {
                Id = 1,
                Login = "admin",
                Password = "admin"
            };
            _appContext.UserInsert(User.ToDbModel(user));
        }
        public void Insert(User user)
        {
            user.Id = ++_userMaxId;
            _appContext.UserInsert(User.ToDbModel(user));
        }

        public User GetUserById(int id)
        {
            return _appContext.users.Select(User.FromDbModel).First(user => user.Id == id);
        }
        public List<User> GetUsers()
        {
            return _appContext.users.Select(User.FromDbModel).ToList();
        }
    }
}