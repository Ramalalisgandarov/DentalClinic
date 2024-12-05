using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DentalClinic
{
    public partial class Appointment : Form
    {

        private DataTable appointmentDataTable;

        public Appointment()
        {
            InitializeComponent();
            InitializeAppointmentDataTable();
        }

        private void InitializeAppointmentDataTable()
        {
            appointmentDataTable = new DataTable();
            appointmentDataTable.Columns.Add("Patient", typeof(string));
            appointmentDataTable.Columns.Add("Treatment", typeof(string));
            appointmentDataTable.Columns.Add("Date", typeof(string));
            appointmentDataTable.Columns.Add("Time", typeof(string));

            appointmentDataTable.Rows.Add("Patient", "Treatment", "Date", "Time");

            guna2DataGridView1.DataSource = appointmentDataTable;
            guna2DataGridView1.AllowUserToAddRows = false;
            guna2DataGridView1.AllowUserToResizeColumns = false;
            guna2DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
            User userForm = new User();
            this.Hide();
            userForm.ShowDialog();
            this.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            this.Hide();
            loginForm.ShowDialog();
            this.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //patient
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //treatment
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //date
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            //time
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Save
            if (string.IsNullOrWhiteSpace(comboBox1.Text) || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the patient's name.");
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox2.Text) || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the treatment.");
                return;
            }
            try
            {
                appointmentDataTable.Rows.Add(
                    comboBox1.Text,
                    comboBox2.Text,
                    dateTimePicker1.Value.ToShortDateString(),
                    dateTimePicker2.Value.ToShortDateString()
                );
                MessageBox.Show("Appointment record added successfully!");
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
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
                    appointmentDataTable.Rows[selectedIndex].Delete();
                    MessageBox.Show("Appointment record deleted successfully!");
                    ClearInputFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while deleting: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void ClearInputFields()
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }
    }
}
