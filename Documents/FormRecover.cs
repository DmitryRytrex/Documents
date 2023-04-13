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
    public partial class FormRecover : Form
    {
        public FormRecover()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            textBox3.PasswordChar = '*';
            string login = textBox1.Text;
            string password = textBox2.Text;
            string confirm = textBox3.Text;
            string symb = "ABCDEFGHIJKLMNOPRSTUVWXYZ123456789!\"#$%&'()*+,-./::<=>?@[\\]:_{|}";
            if (textBox2.Text.IndexOfAny(symb.ToCharArray()) == -1 || textBox2.Text.Length < 8 || textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Пароль не соответствует стандартам. Используйте в пароле как минимум 5 букв и 3 цифры, а также знаки @#%");
            }
            else
            {
                using (DataBase db = new DataBase())
                {

                    db.ExecuteSqlNonQuery($"UPDATE USER WHERE [LOGIN] = '{textBox1.Text}' SET [PASSWORD] = {textBox2.Text}");

                }
            }
        }
    }
}
