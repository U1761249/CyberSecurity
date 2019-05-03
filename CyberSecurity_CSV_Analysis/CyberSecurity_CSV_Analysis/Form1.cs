
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CyberSecurity_CSV_Analysis
{
    public partial class SelectionForm : Form
    {
    
        public SelectionForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Open the file dialog to allow the user to select a file.
        /// </summary>
        /// <param name="sender"></param><param name="e"></param> Standard objects used to detect the user action.
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "CSV files (CSV)|*.CSV;*.csv";

            if (OFD.ShowDialog() == DialogResult.OK) { 
                tbDirectory.Clear();
                tbDirectory.Text = OFD.FileName;
                
                }
        }

        /// <summary>
        /// Allow the user to load the selected file into a DataGridView on another form.
        /// Check that the file exists.
        /// Create a new instance of the form with the directory as a parameter.
        /// Hide the current form.
        /// </summary>
        /// <param name="sender"></param><param name="e"></param> Standard objects used to detect the user action.
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(tbDirectory.Text)) { 
                lblLoading.Visible = true;
                var frm = new Main(tbDirectory.Text);
                frm.Location = this.Location;
                frm.StartPosition = FormStartPosition.Manual;
                frm.FormClosing += delegate { this.Show(); };
                frm.Show();
                this.Hide(); 
            }  
            else { MessageBox.Show("You need to select a valid file first.");}
    }

        /// <summary>
        /// Detect when the form is closed, confirm the action, and perform a safe close.
        /// </summary>
        /// <param name="sender"></param><param name="e"></param> Standard objects used to detect the user action.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("This will close down the whole application. Confirm?", "Close Application", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
