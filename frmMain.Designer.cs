namespace ProPax
{
    partial class frmMain
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
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importRTPPAXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runWizardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbSplit2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMaxRuns = new System.Windows.Forms.Label();
            this.cmbSplit1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbIndexedClass = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lblClub = new System.Windows.Forms.Label();
            this.txtClub = new System.Windows.Forms.TextBox();
            this.lblEvent = new System.Windows.Forms.Label();
            this.txtEvent = new System.Windows.Forms.TextBox();
            this.mnuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlFilters.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.runWizardToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(952, 24);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openEventToolStripMenuItem,
            this.importToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openEventToolStripMenuItem
            // 
            this.openEventToolStripMenuItem.Name = "openEventToolStripMenuItem";
            this.openEventToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.openEventToolStripMenuItem.Text = "Open Event";
            this.openEventToolStripMenuItem.Click += new System.EventHandler(this.openEventToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importRTPPAXToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // importRTPPAXToolStripMenuItem
            // 
            this.importRTPPAXToolStripMenuItem.Name = "importRTPPAXToolStripMenuItem";
            this.importRTPPAXToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.importRTPPAXToolStripMenuItem.Text = "Import RTP/PAX";
            this.importRTPPAXToolStripMenuItem.Click += new System.EventHandler(this.importRTPPAXToolStripMenuItem_Click);
            // 
            // runWizardToolStripMenuItem
            // 
            this.runWizardToolStripMenuItem.Name = "runWizardToolStripMenuItem";
            this.runWizardToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.runWizardToolStripMenuItem.Text = "Run Wizard";
            this.runWizardToolStripMenuItem.Click += new System.EventHandler(this.runWizardToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 167);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(952, 274);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // pnlFilters
            // 
            this.pnlFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilters.Controls.Add(this.panel2);
            this.pnlFilters.Controls.Add(this.panel1);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(0, 24);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(952, 143);
            this.pnlFilters.TabIndex = 2;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(183, 58);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(108, 23);
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "Export To HTML";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbSplit2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lblMaxRuns);
            this.panel2.Controls.Add(this.cmbSplit1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(737, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(213, 141);
            this.panel2.TabIndex = 12;
            // 
            // cmbSplit2
            // 
            this.cmbSplit2.FormattingEnabled = true;
            this.cmbSplit2.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50"});
            this.cmbSplit2.Location = new System.Drawing.Point(155, 115);
            this.cmbSplit2.Name = "cmbSplit2";
            this.cmbSplit2.Size = new System.Drawing.Size(43, 21);
            this.cmbSplit2.TabIndex = 8;
            this.cmbSplit2.SelectedIndexChanged += new System.EventHandler(this.cmbSplit2_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Total Number of Runs:";
            // 
            // lblMaxRuns
            // 
            this.lblMaxRuns.AutoSize = true;
            this.lblMaxRuns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxRuns.Location = new System.Drawing.Point(129, 92);
            this.lblMaxRuns.Name = "lblMaxRuns";
            this.lblMaxRuns.Size = new System.Drawing.Size(14, 13);
            this.lblMaxRuns.TabIndex = 10;
            this.lblMaxRuns.Text = "0";
            // 
            // cmbSplit1
            // 
            this.cmbSplit1.FormattingEnabled = true;
            this.cmbSplit1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50"});
            this.cmbSplit1.Location = new System.Drawing.Point(50, 115);
            this.cmbSplit1.Name = "cmbSplit1";
            this.cmbSplit1.Size = new System.Drawing.Size(43, 21);
            this.cmbSplit1.TabIndex = 6;
            this.cmbSplit1.SelectedIndexChanged += new System.EventHandler(this.cmbSplit1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(113, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Split 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Split 1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.txtEvent);
            this.panel1.Controls.Add(this.lblEvent);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtClub);
            this.panel1.Controls.Add(this.cmbClass);
            this.panel1.Controls.Add(this.lblClub);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbIndexedClass);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 141);
            this.panel1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Class";
            // 
            // cmbClass
            // 
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(42, 115);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(76, 21);
            this.cmbClass.TabIndex = 0;
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filters";
            // 
            // cmbIndexedClass
            // 
            this.cmbIndexedClass.FormattingEnabled = true;
            this.cmbIndexedClass.Location = new System.Drawing.Point(214, 115);
            this.cmbIndexedClass.Name = "cmbIndexedClass";
            this.cmbIndexedClass.Size = new System.Drawing.Size(76, 21);
            this.cmbIndexedClass.TabIndex = 3;
            this.cmbIndexedClass.SelectedIndexChanged += new System.EventHandler(this.cmbIndexedClass_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(135, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Indexed Class";
            // 
            // lblClub
            // 
            this.lblClub.AutoSize = true;
            this.lblClub.Location = new System.Drawing.Point(5, 7);
            this.lblClub.Name = "lblClub";
            this.lblClub.Size = new System.Drawing.Size(31, 13);
            this.lblClub.TabIndex = 14;
            this.lblClub.Text = "Club:";
            // 
            // txtClub
            // 
            this.txtClub.Location = new System.Drawing.Point(42, 4);
            this.txtClub.Name = "txtClub";
            this.txtClub.Size = new System.Drawing.Size(249, 20);
            this.txtClub.TabIndex = 15;
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.Location = new System.Drawing.Point(5, 35);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(38, 13);
            this.lblEvent.TabIndex = 16;
            this.lblEvent.Text = "Event:";
            // 
            // txtEvent
            // 
            this.txtEvent.Location = new System.Drawing.Point(42, 32);
            this.txtEvent.Name = "txtEvent";
            this.txtEvent.Size = new System.Drawing.Size(249, 20);
            this.txtEvent.TabIndex = 17;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 441);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = this.mnuMain;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "frmMain";
            this.Text = "Pro Pax";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlFilters.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importRTPPAXToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.ToolStripMenuItem openEventToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbIndexedClass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSplit1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbSplit2;
        private System.Windows.Forms.ToolStripMenuItem runWizardToolStripMenuItem;
        private System.Windows.Forms.Label lblMaxRuns;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox txtEvent;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.TextBox txtClub;
        private System.Windows.Forms.Label lblClub;
    }
}

