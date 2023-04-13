using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Documents.DBConnect;

namespace Documents
{
    public partial class FormAuth : Form
    {
        public FormAuth()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;


            string login = textBox1.Text;
            string password = textBox2.Text;

            using (DataBase db = new DataBase())
            {
                DataTable users = db.ExecuteSql($"select * from [USER] where [Login] = '{login}' and [Password] = '{password}'");

                if (users.Rows.Count > 0) //||userLevel)
                {
                    FormMain Main = new FormMain();
                    Main.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль! Проверьте корректность введенных данных.");
                    count++;
                }
                if (count >= 3)
                {
                    const string message = "Неправильный логин или пароль. Хотите восстановить доступ к аккаунту?";
                    const string caption = "Восстановление доступа";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                    if (result == DialogResult.Yes)
                    {
                        FormRecover recover = new FormRecover();
                        recover.Show();
                    }
                }

            }
        }
    }
}
