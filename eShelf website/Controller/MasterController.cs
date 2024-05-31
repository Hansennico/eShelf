using eShelf_website.Model;
using eShelf_website.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace eShelf_website.Controller
{
    public class MasterController
    {
        UserRepository userRepo = new UserRepository();
        
        public User getUser(string id)
        {
            return userRepo.getUser(id);
        }

        public bool isAdmin(string id)
        {
            if (id.Contains("AD"))
                return true;
            return false;
        }

        public bool validateText(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                return true;
            }
            return false;
        }
    }
}