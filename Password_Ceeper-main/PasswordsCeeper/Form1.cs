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
using System.Xml.Serialization;
using System.IO;

namespace PasswordsCeeper
{
    public partial class Form1 : Form
    {
        LoginParameters param = new LoginParameters();
        int incorrectLoginTry = 0;
        bool passwordLogin = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists("logInParameters.xml"))
            {
                labelQuestion.Visible = true;
                labelAnswer.Visible = true;

                textBoxQuestion.Visible = true;
                textBoxAnswer.Visible = true;

                buttonApply.Visible = true;
                buttonLogin.Visible = false;
            }
            else
            {
                ReadParameters();
            }
        }

        public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            WriteParameters();

            Hide();

            MainForm mainForm = new MainForm(this);
            mainForm.Show();
        }

        private void WriteParameters()
        {
            param.LoginPassword = GetHash(textBoxPassword.Text);
            param.SecretQuestion = textBoxQuestion.Text;
            param.SecretAnswer = GetHash(textBoxAnswer.Text.ToLower());

            XmlSerializer formatter = new XmlSerializer(typeof(LoginParameters));

            using (FileStream fs = new FileStream("logInParameters.xml", FileMode.Create))
            {
                formatter.Serialize(fs, param);
            }
        }

        private void ReadParameters()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(LoginParameters));

            using (FileStream fs = new FileStream("logInParameters.xml", FileMode.Open))
            {
                param = (LoginParameters)formatter.Deserialize(fs);
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (!passwordLogin && GetHash(textBoxAnswer.Text.ToLower()) == param.SecretAnswer)
            {
                incorrectLoginTry = 0;

                Hide();

                MainForm mainForm = new MainForm(this);
                mainForm.Show();
            }
            else if (!passwordLogin)
            {
                labelWrongAnswer.Visible = true;
            }

            if (GetHash(textBoxPassword.Text) == param.LoginPassword && passwordLogin)
            {
                incorrectLoginTry = 0;
                labelWrongPassword.Visible = false;

                Hide();

                MainForm mainForm = new MainForm(this);
                mainForm.Show();
            }
            else
            {
                incorrectLoginTry ++;
                labelWrongPassword.Visible = true;
            }

            if (incorrectLoginTry >= 5)
            {
                passwordLogin = false;

                labelWrongPassword.Visible = false;
                labelPassword.Visible = false;
                textBoxPassword.Visible = false;
                label1.Visible = true;
                labelSecretQuestion.Visible = true;

                labelSecretQuestion.Text = param.SecretQuestion;
                textBoxAnswer.Visible = true;
            }
        }
    }
}
