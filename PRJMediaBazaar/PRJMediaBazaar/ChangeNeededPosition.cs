using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                int amount = Convert.ToInt32(this.tbAmount.Text);
                if (amount < 1 || amount > 10) throw new FormatException();
                if (!AmountCanChangeWith(amount)) throw new ArgumentOutOfRangeException();

                DialogResult dialogResult = MessageBox.Show($"Are you sure you want to set the needed amount of " +
              $"{_jobPositon} to {amount}", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                       if ( Database.ChangeNeededJobPosition(_jobPositon, amount, _day.Id))
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
                MessageBox.Show("The amount you want to set should be bigger than the assigned rows in the table");
            }
          
        }

        public bool AmountCanChangeWith(int amount)
        {
            int assignedRows = 0;
            foreach (NamesRow r in _rows)
            {
                if (r.Morning != null || r.Midday != null || r.Evening != null)
                {
                    assignedRows++;
                }
            }
            if (assignedRows < amount)
            {
                return true;
            }
            return false;
        }
    }
}
