using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJMediaBazaar.Logic;
using System.Windows.Forms;

namespace PRJMediaBazaar
{
    partial class ExplainDenial : Form
    {
        private DayOff dayOff;
        private AbsenceControl ab;
        private HRHome hr;
        private List<Button> buttons;
        private List<Timer> timers;
        public ExplainDenial(DayOff d, AbsenceControl ab, HRHome hr)
        {
            InitializeComponent();
            buttons = new List<Button>();
            timers = new List<Timer>();
            this.dayOff = d;
            this.ab = ab;
            this.hr = hr;
        }
        public void StatusFunction(String text, int x, int y, int width, int height, Color color)
        {
            Button newButton = new Button();
            newButton.Location = new Point(x, y);
            newButton.Width = width;
            newButton.Height = height;
            newButton.Enabled = false;
            newButton.BackColor = color;
            newButton.Text = text;
            this.Controls.Add(newButton);
            newButton.BringToFront();
            buttons.Add(newButton);
            Timer temp = new Timer();
            timers.Add(temp);
            temp.Start();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                ab.AddReason(dayOff.Employee_id, this.tbExplain.Text); // adds the reason to the db
                //hr.AddReasonForDenial(dayOff, this.tbExplain.Text); // adds the reason to the property of the request
                StatusFunction("Success!", -60, -5, 818, 28, Color.Green);
                tbExplain.Clear();
                this.Hide();

            }

            catch (Exception ex)
            {
                StatusFunction("An error occured!", -60, -5, 818, 28, Color.Red);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void ExplainDenial_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            for (int i = 0; i < timers.Count; i++)
            {
                if (timers[i].Enabled == true)
                {
                    timers[i].Enabled = false;
                    buttons[i].Visible = false;
                }
            }
        }
    }
}