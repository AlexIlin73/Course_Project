using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;
using System.Collections;



namespace Курсовая_по_аисд
{


    public partial class Authorization : Form
    {
        ArrayList DataOfUsers = new ArrayList();
       
        public Authorization()
        {
            
            InitializeComponent();
            DataOfUsers.AddRange(new string[] {"admin","admin"} );
            DataOfUsers.AddRange(new string[] { "Alexander", "alex73" });
            DataOfUsers.AddRange(new string[] { "Александр", "алекс73" });
            DataOfUsers.AddRange(new string[] { "админ", "админ" });
            EnterButton.Click += EnterButton_Click;
            
            
        }
        private void EnterButton_Click(object sender, EventArgs e)
        {
            int i = 0;
            bool CorrectData = false;
            while (i < DataOfUsers.Count)
            {
                if ((login.Text == (string)DataOfUsers[i]) &&
                    (password.Text == (string)DataOfUsers[i + 1]))
                {
                    DataBank.Login = login.Text;
                    MeetRoom room = new MeetRoom();
                    this.Hide();
                    room.Show();
                    CorrectData = true;
                    break;
                }
                i += 2;
            }
            if (CorrectData == false)
            {
                MessageBox.Show("Неверный логин или пароль");
            }

        }

        private void Authorization_Load(object sender, EventArgs e)
        {

        }

        private void login_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
