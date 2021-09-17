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
    public partial class MainForm : Form
    {
        private readonly Form _loginForm = new Form();
        public int selectedIndex = -1;
        bool isFirstLaunch = true;

        public MainForm(Form loginForm)
        {
            InitializeComponent();

            Storage.LoadData();
            _loginForm = loginForm;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _loginForm.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            listBoxAccounts.DisplayMember = "siteURL";
            listBoxAccounts.DataSource = Storage.Accounts();
            listBoxAccounts.ClearSelected();

            toolTip.SetToolTip(pictureBoxCopy, "Копировать в буфер обмена");
        }

        private void listBoxAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            AccountInfoOutput();
        }

        private void AccountInfoOutput()
        {
            if (selectedIndex == listBoxAccounts.SelectedIndex)
                return;

            if (isFirstLaunch)
            {
                isFirstLaunch = false;
                return;
            }

            if (!panel1.Visible)
                panel1.Visible = true;

            selectedIndex = listBoxAccounts.SelectedIndex;

            if (listBoxAccounts.SelectedIndex != -1)
            {
                var acc = (Account)listBoxAccounts.SelectedItem;

                linkLabelSiteURL.Text = acc.SiteURL;
                textBoxUsername.Text = acc.Username;
                textBoxPassword.Text = acc.Password;

                pictureBoxCopy.Location = new Point(linkLabelSiteURL.Location.X + linkLabelSiteURL.Width + 5, 54);
            }
        }

        private void buttonAddAccount_Click(object sender, EventArgs e)
        {
            var addForm = new AccountAddForm(listBoxAccounts);
            addForm.ShowDialog();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Storage.Accounts().Remove((Account)listBoxAccounts.SelectedItem);

            selectedIndex = -1;
            isFirstLaunch = true;
            panel1.Visible = false;

            listBoxAccounts.DataSource = null;
            listBoxAccounts.DisplayMember = "siteURL";
            listBoxAccounts.DataSource = Storage.Accounts();
            listBoxAccounts.ClearSelected();

            Storage.SaveData();
        }

        private void pictureBoxCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(linkLabelSiteURL.Text);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            textBoxSiteURL.Text = linkLabelSiteURL.Text;
            linkLabelSiteURL.Visible = false;

            textBoxSiteURL.Visible = true;
            textBoxUsername.ReadOnly = false;
            textBoxPassword.ReadOnly = false;

            buttonEdit.Visible = false;
            buttonSave.Visible = true;
            buttonDelete.Visible = false;
            buttonAddAccount.Enabled = false;

            pictureBoxClose.Visible = false;
            pictureBoxCopy.Visible = false;

            listBoxAccounts.Enabled = false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Storage.AccountEdit((Account)listBoxAccounts.SelectedItem, textBoxSiteURL.Text, textBoxUsername.Text, textBoxPassword.Text);

            linkLabelSiteURL.Visible = true;
            linkLabelSiteURL.Text = textBoxSiteURL.Text;

            textBoxSiteURL.Clear();
            textBoxSiteURL.Visible = false;

            textBoxUsername.ReadOnly = true;
            textBoxPassword.ReadOnly = true;

            buttonEdit.Visible = true;
            buttonSave.Visible = false;
            buttonDelete.Visible = true;
            buttonAddAccount.Enabled = true;

            pictureBoxClose.Visible = true;
            pictureBoxCopy.Visible = true;
            pictureBoxCopy.Location = new Point(linkLabelSiteURL.Location.X + linkLabelSiteURL.Width + 5, 54);

            listBoxAccounts.Enabled = true;
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            listBoxAccounts.ClearSelected();
            panel1.Visible = false;
        }
    }
}
