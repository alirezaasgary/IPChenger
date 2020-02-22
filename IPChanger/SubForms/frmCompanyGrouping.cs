using IPChanger.Repository;
using IPChanger.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace IPChanger.SubForms
{
    public partial class frmCompanyGrouping : Telerik.WinControls.UI.RadForm
    {
        ICompanyRepository CompanyRepository;
        public frmCompanyGrouping()
        {
            InitializeComponent();
            CompanyRepository = new CompanyRepository();
        }
        private void BindGridALL()
        {

            this.radGridView1.BindingContext = new BindingContext();
            this.radGridView1.DataSource = CompanyRepository.SelectAll();
            this.radGridView1.Size = new Size(this.radGridView1.Width, 690);
            this.radGridView1.TableElement.BeginUpdate();
            radGridView1.MasterTemplate.AutoExpandGroups = true;
            radGridView1.MasterTemplate.EnableFiltering = true;
            radGridView1.ShowGroupPanel = true;
            radGridView1.EnableHotTracking = true;
            this.radGridView1.TableElement.EndUpdate(false);
            radGridView1.TableElement.CellSpacing = -1;
            radGridView1.TableElement.TableHeaderHeight = 35;
            radGridView1.TableElement.GroupHeaderHeight = 30;
            radGridView1.TableElement.RowHeight = 25;
            this.radGridView1.TableElement.BeginUpdate();
            this.radGridView1.EnableFiltering = true;
            this.radGridView1.AllowAddNewRow = false;
            this.radGridView1.ReadOnly = true;
            this.radGridView1.MasterTemplate.ShowHeaderCellButtons = true;
            this.radGridView1.MasterTemplate.ShowFilteringRow = false;
            this.radGridView1.TableElement.EndUpdate();

        }
        private void BindGridJob()
        {

            this.radGridView2.BindingContext = new BindingContext();
            this.radGridView2.DataSource = CompanyRepository.FillJob(radGridView1.CurrentRow.Cells[5].Value.ToString().Trim(), radGridView1.CurrentRow.Cells[1].Value.ToString().Trim());
            this.radGridView2.Size = new Size(this.radGridView1.Width, 690);
            this.radGridView2.TableElement.BeginUpdate();
            radGridView2.MasterTemplate.AutoExpandGroups = true;
            radGridView2.MasterTemplate.EnableFiltering = true;
            radGridView2.ShowGroupPanel = true;
            radGridView2.EnableHotTracking = true;
            this.radGridView2.TableElement.EndUpdate(false);
            radGridView2.TableElement.CellSpacing = -1;
            radGridView2.TableElement.TableHeaderHeight = 35;
            radGridView2.TableElement.GroupHeaderHeight = 30;
            radGridView2.TableElement.RowHeight = 25;
            this.radGridView2.TableElement.BeginUpdate();
            this.radGridView2.EnableFiltering = true;
            this.radGridView2.AllowAddNewRow = false;
            this.radGridView2.ReadOnly = true;
            this.radGridView2.MasterTemplate.ShowHeaderCellButtons = true;
            this.radGridView2.MasterTemplate.ShowFilteringRow = false;
            this.radGridView2.TableElement.EndUpdate();

        }
        private void frmCompanyGrouping_Load(object sender, EventArgs e)
        {
            BindGridALL();
        }

        private void radGridView1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string linkServer = radGridView1.CurrentRow.Cells[5].Value.ToString().Trim();
            string dbName = radGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
            try
            {
                BindGridJob();
            }
            catch
            {

            }
            Cursor.Current = Cursors.Default;
            
        }
    }
}
