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
    public partial class Prescription : Form
    {
        private DataTable prescriptionDataTable;

        public Prescription()
        {
            InitializeComponent();
            InitializePrescriptionDataTable();

        }

        private void InitializePrescriptionDataTable()
        {
            prescriptionDataTable = new DataTable();
            prescriptionDataTable.Columns.Add("Name", typeof(string));
            prescriptionDataTable.Columns.Add("Patient", typeof(string));
            prescriptionDataTable.Columns.Add("Treatment", typeof(string));
            prescriptionDataTable.Columns.Add("Cost", typeof(string));
            prescriptionDataTable.Columns.Add("Medicines", typeof(string));
            prescriptionDataTable.Columns.Add("Quantity", typeof(string));

            prescriptionDataTable.Rows.Add("Name", "Patient", "Treatment","Cost","Medicines","Quantity");

            guna2DataGridView1.DataSource = prescriptionDataTable;
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
            Appointment appointmentForm = new Appointment();
            this.Hide();
            appointmentForm.ShowDialog();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //name
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //patient
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //treatment
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //cost
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //medicines
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //quantity
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Save
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter the name.");
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox1.Text) || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the patient.");
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox2.Text) || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the treatment.");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Please enter a valid cost.");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please enter the medicines.");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Please enter a valid quantity.");
                return;
            }
            try
            {
                prescriptionDataTable.Rows.Add(
                    textBox1.Text,
                    comboBox1.Text,
                    comboBox2.Text,
                    textBox6.Text,
                    textBox3.Text,
                    textBox4.Text
                );
                MessageBox.Show("Prescription record added successfully!");
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
                    prescriptionDataTable.Rows[selectedIndex].Delete();
                    MessageBox.Show("Prescription record deleted successfully!");
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
            textBox1.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            textBox6.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
