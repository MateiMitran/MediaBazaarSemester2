using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Day = PRJMediaBazaar.Logic.Day;
using PRJMediaBazaar.Logic;

namespace PRJMediaBazaar
{
    partial class ChangeNeededPosition : Form
    {
        string _jobPositon;
        Day _day;
        NamesRow[] _rows;
        HRHome _hr;
        private int _scheduleId;
        private int _dayIndex;
        public ChangeNeededPosition(string jobPostion,Day day, NamesRow[] rows, HRHome hr, int  scheduleId, int dayIndex)
        {
            InitializeComponent();
            _jobPositon = jobPostion;
            _day = day;
            _rows = rows;
            _hr = hr;
            _scheduleId = scheduleId;
            _dayIndex = dayIndex;
            this.lblInfo.Text = $"Updating position:{jobPostion} for day: {_day.Date.ToString("dd-MM-yyyy")}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int morning = Convert.ToInt32(this.tbMorning.Text);
                int midday = Convert.ToInt32(this.tbMidday.Text);
                int evening = Convert.ToInt32(this.tbEvening.Text);

                if (morning < 1 || morning> 10) throw new FormatException();
                if (midday < 1 || midday > 10) throw new FormatException();
                if (evening < 1 || evening> 10) throw new FormatException();
                if (!AmountsCanChangeWith(morning,midday,evening)) throw new ArgumentOutOfRangeException();

                DialogResult dialogResult = MessageBox.Show($"Are you sure you want to set the needed amount of " +
              $"{_jobPositon} to:{Environment.NewLine} Morning:{morning}, Midday:{midday}, Evening:{evening}", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                       if (_day.ChangeNeededJobPosition(_jobPositon, morning,midday,evening))
                        {
                            _hr.UpdateDaysCheckbox(_scheduleId);
                            _hr.cbDay.SelectedIndex = _dayIndex;
                            _hr.UpdatePositionNeededLabel();
                            _hr.LoadTableByPosition((Day)_hr.cbDay.SelectedItem, _jobPositon);
                            this.Close();
                            MessageBox.Show("Successfully updated needed amount");

                        }
                }
            }
            catch(FormatException ex)
            {
                MessageBox.Show("Please enter a whole number between 1 and 10");
            }
            catch(ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("The amounts you want to set should be bigger or equal than the assigned columns in the table");
            }
          
        }

        public bool AmountsCanChangeWith(int morning, int midday, int evening)
        {
            int assignedMorning = 0;
            int assignedMidday = 0;
            int assignedEvening = 0;

            foreach (NamesRow r in _rows)
            {
                if (r.Morning != null)
                {
                    assignedMorning++;
                }
                if (r.Midday!= null)
                {
                    assignedMidday++;
                }
                if (r.Evening != null)
                {
                    assignedEvening++;
                }
            }

            if (assignedMorning <= morning && assignedMidday <= midday && assignedEvening <= evening)
            {
                return true;
            }
            return false;
        }
    }
}
