namespace CyberSecurity_CSV_Analysis
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnFreq = new System.Windows.Forms.Button();
            this.btnResetCSV = new System.Windows.Forms.Button();
            this.btnSortDesc = new System.Windows.Forms.Button();
            this.btnSortAsc = new System.Windows.Forms.Button();
            this.btnSelection = new System.Windows.Forms.Button();
            this.btnShowSelection = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.11499F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.88501F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(776, 487);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(770, 422);
            this.dataGridView1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnFreq);
            this.flowLayoutPanel1.Controls.Add(this.btnResetCSV);
            this.flowLayoutPanel1.Controls.Add(this.btnSortDesc);
            this.flowLayoutPanel1.Controls.Add(this.btnSortAsc);
            this.flowLayoutPanel1.Controls.Add(this.btnSelection);
            this.flowLayoutPanel1.Controls.Add(this.btnShowSelection);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(770, 52);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnFreq
            // 
            this.btnFreq.Location = new System.Drawing.Point(3, 3);
            this.btnFreq.Name = "btnFreq";
            this.btnFreq.Size = new System.Drawing.Size(121, 23);
            this.btnFreq.TabIndex = 0;
            this.btnFreq.Text = "Group by Frequency";
            this.btnFreq.UseVisualStyleBackColor = true;
            this.btnFreq.Click += new System.EventHandler(this.btnFreq_Click);
            // 
            // btnResetCSV
            // 
            this.btnResetCSV.Location = new System.Drawing.Point(130, 3);
            this.btnResetCSV.Name = "btnResetCSV";
            this.btnResetCSV.Size = new System.Drawing.Size(121, 23);
            this.btnResetCSV.TabIndex = 3;
            this.btnResetCSV.Text = "Reset Data";
            this.btnResetCSV.UseVisualStyleBackColor = true;
            this.btnResetCSV.Visible = false;
            this.btnResetCSV.Click += new System.EventHandler(this.resetCSV_Click);
            // 
            // btnSortDesc
            // 
            this.btnSortDesc.Location = new System.Drawing.Point(257, 3);
            this.btnSortDesc.Name = "btnSortDesc";
            this.btnSortDesc.Size = new System.Drawing.Size(121, 23);
            this.btnSortDesc.TabIndex = 1;
            this.btnSortDesc.Text = "Sort H -> L";
            this.btnSortDesc.UseVisualStyleBackColor = true;
            this.btnSortDesc.Click += new System.EventHandler(this.btnSortDesc_Click);
            // 
            // btnSortAsc
            // 
            this.btnSortAsc.Location = new System.Drawing.Point(384, 3);
            this.btnSortAsc.Name = "btnSortAsc";
            this.btnSortAsc.Size = new System.Drawing.Size(121, 23);
            this.btnSortAsc.TabIndex = 2;
            this.btnSortAsc.Text = "Sort L -> H";
            this.btnSortAsc.UseVisualStyleBackColor = true;
            this.btnSortAsc.Click += new System.EventHandler(this.btnSortAsc_Click);
            // 
            // btnSelection
            // 
            this.btnSelection.Location = new System.Drawing.Point(511, 3);
            this.btnSelection.Name = "btnSelection";
            this.btnSelection.Size = new System.Drawing.Size(121, 23);
            this.btnSelection.TabIndex = 4;
            this.btnSelection.Text = "Select Cell";
            this.btnSelection.UseVisualStyleBackColor = true;
            this.btnSelection.Click += new System.EventHandler(this.btnSelection_Click);
            // 
            // btnShowSelection
            // 
            this.btnShowSelection.Location = new System.Drawing.Point(638, 3);
            this.btnShowSelection.Name = "btnShowSelection";
            this.btnShowSelection.Size = new System.Drawing.Size(121, 23);
            this.btnShowSelection.TabIndex = 5;
            this.btnShowSelection.Text = "Show Matching Cells";
            this.btnShowSelection.UseVisualStyleBackColor = true;
            this.btnShowSelection.Visible = false;
            this.btnShowSelection.Click += new System.EventHandler(this.btnShowSelection_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 511);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Main";
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnFreq;
        private System.Windows.Forms.Button btnSortDesc;
        private System.Windows.Forms.Button btnSortAsc;
        private System.Windows.Forms.Button btnResetCSV;
        private System.Windows.Forms.Button btnSelection;
        private System.Windows.Forms.Button btnShowSelection;
    }
}