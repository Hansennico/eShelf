using eShelf_website.Model;
using eShelf_website.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShelf_website.Controller
{
    public class LoginController
    {
        UserRepository userRepo = new UserRepository();
        public User validateLogin(string email, string password)
        {
            User user = userRepo.getUser(email, password);
            return user;
        }

        public HttpCookie createCookie(User user)
        {
            HttpCookie cookie = new HttpCookie("user_cookie");
            cookie.Value = user.Id;
            cookie.Expires = DateTime.Now.AddDays(1);
            return cookie;
        } 

        public User getUser(string id)
        {
            User user = userRepo.getUser(id);
            return user;
        }
    }
}