using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShelf_website.Controller
{
    public class Country
    {
        private string name;
        private string dialCode;
        private string code;

        public Country(string name, string dialCode, string code)
        {
            this.name = name;
            this.dialCode = dialCode;
            this.code = code;
        }

        public string getName()
        {
            return name;
        }

        public string getDialCode()
        {
            return dialCode;
        }

        public string getCode()
        {
            return code;
        }

        public void setName(string x)
        {
            name = x;
        }

        public void setDialCode(string x)
        {
            dialCode = x;
        }

        public void setCode(string x)
        {
            code = x;
        }
    }
}