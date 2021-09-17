using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordsCeeper
{
    public partial class AccountAddForm : Form
    {
        private readonly ListBox _listBoxAccounts;

        public AccountAddForm(ListBox listBoxAccounts)
        {
            InitializeComponent();

            _listBoxAccounts = listBoxAccounts;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (Storage.AccountAdd(textBoxSiteURL.Text, textBoxUsername.Text, textBoxPassword.Text))
            {
                _listBoxAccounts.DataSource = null;
                _listBoxAccounts.DisplayMember = "siteURL";
                _listBoxAccounts.DataSource = Storage.Accounts();

                Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
