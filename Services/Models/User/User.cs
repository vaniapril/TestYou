using System.Collections;
using System.Collections.Generic;

namespace TestYou.Services.Models.User

{
    public class User
    {
        public string Password { set; get;}
        public string Login { set; get; }
        public int Id { set; get; }

        public SortedDictionary<int, int> Results { set; get; }
        
        ///TODO profile
    }
}