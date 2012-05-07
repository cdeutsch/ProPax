using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProPax
{
    public partial class frmWizard : Form
    {
        public string EventFileName
        {
            get
            {
                return txtEventFileName.Text;
            }
        }


        public string ClassFileName
        {
            get
            {
                return txtClassFileName.Text;
            }
        }

        public frmWizard()
        {
            InitializeComponent();

            dgvClassFiles.DataSource = FormatForDataSource(Axware.GetDefinitionFiles(""));
            DefaultClassSelection();
        }

        private void frmWizard_Load(object sender, EventArgs e)
        {
            
        }

        private void btnEventBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "AXWare Events (*.st1)|*.st1|AXWare Events (*.st*)|*.st*|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtEventFileName.Text = openFileDialog1.FileName;

                //try to find a .def file in the event directory.
                dgvClassFiles.DataSource = FormatForDataSource(Axware.GetDefinitionFiles(new System.IO.FileInfo(openFileDialog1.FileName).DirectoryName));
                DefaultClassSelection();
            }
        }

        private void btnClassBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "AXWare Definitions (*.def)|*.def|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtClassFileName.Text = openFileDialog1.FileName;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private List<FormattedFileInfo> FormatForDataSource(List<System.IO.FileInfo> Files)
        {
            return (from ff in Files
                    select new FormattedFileInfo { FullName = ff.FullName, Length = ff.Length, CreationTime = ff.CreationTime }).ToList();
        }

        private void DefaultClassSelection()
        {
            if (dgvClassFiles.Rows.Count > 0)
            {
                //default by selecting a row.
                dgvClassFiles.Rows[0].Selected = true;

                //txtClassFileName.Text = ((FormattedFileInfo)dgvClassFiles.Rows[0].DataBoundItem).FullName;
            }
        }

        private void dgvClassFiles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClassFiles.SelectedRows.Count > 0)
            {
                txtClassFileName.Text = ((FormattedFileInfo)dgvClassFiles.Rows[dgvClassFiles.SelectedRows[0].Index].DataBoundItem).FullName;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }
    }

    public class FormattedFileInfo
    {
        public string FullName { get; set; }
        public long Length { get; set; }
        public DateTime CreationTime { get; set; }
    }
}


