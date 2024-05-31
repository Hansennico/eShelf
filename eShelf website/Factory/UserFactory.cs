using eShelf_website.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShelf_website.Factory
{
    public class UserFactory
    {
        public static User createUser(string id, string name, string email, string password)
        {
            User user = new User();
            user.Id = id;
            user.Name = name;
            user.Email = email;
            user.Password = password;
            return user;
        }


    }
}