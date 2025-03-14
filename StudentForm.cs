using Castillo_PaulNazarene_GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Castillo_PaulNazarene_GUI
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
            // Mock Student Data
            StudentNameLabel.Text = "Paul Nazarene Castillo";
            StudentAgeLabel.Text = "22";
            StudentAddressLabel.Text = "Bayambang Pangasinan";
            StudentContactLabel.Text = "09123456789";
            StudentEmailLabel.Text = "email@sample.com";
            StudentCourseYearLabel.Text = "BSIT Third";
            ParentNameLabel.Text = "Paul Castillo";
            ParentContactLabel.Text = "09123456789";
            HobbiesLabel.Text = "Gaming";
            NicknameLabel.Text = "Naz";
        }

        private void AddImageBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Image functionality is not implemented.", "Feature Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ChangeImageBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Change Image functionality is not implemented.", "Feature Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EditUpdateBtn_Click(object sender, EventArgs e)
        {
            EditForm editForm = new EditForm(this);
            this.Hide();
            editForm.Show();
        }

    }
}