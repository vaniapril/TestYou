﻿using System.Collections.Generic;
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

        public List<User> GetUsers()
        {
            return _appContext.Users.Select(BuildUser).ToList();
        }

        private User BuildUser(UserDbModel u)
        {
            return new User
            {
                Id = u.Id,
                Login = u.Login,
                Password = u.Password,
            };
        }
    }
}