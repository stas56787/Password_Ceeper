
namespace PasswordsCeeper
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxQuestion = new System.Windows.Forms.TextBox();
            this.textBoxAnswer = new System.Windows.Forms.TextBox();
            this.buttonApply = new System.Windows.Forms.Button();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelQuestion = new System.Windows.Forms.Label();
            this.labelAnswer = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.labelWrongPassword = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelSecretQuestion = new System.Windows.Forms.Label();
            this.labelWrongAnswer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPassword.Location = new System.Drawing.Point(124, 76);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '•';
            this.textBoxPassword.Size = new System.Drawing.Size(193, 26);
            this.textBoxPassword.TabIndex = 0;
            // 
            // textBoxQuestion
            // 
            this.textBoxQuestion.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxQuestion.Location = new System.Drawing.Point(124, 126);
            this.textBoxQuestion.Name = "textBoxQuestion";
            this.textBoxQuestion.Size = new System.Drawing.Size(193, 26);
            this.textBoxQuestion.TabIndex = 1;
            this.textBoxQuestion.Visible = false;
            // 
            // textBoxAnswer
            // 
            this.textBoxAnswer.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxAnswer.Location = new System.Drawing.Point(124, 176);
            this.textBoxAnswer.Name = "textBoxAnswer";
            this.textBoxAnswer.PasswordChar = '•';
            this.textBoxAnswer.Size = new System.Drawing.Size(193, 26);
            this.textBoxAnswer.TabIndex = 2;
            this.textBoxAnswer.Visible = false;
            // 
            // buttonApply
            // 
            this.buttonApply.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonApply.Location = new System.Drawing.Point(209, 222);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(108, 35);
            this.buttonApply.TabIndex = 3;
            this.buttonApply.Text = "Подтвердить";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Visible = false;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPassword.Location = new System.Drawing.Point(121, 55);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(55, 18);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Пароль";
            // 
            // labelQuestion
            // 
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelQuestion.Location = new System.Drawing.Point(121, 105);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(127, 18);
            this.labelQuestion.TabIndex = 5;
            this.labelQuestion.Text = "Секретный вопрос";
            this.labelQuestion.Visible = false;
            // 
            // labelAnswer
            // 
            this.labelAnswer.AutoSize = true;
            this.labelAnswer.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAnswer.Location = new System.Drawing.Point(121, 155);
            this.labelAnswer.Name = "labelAnswer";
            this.labelAnswer.Size = new System.Drawing.Size(183, 18);
            this.labelAnswer.TabIndex = 6;
            this.labelAnswer.Text = "Ответ на секретный вопрос";
            this.labelAnswer.Visible = false;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLogin.Location = new System.Drawing.Point(229, 222);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(88, 35);
            this.buttonLogin.TabIndex = 7;
            this.buttonLogin.Text = "Войти";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // labelWrongPassword
            // 
            this.labelWrongPassword.AutoSize = true;
            this.labelWrongPassword.ForeColor = System.Drawing.Color.Red;
            this.labelWrongPassword.Location = new System.Drawing.Point(121, 105);
            this.labelWrongPassword.Name = "labelWrongPassword";
            this.labelWrongPassword.Size = new System.Drawing.Size(98, 13);
            this.labelWrongPassword.TabIndex = 8;
            this.labelWrongPassword.Text = "Неверный пароль";
            this.labelWrongPassword.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(412, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Вы неправильно ввели пароль 5 раз, для входа ответьте на секретный вопрос:";
            this.label1.Visible = false;
            // 
            // labelSecretQuestion
            // 
            this.labelSecretQuestion.AutoSize = true;
            this.labelSecretQuestion.Location = new System.Drawing.Point(121, 132);
            this.labelSecretQuestion.Name = "labelSecretQuestion";
            this.labelSecretQuestion.Size = new System.Drawing.Size(35, 13);
            this.labelSecretQuestion.TabIndex = 10;
            this.labelSecretQuestion.Text = "label2";
            this.labelSecretQuestion.Visible = false;
            // 
            // labelWrongAnswer
            // 
            this.labelWrongAnswer.AutoSize = true;
            this.labelWrongAnswer.ForeColor = System.Drawing.Color.Red;
            this.labelWrongAnswer.Location = new System.Drawing.Point(121, 206);
            this.labelWrongAnswer.Name = "labelWrongAnswer";
            this.labelWrongAnswer.Size = new System.Drawing.Size(90, 13);
            this.labelWrongAnswer.TabIndex = 11;
            this.labelWrongAnswer.Text = "Неверный ответ";
            this.labelWrongAnswer.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 319);
            this.Controls.Add(this.labelWrongAnswer);
            this.Controls.Add(this.labelSecretQuestion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelWrongPassword);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.labelAnswer);
            this.Controls.Add(this.labelQuestion);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.textBoxAnswer);
            this.Controls.Add(this.textBoxQuestion);
            this.Controls.Add(this.textBoxPassword);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxQuestion;
        private System.Windows.Forms.TextBox textBoxAnswer;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.Label labelAnswer;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label labelWrongPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelSecretQuestion;
        private System.Windows.Forms.Label labelWrongAnswer;
    }
}

