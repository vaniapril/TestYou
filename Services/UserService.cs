using System.Collections.Generic;
using System.Linq;
using TestYou.Database;
using TestYou.Services.Models.User;

namespace TestYou.Services
{
    public class UserService
    {
        private readonly AppContext _appContext;
        private int _userMaxId;
        public UserService()
        {
            _appContext = new AppContext();
            _userMaxId = 1;
            foreach (var model in _appContext.results)
            {
                if (model.Id > _userMaxId)
                {
                    _userMaxId = model.Id;
                }
            }
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