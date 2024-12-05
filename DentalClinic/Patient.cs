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
    public partial class Patient : Form
    {
        private DataTable patientDataTable;
        public Patient()
        {
            InitializeComponent();
            InitializePatientDataTable();
        }

        private void InitializePatientDataTable()
        {
            patientDataTable = new DataTable();

            patientDataTable.Columns.Add("Name", typeof(string));
            patientDataTable.Columns.Add("Date of Birth", typeof(string));
            patientDataTable.Columns.Add("Phone", typeof(string));
            patientDataTable.Columns.Add("Gender", typeof(string));
            patientDataTable.Columns.Add("Treatment", typeof(string));
            patientDataTable.Columns.Add("Allergies", typeof(string));

            patientDataTable.Rows.Add("Name", "Date of Birth", "Phone", "Gender", "Treatment", "Allergies");

            guna2DataGridView1.DataSource = patientDataTable;
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
            Appointment appointmentForm = new Appointment();
            this.Hide();
            appointmentForm.ShowDialog();
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

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //name
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //dob
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //phone
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //gender
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //treatment
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //allegris
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //save
            if (string.IsNullOrWhiteSpace(textBox1.Text)) 
            { 
                MessageBox.Show("Please enter the name."); return; 
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text)) 
            {
                MessageBox.Show("Please enter the phone number."); return; 
            }
            if (string.IsNullOrWhiteSpace(comboBox1.Text) || comboBox1.SelectedIndex == -1) 
            {
                MessageBox.Show("Please select a gender."); return; 
            }
            try
            {
                patientDataTable.Rows.Add(
                    textBox1.Text,
                    dateTimePicker1.Value.ToShortDateString(),
                    textBox2.Text,
                    comboBox1.Text,
                    textBox3.Text,
                    textBox4.Text
                );
                MessageBox.Show("Patient record added successfully!");
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void ClearInputFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Now;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //delete
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = guna2DataGridView1.SelectedRows[0].Index;
                if (selectedIndex == 0)
                {
                    MessageBox.Show("The header row cannot be deleted.");
                    return;
                }
                try
                {
                    patientDataTable.Rows[selectedIndex].Delete();
                    MessageBox.Show("Patient record deleted successfully!");
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
    }
}

