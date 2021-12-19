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
    public partial class ChangeForm : Form
    {
        public Button EventForDelete;
        
        public DateTime Date;
        public string StartTime;
        public string EndTime;
        public string DopInformation;
        public ChangeForm()
        {
            InitializeComponent();
        }

        private void ChangeForm_Load(object sender, EventArgs e)
        {
            DeleteButton.Click += DeleteButton_Click;
            ChangeButton.Click += ChangeButton_Click;
        }

        private void DeleteEvent()
        {
            int DateIndex = Convert.ToInt16(Convert.ToString
                     (Date).Substring(0, 2)) - 10;
            int StartTimeIndex = DataBank.StartTimeItems.IndexOf(StartTime);
            int EndTimeIndex = DataBank.StartTimeItems.IndexOf(EndTime);
            int CountOfLimits = DataBank.BookedTime[DateIndex].Count;
            int LimitIndex = 0;

            for (int i = 0; i < CountOfLimits; i += 2)
            {
                int StartLimit = DataBank.BookedTime[DateIndex][i];
                int EndLimit = DataBank.BookedTime[DateIndex][i + 1];
                if ((StartTimeIndex == StartLimit) && (EndTimeIndex == EndLimit))
                {
                    LimitIndex = i;
                }
            }

            DataBank.BookedTime[DateIndex].RemoveAt(LimitIndex);
            DataBank.BookedTime[DateIndex].RemoveAt(LimitIndex);
            EventForDelete.Parent.Controls.Remove(EventForDelete);
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteEvent();
            this.Close();
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            this.Close();
            DeleteEvent();
            
            DataBank.change_bron.IWantToChangeEvent = true;
            DataBank.change_bron.LastDate = Date;
            DataBank.change_bron.LastStartTime = StartTime;
            DataBank.change_bron.LastEndTime = EndTime;
            DataBank.change_bron.LastDopInformation = DopInformation;

            DataBank.change_bron.ShowDialog();



        }

    }
}
