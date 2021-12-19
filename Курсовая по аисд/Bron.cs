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
    public partial class Bron : Form
    {
        public PictureBox picbox1;
        public PictureBox picbox2;
        public TabControl tab;

        public DateTime LastDate;
        public string LastStartTime;
        public string LastEndTime;
        public string LastDopInformation;
        public bool IWantToChangeEvent=false;

        public class Event : Button
        {
            public static int Number = 0;
            private string StartTime; private string EndTime;
            private DateTime Date; private string DopInformation;
            public void Event_Click(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    string Massage = "Дата: " + Convert.ToString(Date).Substring(0,10) + 
                        "\nНачало: " + StartTime +
                    "\nКонец: " + EndTime + "\nИнформация о событии: \n" + DopInformation;

                    MessageBox.Show(Massage, "Данные о событии");
                }
                else
                if (e.Button == MouseButtons.Right)
                {
                    ChangeForm change = new ChangeForm();
                    change.EventForDelete = this;
                    change.Date = this.Date;
                    change.StartTime = this.StartTime;
                    change.EndTime = this.EndTime;
                    change.DopInformation = this.DopInformation;
                    
                    change.ShowDialog();

                }
            }
            public Event(string StartTime, string EndTime, DateTime Date,
                string DopInformation)
            {
                int Y_EVENT; int X_EVENT; int H_EVENT;
                if (Convert.ToByte(Convert.ToString(Date).Substring(0, 2)) <= 16)
                    X_EVENT = 55 + 155 * (Convert.ToByte(Convert.ToString(Date).Substring(0, 2)) - 10);
                else
                    X_EVENT = 55 + 155 * (Convert.ToByte(Convert.ToString(Date).Substring(0, 2)) - 17);
                Y_EVENT = 50 + 25 * DataBank.StartTimeItems.IndexOf(StartTime);
                H_EVENT = 25 * (DataBank.StartTimeItems.IndexOf(EndTime) -
                    DataBank.StartTimeItems.IndexOf(StartTime));
                Location = new System.Drawing.Point(X_EVENT, Y_EVENT);
                Name = "button";
                Size = new System.Drawing.Size(155, H_EVENT);
                TabIndex = 0;
                Text = "Забронировал: " + DataBank.Login;
                BackColor = Color.Green;

                this.MouseUp += Event_Click;
                this.StartTime = StartTime;
                this.EndTime = EndTime;
                this.Date = Date;
                this.DopInformation = DopInformation; 
                Number += 1;
            }
        }








        public Bron()
        {
            
            InitializeComponent();
            AcceptButton.Click += AcceptButton_Click;
        }



        private void AcceptButton_Click(object sender, EventArgs e)
        {
            bool AcceptableTime = false;
            int DateIndex = Convert.ToInt16(Convert.ToString
                (dateTimePicker1.Value).Substring(0, 2)) - 10;
            int StartTimeIndex = comboBox1.SelectedIndex;
            int EndTimeIndex = DataBank.StartTimeItems.IndexOf(comboBox2.Text);
            if (DataBank.BookedTime[DateIndex] == null)
            {
                DataBank.BookedTime[DateIndex] = new List<int>();
                DataBank.BookedTime[DateIndex].Add(0);
                DataBank.BookedTime[DateIndex].Add(0);
            }
            int CountOfLimits = DataBank.BookedTime[DateIndex].Count;
            for (int i = 0; i < CountOfLimits; i+=2)
            {
                int StartLimit = DataBank.BookedTime[DateIndex][i];
                int EndLimit = DataBank.BookedTime[DateIndex][i+1];
                if ((EndTimeIndex <= StartLimit) || (StartTimeIndex >= EndLimit))
                    AcceptableTime = true;
                else
                {
                    AcceptableTime = false;
                    break;
                }
            }

            if ((comboBox1.Text == "") || (comboBox2.Text == ""))
                MessageBox.Show("Введите время!");
            else if (AcceptableTime == false)
                MessageBox.Show("Выберите другое время. Данное время уже занято.");
            else
                if (richTextBox1.Text == "")
                MessageBox.Show("Введите информацию о " +
                    "вашем событии. Например, укажите участников и тему " +
                    "ваших переговоров.");
            else
            {
                DataBank.BookedTime[DateIndex].Add(StartTimeIndex);
                DataBank.BookedTime[DateIndex].Add(EndTimeIndex);
                DataBank.StartTime = comboBox1.Text;
                DataBank.EndTime = comboBox2.Text;
                DataBank.DopInformation = richTextBox1.Text;
                DataBank.Date = dateTimePicker1.Value;
                DataBank.Event_is_Booked = true;


                if (Convert.ToByte(Convert.ToString(DataBank.Date).Substring(0, 2)) <= 16)
                {
                    picbox1.Controls.Add(new Event(DataBank.StartTime,
                     DataBank.EndTime, DataBank.Date, DataBank.DopInformation));
                    tab.SelectedIndex = 0;
                }
                else
                {
                    picbox2.Controls.Add(new Event(DataBank.StartTime,
                     DataBank.EndTime, DataBank.Date, DataBank.DopInformation));
                    tab.SelectedIndex = 1;
                }


                this.Close();
            }
                
                    

        }


        private void Bron_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            for (int i = 0; i < 24; i++)
            {
                string hour = Convert.ToString(i);
                comboBox1.Items.Add(hour + ":00");
                comboBox1.Items.Add(hour + ":30");
                DataBank.StartTimeItems.Add(Convert.ToString(hour + ":00"));
                DataBank.StartTimeItems.Add(Convert.ToString(hour + ":30"));
            }
            DataBank.StartTimeItems.Add("24:00");
            if (IWantToChangeEvent==true)
            {
                dateTimePicker1.Value = LastDate;
                comboBox1.SelectedIndex = DataBank.StartTimeItems.IndexOf(LastStartTime);
                richTextBox1.Text = LastDopInformation;

                comboBox2.Items.Clear();
                for (int i = comboBox1.SelectedIndex + 1;
                    i < comboBox1.Items.Count; i++)
                {
                    comboBox2.Items.Add(comboBox1.Items[i]);
                }
                comboBox2.Items.Add("24:00");

                comboBox2.SelectedIndex = comboBox2.Items.IndexOf(LastEndTime);


            }
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox2.Text = "";
            comboBox2.Items.Clear();
            for (int i = comboBox1.SelectedIndex + 1;
                i < comboBox1.Items.Count; i++)
            {
                comboBox2.Items.Add(comboBox1.Items[i]);
            }
            comboBox2.Items.Add("24:00");

        }

    }
}
