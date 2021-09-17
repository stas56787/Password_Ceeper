using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace PasswordsCeeper
{
    public partial class MainForm : Form
    {
        private readonly Form _loginForm = new Form();
        public int selectedIndex = -1;
        bool isFirstLaunch = true;
        private string siteURLBeforeEdit;
        private string usernameBeforeEdit;
        private string passwordBeforeEdit;

        public MainForm(Form loginForm)
        {
            InitializeComponent();

            Storage.LoadData();
            _loginForm = loginForm;

            //Encrypt();

            //Decrypt();
        }

        private void Encrypt()
        {
            try
            {
                string textToEncrypt = File.ReadAllText("acc.xml");

                using (FileStream fileStream = new FileStream("acc.xml", FileMode.OpenOrCreate))
                {
                    using (Aes aes = Aes.Create())
                    {
                        byte[] key =
                        {
                0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
            };
                        aes.Key = key;

                        ////// ключ 128 бит на основе пароля //////
                        // если длина пароля больше 16, надо чинить
                        
                        //string pass = "qwerty";
                        //byte[] bytes = Encoding.Default.GetBytes(pass + new string('0', 16 - pass.Length));
                        //aes.Key = bytes;

                        byte[] iv = aes.IV;
                        fileStream.Write(iv, 0, iv.Length);

                        using (CryptoStream cryptoStream = new CryptoStream(
                            fileStream,
                            aes.CreateEncryptor(),
                            CryptoStreamMode.Write))
                        {
                            using (StreamWriter encryptWriter = new StreamWriter(cryptoStream))
                            {
                                encryptWriter.WriteLine(textToEncrypt);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The encryption failed. {ex}");
            }
        }

        private async void Decrypt()
        {
            try
            {
                string decryptedMessage;

                using (FileStream fileStream = new FileStream("acc.xml", FileMode.Open))
                {
                    using (Aes aes = Aes.Create())
                    {
                        byte[] iv = new byte[aes.IV.Length];
                        int numBytesToRead = aes.IV.Length;
                        int numBytesRead = 0;
                        while (numBytesToRead > 0)
                        {
                            int n = fileStream.Read(iv, numBytesRead, numBytesToRead);
                            if (n == 0) break;

                            numBytesRead += n;
                            numBytesToRead -= n;
                        }

                        byte[] key =
                        {
                0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
            };

                        ////// ключ 128 бит на основе пароля //////
                        ///
                        // string pass = "qwerty";
                        // byte[] bytes = Encoding.Default.GetBytes(pass + new string('0', 16 - pass.Length));

                        using (CryptoStream cryptoStream = new CryptoStream(
                           fileStream,
                           aes.CreateDecryptor(key, iv),
                           CryptoStreamMode.Read))
                        {
                            using (StreamReader decryptReader = new StreamReader(cryptoStream))
                            {
                                decryptedMessage = await decryptReader.ReadToEndAsync();
                                //MessageBox.Show($"The decrypted original message: {decryptedMessage}");
                            }
                        }
                    }
                }

                File.WriteAllText("acc.xml", decryptedMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The decryption failed. {ex}");
            }
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
            siteURLBeforeEdit = linkLabelSiteURL.Text;
            usernameBeforeEdit = textBoxUsername.Text;
            passwordBeforeEdit = textBoxPassword.Text;

            textBoxSiteURL.Text = linkLabelSiteURL.Text;
            linkLabelSiteURL.Visible = false;

            textBoxSiteURL.Visible = true;
            textBoxUsername.ReadOnly = false;
            textBoxPassword.ReadOnly = false;

            buttonEdit.Visible = false;
            buttonSave.Visible = true;
            buttonCancel.Visible = true;
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
            buttonCancel.Visible = false;
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            linkLabelSiteURL.Text = siteURLBeforeEdit;
            textBoxUsername.Text = usernameBeforeEdit;
            textBoxPassword.Text = passwordBeforeEdit;

            linkLabelSiteURL.Visible = true;

            textBoxSiteURL.Clear();
            textBoxSiteURL.Visible = false;

            textBoxUsername.ReadOnly = true;
            textBoxPassword.ReadOnly = true;

            buttonEdit.Visible = true;
            buttonSave.Visible = false;
            buttonCancel.Visible = false;
            buttonDelete.Visible = true;
            buttonAddAccount.Enabled = true;

            pictureBoxClose.Visible = true;
            pictureBoxCopy.Visible = true;

            listBoxAccounts.Enabled = true;
        }
    }
}
