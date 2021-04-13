using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRJMediaBazaar.Logic;

namespace PRJMediaBazaar
{
    partial class EditNote : Form
    {
        private Employee thisEmployee;
        private EmployeeControl ec;
        private HRHome hr;
        public EditNote(Employee thisEmployee,EmployeeControl ec,HRHome hr)
        {
            InitializeComponent();
            this.thisEmployee = thisEmployee;
            this.ec = ec;
            this.hr = hr;
        }

        private void EditNote_Load(object sender, EventArgs e)
        {
            this.tbNote.Text = thisEmployee.Note;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                ec.UpdateNote(this.tbNote.Text, thisEmployee.Email);
                hr.AddNoteToEmployee(thisEmployee, this.tbNote.Text);
                MessageBox.Show("Success!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured!" + ex.ToString());
            }
            
        }
    }
}
