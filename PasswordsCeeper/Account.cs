using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordsCeeper
{
    [Serializable]
    public class Account
    {
        public string SiteURL { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Account()
        {

        }

        public Account(string inp_site, string inp_username, string inp_password)
        {
            SiteURL = inp_site;
            Username = inp_username;
            Password = inp_password;
        }
    }
}
