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


    public partial class Treatment : Form
    {
        private DataTable treatmentDataTable;
        public Treatment()
        {
            InitializeComponent();
            InitializeTreatmentDataTable();

        }
        private void InitializeTreatmentDataTable()
        {
            treatmentDataTable = new DataTable();
            treatmentDataTable.Columns.Add("Treatment Name", typeof(string));
            treatmentDataTable.Columns.Add("Cost", typeof(string));
            treatmentDataTable.Columns.Add("Description", typeof(string));

            treatmentDataTable.Rows.Add("Treatment Name", "Cost", "Description");

            guna2DataGridView1.DataSource = treatmentDataTable;
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
            Appointment appointmentForm = new Appointment();
            this.Hide();
            appointmentForm.ShowDialog();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //treatment name
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //cost
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //description
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //save
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter the treatment name.");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter a valid cost.");
                return;
            }
            try
            {
                treatmentDataTable.Rows.Add(
                    textBox1.Text,
                    textBox2.Text,
                    textBox4.Text
                );
                MessageBox.Show("Treatment record added successfully!");
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
                    MessageBox.Show("The header row cannot be deleted.");
                    return;
                }

                try
                {
                    treatmentDataTable.Rows[selectedIndex].Delete();
                    MessageBox.Show("Treatment record deleted successfully!");
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
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
