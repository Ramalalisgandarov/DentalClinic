using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentalClinic
{
    public partial class User : Form
    {
        private DataTable userDataTable;

        public User()
        {
            InitializeComponent();
            InitializeUserDataTable();

        }
        private void InitializeUserDataTable()
        {
            userDataTable = new DataTable();
            userDataTable.Columns.Add("Name", typeof(string));
            userDataTable.Columns.Add("Phone", typeof(string));
            userDataTable.Columns.Add("Password", typeof(string));

            userDataTable.Rows.Add("Name", "Phone", "Password");

            guna2DataGridView1.DataSource = userDataTable;
            guna2DataGridView1.AllowUserToAddRows = false;
            guna2DataGridView1.AllowUserToResizeColumns = false;
            guna2DataGridView1.ColumnHeadersVisible = true;

            foreach (DataGridViewColumn column in guna2DataGridView1.Columns)
            {
                column.ReadOnly = true;
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {
            Patient patientForm = new Patient();
            this.Hide();
            patientForm.ShowDialog();
            this.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Treatment treatmentForm = new Treatment();
            this.Hide();
            treatmentForm.ShowDialog();
            this.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Prescription prescriptionForm = new Prescription();
            this.Hide();
            prescriptionForm.ShowDialog();
            this.Show();
        }
        private void label7_Click(object sender, EventArgs e)
        {
            Appointment appointmentForm = new Appointment();
            this.Hide();
            appointmentForm.ShowDialog();
            this.Show();
        }


        private void label9_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            this.Hide();
            loginForm.ShowDialog();
            this.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //user
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //password
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //phone
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Save
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter the name.");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please enter the phone number.");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Please enter the password.");
                return;
            }
            try
            {
                userDataTable.Rows.Add(
                    textBox2.Text,
                    textBox3.Text,
                    textBox4.Text
                );
                MessageBox.Show("User record added successfully!");
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the record: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Delete
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = guna2DataGridView1.SelectedRows[0].Index;
                if (selectedIndex == 0)
                {
                    MessageBox.Show("The first row cannot be deleted.");
                    return;
                }
                try
                {
                    userDataTable.Rows[selectedIndex].Delete();
                    MessageBox.Show("User record deleted successfully!");
                    ClearInputFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while deleting the record: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }
        private void ClearInputFields()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
