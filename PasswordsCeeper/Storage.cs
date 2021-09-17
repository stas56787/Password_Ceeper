using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace PasswordsCeeper
{
    static class Storage
    {
        private static List<Account> accounts = new List<Account>();

        public static void LoadData()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Account>));
            using (FileStream fs = new FileStream("accounts.xml", FileMode.OpenOrCreate))
                accounts = (List<Account>)formatter.Deserialize(fs);
        }

        public static void SaveData()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Account>));
            using (FileStream fs = new FileStream("accounts.xml", FileMode.Create))
                formatter.Serialize(fs, accounts);
        }

        public static void AccountEdit(Account oldAccount, string newSiteURL, string newUsername, string newPassword)
        {
            foreach (var account in accounts)
                if (account.SiteURL == oldAccount.SiteURL && account.Username == oldAccount.Username)
                {
                    account.SiteURL = newSiteURL;
                    account.Username = newUsername;
                    account.Password = newPassword;
                }

            SaveData();
        }

        public static bool AccountAdd(string siteURL, string username, string password)
        {
            foreach (var account in accounts)
                if (account.SiteURL == siteURL && account.Username == username)
                {
                    MessageBox.Show("Аккаунт с таким пользователем на этом сайте уже есть");
                    return false;
                }

            Account acc = new Account(siteURL, username, password);
            accounts.Add(acc);

            SaveData();

            return true;
        }

        public static List<Account> Accounts()
        {
            return accounts;
        }
    }
}
