using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CyberSecurity_CSV_Analysis
{
    public partial class Main : Form
    {

        DataTable table = new DataTable();
        bool cellSelection = false;
        string dataGridSource = "table";

        public Main(string directory)
        {
            InitializeComponent();
            loadCSV(directory);
        }

        /// <summary>
        /// Initialize the DataGridView Contents based on the file provided by the user.
        /// Create a file containing all of the data in the file. 
        /// Get the heading of the columns and add them to the table (Create names if none are provided).
        /// Add the data to the table.
        /// Set the DataGridView to show the table data.
        /// </summary>
        /// <param name="directory"></param> the directory of the file to be loaded. Given from Form1.
        private void loadCSV(string directory)
        {
            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.Turquoise;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = BackColor = Color.Teal;

            char delimiter = ',';
            string fileName = directory;

            StreamReader sr = new StreamReader(fileName);
            string[] headers = sr.ReadLine().Split(delimiter);
            string allData = sr.ReadToEnd();
            string[] rows = allData.Split("\r".ToArray());
                                        
            // Add the headings to the columns.
            try
            {   // Try to add the first row as table headings.
                table.Columns.Add("Row");
                setPrimary(table);
                for (int i = 0; i < headers.Count(); i++)
                {
                    table.Columns.Add(headers[i].ToString());
                }
            }
            catch (DuplicateNameException e)
            {
                table.Reset();    // Clear the dataset and add the table again

                table.Columns.Add("Row", typeof(int)).SetOrdinal(0);
                setPrimary(table);

                // Create nondescript headings/
                for (int i = 0; i < rows[0].Length; i++)
                {
                    string name = "Column " + (i + 1);
                    table.Columns.Add(name);
                }
            }

            int rowNumber = 1;

            // Populate the table with the data from the StreamReader.
            foreach (string r in rows)
            {
                string[] items = r.Split(delimiter.ToString().ToArray());
                if (items[0].ToString().Length != 0)
                {
                    ArrayList rowData = new ArrayList();
                    rowData.Add(rowNumber.ToString());
                    rowNumber++;
                    for (int i = 0; i < items.Length-1; i++)
                    {
                        rowData.Add(items[i]);
                    }

                    table.Rows.Add(rowData.ToArray());
                }
            }

            // Remove all blank columns.
            foreach (var column in table.Columns.Cast<DataColumn>().ToArray())  // Clear empty columns
            {
                if (table.AsEnumerable().All(dr => dr.IsNull(column)))
                    table.Columns.Remove(column);
            }

            table.AcceptChanges();

            UpdateGridView(table);

        }

        /// <summary>
        /// Update the contents of the DataGridView to show the data passed in by the program.
        /// </summary>
        /// <param name="source"></param> The Table to be displayed.
        private void UpdateGridView(DataTable source)
        {
            //Reset the grid view
            this.dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            for (int i = 0; i < dataGridView1.Columns.Count; i++) { dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic; }

            // Add the data to the grid view
            this.dataGridView1.DataSource = source.DefaultView;  // Set the datagrid to the dataset data
            for (int i = 0; i < dataGridView1.Columns.Count; i++) { dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable; }
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
            this.dataGridView1.MultiSelect = false;
            dataGridView1.Refresh();
            dataGridSource = source.ToString();
        }

        /// <summary>
        /// Return the contents of the DataGridView as a DataTable to be used elsewhere.
        /// </summary>
        /// <returns></returns> The DataGridView as a DataTable to be used.
        private DataTable GridToTable()
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                dt.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }
            return dt;
        }

        /// <summary>
        /// Detect when the form is closed, confirm the action, and perform a safe close.
        /// </summary>
        /// <param name="sender"></param><param name="e"></param> Standard objects used to detect the user action.
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("This will close down the whole application. Confirm?", "Close Application", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Dispose();

                try { Environment.Exit(0); } // Can take a short time to close without exceptions.
                catch (Exception) { }

            }
            else
            {
                e.Cancel = true;

            }
        }

        /// <summary>
        /// Perform the main execution when the user presses the Frequency button.
        /// Get the selected column's index.
        /// Create a new table with the Row number, the selected column, Frequency and Percentage.
        /// Delete all rows with duplicate values in column 1 (adding 1 to the frequency each time).
        /// Update the DataGridView.
        /// </summary>
        /// <param name="sender"></param><param name="e"></param> Standard objects used to detect the user action.
        private void btnFreq_Click(object sender, EventArgs e)
        {
            int selectedColumn = this.dataGridView1.CurrentCell.ColumnIndex;
            if (selectedColumn == 0)
            {
                MessageBox.Show("You must select a data column first (not row number).");
            }
            else
            {
                MessageBox.Show("Some columns may take longer to process than others.");
                DataTable freqTable = new DataTable();
                DataTable curentData = new DataTable();
                if (dataGridSource == "table") { curentData = table; }  // Use "table" if it is the DataSource
                else { curentData = GridToTable(); }                    // Create a new table if "table" is not the DataSource
                
                // Setup the columns of the freqTable.
                freqTable.Columns.Add("Row");
                setPrimary(freqTable);
                freqTable.Columns.Add(curentData.Columns[selectedColumn].ColumnName, curentData.Columns[selectedColumn].DataType);
                DataColumn freq = freqTable.Columns.Add("Frequency", typeof(Int32));
                freq.ReadOnly = false;
                DataColumn per = freqTable.Columns.Add("Percent", typeof(string));
                per.ReadOnly = false;

                // Populate FreqTable with all of the rows from the source table.
                for (int i = 0; i < curentData.Rows.Count; i++)
                {
                    try { freqTable.Rows.Add(curentData.Rows[i][0], curentData.Rows[i][selectedColumn], 1); }
                    catch (Exception) { break; }
                    

                }

                // Perform calculation functions on the table.
                GroupRows(freqTable);
                UpdatePercent(freqTable);
                UpdateGridView(freqTable);

                // Change the display to reflect the data change.
                btnFreq.Visible = false;
                btnResetCSV.Visible = true;
            }
        }

        /// <summary>
        /// Calculate the percentage of each row's frequency compared to the whole.
        /// </summary>
        /// <param name="freqTable"></param> The table containing all of the frequency data.
        private void UpdatePercent(DataTable freqTable)
        {

            foreach (DataRow row in freqTable.Rows)
            {
                decimal freq = (int)row["Frequency"];
                decimal count = table.Rows.Count;
                decimal perc = ((freq / count));
                row["Percent"] = perc.ToString("0.00%");
            }
        }

        /// <summary>
        /// Group all rows where the column 1 data matches.
        /// For each row, check the row above it.
        /// If the row is unique continue.
        /// Else add 1 to the above row's frequency and remove the current row.
        /// </summary>
        /// <param name="freqTable"></param> The table containing all of the frequency data.
        private void GroupRows(DataTable freqTable)
        {

            int rowCount = freqTable.Rows.Count;
            if (rowCount > 1)
            {
                for (int i = 1; i < rowCount; i++) // row 0 will always be unique
                {
                    for (int r = 0; r < i; r++) // All unique rows above the current row being checked
                    {

                        var currentRow = freqTable.Rows[i].ItemArray;
                        var nextRow = freqTable.Rows[r].ItemArray;

                        if (currentRow[1].ToString().Equals(nextRow[1].ToString())) // If the row is non-unique, remove it and increment the frequency of the first occurrence.
                        {
                            freqTable.Rows.RemoveAt(i);
                            freqTable.Rows[r][2] = (int)freqTable.Rows[r][2] + 1;
                            i--;
                            rowCount--;
                            break;
                        }
                    }

                }
            }
        }


        /// <summary>
        /// Set the primary key value of the provided table to the "Rows" column.
        /// </summary>
        /// <param name="table"></param> The table which needs to be set.
        private void setPrimary(DataTable table)
        {
            DataColumn[] primary = new DataColumn[1];
            primary[0] = table.Columns["Row"];
            table.PrimaryKey = primary;
        }

        /// <summary>
        /// Change the data in the DataGridView to display the contents of "table".
        /// </summary>
        /// <param name="sender"></param><param name="e"></param> Standard objects used to detect the user action.
        private void resetCSV_Click(object sender, EventArgs e)
        {
            UpdateGridView(table);
            btnFreq.Visible = true;
            btnResetCSV.Visible = false;

        }

        /// <summary>
        /// Alter the properties of the DataGridView to allow for sorting.
        /// Sort based on the provided parameters.
        /// </summary>
        /// <param name="index"></param> The Index of the selected column.
        /// <param name="sort"></param> The type of sort to be used (ASC or DESC).
        private void SortColumn(int index, string sort)
        {
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            for (int i = 0; i < dataGridView1.Columns.Count; i++) { dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic; }

            if (sort == "Ascending") { dataGridView1.Sort(dataGridView1.Columns[index], ListSortDirection.Ascending); }
            else if (sort == "Descending") { dataGridView1.Sort(dataGridView1.Columns[index], ListSortDirection.Descending); }
            else { throw new InvalidOperationException(); }


            for (int i = 0; i < dataGridView1.Columns.Count; i++) { dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable; }
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
            this.dataGridView1.MultiSelect = false;
        }

        /// <summary>
        /// Detect if the user wants to sort the selected column Descending.
        /// </summary>
        /// <param name="sender"></param><param name="e"></param> Standard objects used to detect the user action.
        private void btnSortDesc_Click(object sender, EventArgs e)
        {
            int selectedColumn = this.dataGridView1.CurrentCell.ColumnIndex;
            if (selectedColumn == 0)
            {
                MessageBox.Show("You must select a data column first (not row number).");
            }
            else
            { SortColumn(selectedColumn, "Descending"); }
        }

        /// <summary>
        /// Detect if the user wants to sort the selected column Ascending.
        /// </summary>
        /// <param name="sender"></param><param name="e"></param> Standard objects used to detect the user action.
        private void btnSortAsc_Click(object sender, EventArgs e)
        {
            int selectedColumn = this.dataGridView1.CurrentCell.ColumnIndex;
            if (selectedColumn == 0)
            {
                MessageBox.Show("You must select a data column first (not row number).");
            }
            else
            { SortColumn(selectedColumn, "Ascending"); }
        }

        /// <summary>
        /// Detect if the user wants to toggle Cell or Column selection.
        /// </summary>
        /// <param name="sender"></param><param name="e"></param> Standard objects used to detect the user action.
        private void btnSelection_Click(object sender, EventArgs e)
        {
            if (!cellSelection)
            { // Change to select single cell
                btnShowSelection.Visible = true;
                this.dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
                this.btnSelection.Text = "Select Column";
                cellSelection = !cellSelection;
            }
            else
            { // Change to select whole column
                btnShowSelection.Visible = false;
                this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
                this.btnSelection.Text = "Select Cell";
                cellSelection = !cellSelection;
            }
        }

        /// <summary>
        /// Take the data at the selected cell.
        /// Remove any row where the data in the selected column doesn't match the selection.
        /// </summary>
        /// <param name="sender"></param><param name="e"></param> Standard objects used to detect the user action.
        private void btnShowSelection_Click(object sender, EventArgs e)
        {
            int selectedColumn = this.dataGridView1.CurrentCell.ColumnIndex;
            int selectedRow = this.dataGridView1.CurrentCell.RowIndex;
            if (selectedColumn == 0)
            {
                MessageBox.Show("You must select a data cell first (not row number).");
            }
            else
            {
                MessageBox.Show("This may take up to a few minutes.");

                DataTable refinedTable = table.Copy();
                
                int rowCount = refinedTable.Rows.Count - 1;
                for (int i = rowCount; i >= 0; i--)
                {
                    var currentRow = refinedTable.Rows[i].ItemArray;
                    var filterRow = refinedTable.Rows[selectedRow].ItemArray;

                    if (!currentRow[selectedColumn].ToString().Equals(filterRow[selectedColumn].ToString()))
                    {
                        refinedTable.Rows.RemoveAt(i);

                        
                    }
                }
                UpdateGridView(refinedTable);
                this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
                this.btnSelection.Text = "Select Cell";
                cellSelection = !cellSelection;
            }
        }
    }
}