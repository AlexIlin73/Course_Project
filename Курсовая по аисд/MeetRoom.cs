using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая_по_аисд
{
    public partial class MeetRoom : Form
    {

        Label[] HoursLabels = new Label[24];
        Label[] DayLabels = new Label[7];







        public MeetRoom()
        {
            InitializeComponent();
            this.FormClosed += room_FormClosed;
            BronButton.Click += BronButton_Click;
            
            DataBank.change_bron.picbox1 = this.pictureBox1;
            DataBank.change_bron.picbox2 = this.pictureBox2;
            DataBank.change_bron.tab = this.tabControl1;



        }
        private void MeetRoom_Load(object sender, EventArgs e)
        {
            DrawTable();
            AddLabels();

        }
        private void BronButton_Click(object sender, EventArgs e)
        {
            Bron bron = new Bron();
            bron.picbox1 = this.pictureBox1;
            bron.picbox2 = this.pictureBox2;
            bron.tab = this.tabControl1;
            bron.ShowDialog();
            
        }


        private void room_FormClosed(object sender, EventArgs e)
        {
            Application.Exit();
        }


        public void DrawTable()
        {
            Bitmap bmp = new Bitmap(1136, 1261);
            Graphics g = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Black, 2);
            //Drawing rows:
            g.DrawLine(pen, 5, 5, 1136, 5);

            for (int i = 1; i < 26; i++)
            {
                g.DrawLine(pen, 5, 50 * i, 1136, 50 * i);
                
            }
            

            //Drawing columnes:
            g.DrawLine(pen, 5, 5, 5, 1255);
            for (int i = 0; i < 7; i++)
            {
                g.DrawLine(pen, 55 + 155 * i, 5, 55 + 155 * i, 1255);
            }
            g.DrawLine(pen, 1135, 5, 1135, 1255);
            
            pictureBox1.Image = bmp;
            pictureBox2.Image = bmp;



        }


        private void AddLabels()
        {
            //HourLabels for first page
            for (int i = 0; i < 24; i++)
            {
                HoursLabels[i] = new Label();
                HoursLabels[i].AutoSize = false;
                HoursLabels[i].Location = new System.Drawing.Point(7, 52 + i * 50);
                HoursLabels[i].Name = "label1";
                HoursLabels[i].Size = new System.Drawing.Size(46, 46);
                HoursLabels[i].TabIndex = 2;
                HoursLabels[i].Text = i < 10 ? "00:0" + Convert.ToString(i) :
                    "00:" + Convert.ToString(i);
                pictureBox1.Controls.Add(HoursLabels[i]);

            }
            //HourLabels for second page:


            for (int i = 0; i < 24; i++)
            {
                HoursLabels[i] = new Label();
                HoursLabels[i].AutoSize = false;
                HoursLabels[i].Location = new System.Drawing.Point(7, 52 + i * 50);
                HoursLabels[i].Name = "label1";
                HoursLabels[i].Size = new System.Drawing.Size(46, 46);
                HoursLabels[i].TabIndex = 2;
                HoursLabels[i].Text = i < 10 ? "00:0" + Convert.ToString(i) :
                    "00:" + Convert.ToString(i);
                pictureBox2.Controls.Add(HoursLabels[i]);

            }
            

            //DayLabels for first page:
            for (int i = 0; i < 7; i++)
            {
                DayLabels[i] = new Label();
                DayLabels[i].AutoSize = false;
                DayLabels[i].Location = new System.Drawing.Point(57+155*i, 7);
                DayLabels[i].Name = "label1";
                DayLabels[i].Size = new System.Drawing.Size(150, 40);
                DayLabels[i].TabIndex = 2;
                switch (i)
                {
                    case 0:
                        DayLabels[i].Text = "Понедельник\n" + Convert.ToString(10 + i) + ".01.2022";
                        break;
                    case 1:
                        DayLabels[i].Text = "Вторник\n" + Convert.ToString(10 + i) + ".01.2022";
                        break;
                    case 2:
                        DayLabels[i].Text = "Среда\n" + Convert.ToString(10 + i) + ".01.2022";
                        break;
                    case 3:
                        DayLabels[i].Text = "Четверг\n" + Convert.ToString(10 + i) + ".01.2022";
                        break;
                    case 4:
                        DayLabels[i].Text = "Пятница\n" + Convert.ToString(10 + i) + ".01.2022";
                        break;
                    case 5:
                        DayLabels[i].Text = "Суббота\n" + Convert.ToString(10 + i) + ".01.2022";
                        break;
                    case 6:
                        DayLabels[i].Text = "Воскресенье\n" + Convert.ToString(10 + i) + ".01.2022";
                        break;
                }
                pictureBox1.Controls.Add(DayLabels[i]);

            }

            //DayLabels for second page:
            for (int i = 0; i < 7; i++)
            {
                DayLabels[i] = new Label();
                DayLabels[i].AutoSize = false;
                DayLabels[i].Location = new System.Drawing.Point(57 + 155 * i, 7);
                DayLabels[i].Name = "label1";
                DayLabels[i].Size = new System.Drawing.Size(150, 40);
                DayLabels[i].TabIndex = 2;
                switch (i)
                {
                    case 0:
                        DayLabels[i].Text = "Понедельник\n" + Convert.ToString(17 + i) + ".01.2022";
                        break;
                    case 1:
                        DayLabels[i].Text = "Вторник\n" + Convert.ToString(17 + i) + ".01.2022";
                        break;
                    case 2:
                        DayLabels[i].Text = "Среда\n" + Convert.ToString(17 + i) + ".01.2022";
                        break;
                    case 3:
                        DayLabels[i].Text = "Четверг\n" + Convert.ToString(17 + i) + ".01.2022";
                        break;
                    case 4:
                        DayLabels[i].Text = "Пятница\n" + Convert.ToString(17 + i) + ".01.2022";
                        break;
                    case 5:
                        DayLabels[i].Text = "Суббота\n" + Convert.ToString(17 + i) + ".01.2022";
                        break;
                    case 6:
                        DayLabels[i].Text = "Воскресенье\n" + Convert.ToString(17 + i) + ".01.2022";
                        break;
                }
                pictureBox2.Controls.Add(DayLabels[i]);

            }

        }

        private void AddEventButton_Click_1(object sender, EventArgs e)
        {

        }
    }
}
