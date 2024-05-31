using eShelf_website.Model;
using eShelf_website.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eShelf_website.Controller
{
    public class RegisterController
    {
        UserRepository userRepo = new UserRepository();

        public bool validateRegister(string name, string email, string password, string confirm, bool tos)
        {
            if (!validateName(name)) return false;
            if (!validateEmail(email)) return false;
            if (!validatePassword(password, confirm)) return false;
            if (!tos) return false;

            registerNewUser(name, email, password);

            return true;
        }

        private bool validateName(string name)
        {
            if (name == null || name.Length == 0) return false;
            return true;
        }

        private bool validateEmail(string email)
        {
            if (email == null || email.Length == 0) 
                return false;

            bool valid = false;

            if (email.Contains("@") && email.Contains("."))
                valid = true;

            if (valid && email.LastIndexOf("@") < email.LastIndexOf(".")) 
                return true;
            return false;
        }

        private bool validatePassword(string password, string confirm)
        {
            if (password.Length < 8 || password == null) return false;
            if (password == confirm) return true;
            return false;
        }




        private void registerNewUser(string name, string email, string password)
        {
            string id = generateId();
            userRepo.insertUser(id, name, email, password);
        }

        private string generateId()
        {
            string newId = "";
            string lastId = userRepo.getLastId();

            if (lastId == null)
            {
                newId = "UD001";
            }
            else
            {
                int idNum = Convert.ToInt32(lastId.Substring(2));
                idNum++;
                newId = String.Format("UD{0:000}", idNum);
            }
            return newId;
        }

        public User getUser(string email, string password)
        {
            User user = userRepo.getUser(email, password);
            return user;
        }
    }
}