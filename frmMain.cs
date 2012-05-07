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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        protected RTP _rtp = null;
        protected Competition _cc = null;

        protected frmWizard frmWiz = null;

        protected string EventFilename = null;
        protected int gvRowNum = 1;

        private void Form1_Load(object sender, EventArgs e)
        {
            //create wizard form once.
            frmWiz = new frmWizard();

            
            //hide filters by default (they'll be displayed when ShowCompetition is called)
            pnlFilters.Visible = false;

            //default drop downs.
            cmbSplit1.SelectedIndex = 3;
            cmbSplit2.SelectedIndex = 3;

            //show the wizard.
            runWizardToolStripMenuItem_Click(this, null);

            //CDEUTSCH: no longer doing it this way.
            ////attempt to automatically import the Pax definition.
            //_rtp = Axware.AutoImport();
            //if (_rtp != null)
            //{
            //    ShowRTP();
            //}
            //else
            //{
            //    MessageBox.Show("Could not file RTP/PAX definition file. \nYou'll need to Import the definition manually.");
            //}
        }

        private void ShowRTP()
        {
            //hide filter.
            pnlFilters.Visible = false;

            dataGridView1.DataSource = _rtp.ClassIndexes;
        }

        private void ShowCompetition()
        {
            //default splits based on number of runs.
            int iMaxRuns = _cc.MaxRuns();
            if (iMaxRuns > 0) 
            {
                int iSplit2 = iMaxRuns / 2;
                int iSplit1 = iMaxRuns - iSplit2;

                cmbSplit1.SelectedIndex = iSplit1;
                cmbSplit2.SelectedIndex = iSplit2;
            }
            //display max runs
            lblMaxRuns.Text = iMaxRuns.ToString();

            List<string> classes = (from ci in _rtp.ClassIndexes 
                                      select ci.ClassAbbreviation).ToList();
            classes.Insert(0, "");
            classes.Insert(0, "Show All");
            cmbClass.DataSource = classes;

            List<string> indexedclasses = _rtp.IndexedClassPrefixes.ToList();
            indexedclasses.Insert(0, "");
            indexedclasses.Insert(0, "Show All");
            cmbIndexedClass.DataSource = indexedclasses;

            pnlFilters.Visible = true;

            ShowCompetitionGrid();
        }

        private void ShowCompetitionGrid()
        {
            DataView dv = _cc.ResultsToSortedDataView();
                
            if (cmbIndexedClass.SelectedValue.ToString() != "Show All")
            {
                dv.RowFilter = string.Format("[Indexed Class] = '{0}'", cmbIndexedClass.SelectedValue);                
            }
            if (cmbClass.SelectedValue.ToString() != "Show All")
            {
                if (dv.RowFilter.Length > 0)
                {
                    dv.RowFilter += " AND " + string.Format("[Class] = '{0}'", cmbClass.SelectedValue);
                }
                else
                {
                    dv.RowFilter = string.Format("[Class] = '{0}'", cmbClass.SelectedValue);
                }
            }

            dataGridView1.DataSource = dv;
            if (dataGridView1.ColumnCount > 8)
            {
                //make key columns bold.
                dataGridView1.Columns[6].DefaultCellStyle.Font = new Font(dataGridView1.Font.FontFamily, dataGridView1.Font.Size, FontStyle.Bold);
                dataGridView1.Columns[7].DefaultCellStyle.Font = dataGridView1.Columns[6].DefaultCellStyle.Font;
                dataGridView1.Columns[8].DefaultCellStyle.Font = dataGridView1.Columns[6].DefaultCellStyle.Font;
            
                //highlight background of combined column.
                dataGridView1.Columns[8].DefaultCellStyle.BackColor = Color.LightYellow;

                //set size
                dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                //set format.
                dataGridView1.Columns[6].DefaultCellStyle.Format = "N3";
                dataGridView1.Columns[7].DefaultCellStyle.Format = "N3";
                dataGridView1.Columns[8].DefaultCellStyle.Format = "N3";

                ////loop thru each row and highlight best times and hide MaxValues.
                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //{
                //    DataRowView drv = (DataRowView)row.va;
                //    foreach (DataGridViewColumn col in dataGridView1.Columns)
                //    {
                //        if (col.Name.StartsWith("PAX") && Convert.ToDecimal(drv[col.Name]) == decimal.MaxValue)
                //        {
                //            row.SetValues("N/A");
                //        }
                //    }
                //}
            }
        }

        private void importRTPPAXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "AXWare Definitions (*.def)|*.def|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //load RTP/PAX file.
                _rtp = Axware.ImportRTP(openFileDialog1.FileName);
                ShowRTP();
            }
        }

        private void openEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_rtp != null)
            {
                openFileDialog1.FileName = "";
                openFileDialog1.Filter = "AXWare Events (*.st1)|*.st1|AXWare Events (*.st*)|*.st*|All files (*.*)|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //load staging file.
                    EventFilename = openFileDialog1.FileName;
                    if (!ImportStagingFileAndShowCompetition(EventFilename))
                    {
                        openEventToolStripMenuItem_Click(sender, e);
                    }
                }
            }
            else
            {
                MessageBox.Show("RTP/PAX indexes have not been loaded. Please loaded them first and try again.");
            }
        }

        private void Test()
        {
            Competition cc = new Competition(_rtp);

            Driver dd = cc.AddDriver("STU", "160", "Deutsch", "Evo");
            dd.AddRun(1, 11, 0, false);
            dd.AddRun(2, 10, 1, false);
            dd.AddRun(3, 8, 1, false);
            dd.AddRun(4, 13, 2, false);
            dd.AddRun(5, 11, 2, false);
            dd.AddRun(6, 10, 0, false);

            dd = cc.AddDriver("STU", "60", "Washburn", "Evo");
            dd.AddRun(1, 11, 0, false);
            dd.AddRun(2, 10, 1, false);
            dd.AddRun(3, 8, 1, false);
            dd.AddRun(4, 13, 2, false);
            dd.AddRun(5, 11, 2, false);
            dd.AddRun(6, 11, 0, false);

            cc.CalculateBestTimes();

            dataGridView1.DataSource = cc.ResultsToSortedDataView();
            

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Test();
        }

        private void cmbIndexedClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pnlFilters.Visible)
            {
                ShowCompetitionGrid();
            }
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pnlFilters.Visible)
            {
                ShowCompetitionGrid();
            }
        }

        private void cmbSplit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pnlFilters.Visible)
            {
                _cc.NumberRunsSplit1 = Convert.ToInt32(cmbSplit1.Text);
                ShowCompetitionGrid();
            }
        }

        private void cmbSplit2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pnlFilters.Visible)
            {
                _cc.NumberRunsSplit2 = Convert.ToInt32(cmbSplit2.Text);
                ShowCompetitionGrid();
            }
        }

        private void runWizardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmWiz.ShowDialog() == DialogResult.OK)
            {
                _rtp = Axware.ImportRTP(frmWiz.ClassFileName);
                ShowRTP();
                EventFilename = frmWiz.EventFileName;
                if (!ImportStagingFileAndShowCompetition(EventFilename))
                {
                    runWizardToolStripMenuItem_Click(sender, e);
                }
            }

        }

        /// <summary>
        /// Returns true if it's completed. If it returns false it wants to be retried.
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        protected bool ImportStagingFileAndShowCompetition(string FileName)
        {
            //load staging file.
            Exception expSave = null;
            try
            {
                _cc = Axware.ImportStagingFile(FileName, _rtp);
            }
            catch (RTPClassNotFoundException exp)
            {
                expSave = exp;
            }
            catch (StagingFileParsingException exp)
            {
                expSave = exp;
            }
            //check for errors.
            if (expSave != null)
            {
                if (MessageBox.Show("The following error occurred while loading the event. Make sure you used the correct Class Definition file. \n" + expSave.Message, "Error", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
                {
                    //call this function again.
                    return false;
                }
            }
            else
            {
                ShowCompetition();
            }

            //set event name:
            string eventTitle = GetEventNameFromECF();
            if (eventTitle != null)
            {
                txtEvent.Text = eventTitle.Replace("\n", " - ");
            }

            //we're done.
            return true;
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture),
                                                  dataGridView1.DefaultCellStyle.Font,
                                                  b,
                                                  e.RowBounds.Location.X + 20,
                                                  e.RowBounds.Location.Y + 4);
            }
        }

        private string GetEventNameFromECF()
        {
            //try to read event name out of matching .ecf file.
            string rslt = null;
            if (!string.IsNullOrEmpty(EventFilename))
            {
                //remove existing extension.
                System.IO.FileInfo fi = new System.IO.FileInfo(EventFilename);
                string ECFFileName = fi.FullName.Substring(0, fi.FullName.Length - fi.Extension.Length) + ".ecf";

                if (System.IO.File.Exists(ECFFileName))
                {
                    System.IO.StreamReader reader = System.IO.File.OpenText(ECFFileName);
                    string sECF = reader.ReadToEnd();
                    reader.Close();

                    int iStartTitle = sECF.IndexOf(Convert.ToChar(7)) + 1;
                    if (iStartTitle > -1)
                    {
                        rslt = sECF.Substring(iStartTitle);
                        rslt = rslt.Substring(0, rslt.IndexOf(Convert.ToChar(0)));
                    }
                }
            }
            return rslt;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ////export results to XML.

            //prompt user for location.
            if (!string.IsNullOrEmpty(EventFilename))
            {
                //remove existing extension.
                System.IO.FileInfo fi = new System.IO.FileInfo(EventFilename);
                saveFileDialog1.FileName = fi.FullName.Substring(0, fi.FullName.Length - fi.Extension.Length) + "_pro.htm";
            }
            else
            {
                saveFileDialog1.FileName = "pro_results.htm";
            }
            
            saveFileDialog1.DefaultExt = "htm";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //
                //export to HTML using a datagrid.
                gvRowNum = 1;
                System.Web.UI.WebControls.GridView gv = new System.Web.UI.WebControls.GridView();
                gv.AutoGenerateColumns = false;
                ////add some styling.
                gv.CellPadding = 4;
                gv.CellSpacing = 2;
                //gv.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;

                ////add the columns we want to display
                //Place
                System.Web.UI.WebControls.BoundField bf = new System.Web.UI.WebControls.BoundField();
                bf.HeaderText = "Place";
                gv.Columns.Add(bf);
                //Class
                bf = new System.Web.UI.WebControls.BoundField();
                bf.HeaderText = "Class";
                bf.DataField = "Class";
                gv.Columns.Add(bf);
                //Number
                bf = new System.Web.UI.WebControls.BoundField();
                bf.HeaderText = "Number";
                bf.DataField = "Number";
                gv.Columns.Add(bf);
                //Name
                bf = new System.Web.UI.WebControls.BoundField();
                bf.HeaderText = "Name";
                bf.DataField = "Name";
                gv.Columns.Add(bf);
                //Car
                bf = new System.Web.UI.WebControls.BoundField();
                bf.HeaderText = "Car";
                bf.DataField = "Car";
                gv.Columns.Add(bf);
                //Index
                bf = new System.Web.UI.WebControls.BoundField();
                bf.HeaderText = "Index";
                bf.DataField = "Index";
                bf.DataFormatString = "{0:#.000}";
                gv.Columns.Add(bf);
                //Best 1
                bf = new System.Web.UI.WebControls.BoundField();
                bf.HeaderText = "Best 1";
                bf.DataField = "Best 1";
                bf.DataFormatString = "{0:#.000}";
                gv.Columns.Add(bf);
                //Best 2
                bf = new System.Web.UI.WebControls.BoundField();
                bf.HeaderText = "Best 2";
                bf.DataField = "Best 2";
                bf.DataFormatString = "{0:#.000}";
                gv.Columns.Add(bf);
                //Combined
                bf = new System.Web.UI.WebControls.BoundField();
                bf.HeaderText = "Combined";
                bf.DataField = "Combined";
                bf.DataFormatString = "{0:#.000}";
                gv.Columns.Add(bf);

                gv.RowDataBound += new System.Web.UI.WebControls.GridViewRowEventHandler(gv_RowDataBound);
                gv.DataSource = dataGridView1.DataSource;
                gv.DataBind();
                System.IO.StringWriter sw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmltw = new System.Web.UI.HtmlTextWriter(sw);
                gv.RenderControl(htmltw);

                System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog1.FileName, System.IO.FileMode.Create);
                System.IO.StreamWriter strmwtr = new System.IO.StreamWriter(fs);
                //write begging HTML.
                strmwtr.WriteLine(string.Format("<html><head><title>Pro Results - {0}</title></head><body>", txtEvent.Text));
                //write title header.
                //strmwtr.WriteLine("<h1>Pro Results</h1>");
                strmwtr.WriteLine(string.Format("<h2>{0}</h2>", txtClub.Text));
                strmwtr.WriteLine(string.Format("<h3>Pro Results - {0}</h3>", txtEvent.Text));
                //write split info.
                strmwtr.WriteLine(string.Format("<p>Number of runs in AM: {0} <br />Number of runs in PM: {1}</p>", cmbSplit1.Text, cmbSplit2.Text));
                //write results table.
                strmwtr.Write(sw.ToString());
                //write ending HTML.
                strmwtr.WriteLine("</body></html>");

                strmwtr.Flush();
                strmwtr.Close();
                fs.Close();
            }
        }

        

        private void gv_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
            {
                System.Web.UI.WebControls.GridView gv = (System.Web.UI.WebControls.GridView)sender;
                e.Row.Cells[0].Text = gvRowNum.ToString();

                //check for "invalid times" in columns 6-8 (zero based index).
                for (int xx = 6; xx <= 8; xx++)
                {
                    if (e.Row.Cells[xx].Text == decimal.MaxValue.ToString() || e.Row.Cells[xx].Text == decimal.MaxValue.ToString() + ".000")
                    {
                        e.Row.Cells[xx].Text = "";
                    }
                }

                gvRowNum += 1;
            }
        }

    }
}
