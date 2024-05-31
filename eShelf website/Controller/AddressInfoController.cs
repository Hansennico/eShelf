using eShelf_website.Model;
using eShelf_website.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShelf_website.Controller
{
    public class AddressInfoController
    {
        UserRepository userRepo = new UserRepository();

        public List<Country> getCountryList()
        {
            Country Indonesia = new Country("Indonesia", "+62", "ID");
            Country Phillipines = new Country("Phillipines", "+63", "PH");
            Country Singapore = new Country("Singapore", "+65", "SG");
            Country Malaysia = new Country("Malaysia", "+60", "MY");
            Country Japan = new Country("Japan", "+81", "JP");

            List<Country> countries = new List<Country> {Indonesia, Phillipines, Singapore, Malaysia, Japan };
            return countries;
        }

        public bool validateAddressInfo(string phone,string address, string postal, string country, string state, string city, User user)
        {
            bool valPhone = validPhone(phone);
            bool valAddress = validOther(address);
            bool valPostal = validPostal(postal);
            bool valCountry = validCountry(country);
            bool valState = validOther(state);
            bool valCity = validOther(city);

            if (!valPhone || !valAddress || !valPostal || !valCountry || !valState || !valCity)
                return false;

            updateAddressInfo(phone, address, postal, country, state, city, user);
            return true;
        }

        public void updateAddressInfo(string phone, string address, string postal, string country, string state, string city, User user)
        {
            int postalCode = Convert.ToInt32(postal);
            userRepo.updateAddressInfo(phone, address, postalCode, country, state, city, user.Id);
        }

        protected bool validPhone(string phone)
        {
            if (phone == null || phone.Length == 0 || phone.Length < 11 )
                return false;
            
            return true;
        }

        protected bool validOther(string x)
        {
            if (x == null || x.Length == 0)
                return false;
            
            return true;
        }

        protected bool validPostal(string postal)
        {
            bool valid = true;

            if (postal == null || postal.Length == 0)
            {
                valid = false;
                return false;
            }

            if (valid)
            {
                foreach (char c in postal)
                {
                    if (!char.IsDigit(c)) return false;
                }
                return true;
            }
            return false;
        }

        protected bool validCountry(string country)
        {
            if (country == null || country.Length == 0)
            {
                return false;
            }
            return true;
        }
    }
}