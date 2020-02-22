using IPChanger.Repository;
using IPChanger.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPChanger.SubForms
{
    public partial class frmPezeshki : Form
    {
        IPezeshkiRepository PezeshkiRepository;
        public frmPezeshki()
        {
            InitializeComponent();
            PezeshkiRepository = new PezeshkiRepository();
        }

        private void BindGridALL()
        {

            this.radGridView1.BindingContext = new BindingContext();
            this.radGridView1.DataSource = PezeshkiRepository.SelectAll();
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
        private void BindGrid_Owner1()
        {

            this.radGridView1.BindingContext = new BindingContext();
            this.radGridView1.DataSource = PezeshkiRepository.SelectOwner1();
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
        private void BindGrid_Owner2()
        {

            this.radGridView1.BindingContext = new BindingContext();
            this.radGridView1.DataSource = PezeshkiRepository.SelectOwner2();
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
        private void BindGrid_Owner3()
        {

            this.radGridView1.BindingContext = new BindingContext();
            this.radGridView1.DataSource = PezeshkiRepository.SelectOwner3();
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



        private void radGridView1_Click(object sender, EventArgs e)
        {

        }

        private void frmPezeshki_Load(object sender, EventArgs e)
        {
            BindGrid_Owner3();
           
        }

        private void OW3_Click(object sender, EventArgs e)
        {
            BindGrid_Owner3();
        }

        private void OW2_Click(object sender, EventArgs e)
        {
            BindGrid_Owner2();
        }

        private void OW1_Click(object sender, EventArgs e)
        {
            BindGrid_Owner1();
        }

        private void radSplitButton1_Click(object sender, EventArgs e)
        {
            BindGridALL();
        }
    }
}
