namespace ProPax
{
    partial class frmWizard
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEventBrowse = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEventFileName = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvClassFiles = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtClassFileName = new System.Windows.Forms.TextBox();
            this.btnClassBrowse = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassFiles)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Event";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Open the event file you want to get pro results for.";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnEventBrowse);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtEventFileName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(511, 94);
            this.panel1.TabIndex = 2;
            // 
            // btnEventBrowse
            // 
            this.btnEventBrowse.Location = new System.Drawing.Point(278, 55);
            this.btnEventBrowse.Name = "btnEventBrowse";
            this.btnEventBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnEventBrowse.TabIndex = 1;
            this.btnEventBrowse.Text = "Browse..";
            this.btnEventBrowse.UseVisualStyleBackColor = true;
            this.btnEventBrowse.Click += new System.EventHandler(this.btnEventBrowse_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Event file:";
            // 
            // txtEventFileName
            // 
            this.txtEventFileName.Location = new System.Drawing.Point(63, 57);
            this.txtEventFileName.Name = "txtEventFileName";
            this.txtEventFileName.Size = new System.Drawing.Size(203, 20);
            this.txtEventFileName.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 254);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(511, 48);
            this.panel2.TabIndex = 3;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(32, 13);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvClassFiles);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 94);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(511, 160);
            this.panel3.TabIndex = 4;
            // 
            // dgvClassFiles
            // 
            this.dgvClassFiles.AllowUserToAddRows = false;
            this.dgvClassFiles.AllowUserToDeleteRows = false;
            this.dgvClassFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvClassFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClassFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClassFiles.Location = new System.Drawing.Point(0, 39);
            this.dgvClassFiles.MultiSelect = false;
            this.dgvClassFiles.Name = "dgvClassFiles";
            this.dgvClassFiles.ReadOnly = true;
            this.dgvClassFiles.Size = new System.Drawing.Size(511, 84);
            this.dgvClassFiles.TabIndex = 3;
            this.dgvClassFiles.SelectionChanged += new System.EventHandler(this.dgvClassFiles_SelectionChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(511, 39);
            this.panel5.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Select Class Definition";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(300, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Select or browse for the class definition file used for this event.";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtClassFileName);
            this.panel4.Controls.Add(this.btnClassBrowse);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 123);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(511, 37);
            this.panel4.TabIndex = 8;
            // 
            // txtClassFileName
            // 
            this.txtClassFileName.Location = new System.Drawing.Point(63, 11);
            this.txtClassFileName.Name = "txtClassFileName";
            this.txtClassFileName.Size = new System.Drawing.Size(203, 20);
            this.txtClassFileName.TabIndex = 6;
            // 
            // btnClassBrowse
            // 
            this.btnClassBrowse.Location = new System.Drawing.Point(278, 9);
            this.btnClassBrowse.Name = "btnClassBrowse";
            this.btnClassBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnClassBrowse.TabIndex = 5;
            this.btnClassBrowse.Text = "Browse..";
            this.btnClassBrowse.UseVisualStyleBackColor = true;
            this.btnClassBrowse.Click += new System.EventHandler(this.btnClassBrowse_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Class file:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(113, 13);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnCancel);
            this.panel6.Controls.Add(this.btnOk);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(308, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(203, 48);
            this.panel6.TabIndex = 2;
            // 
            // frmWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 302);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(519, 329);
            this.Name = "frmWizard";
            this.Text = "Pro Pax Wizard";
            this.Load += new System.EventHandler(this.frmWizard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassFiles)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEventFileName;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnEventBrowse;
        private System.Windows.Forms.DataGridView dgvClassFiles;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtClassFileName;
        private System.Windows.Forms.Button btnClassBrowse;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel6;
    }
}