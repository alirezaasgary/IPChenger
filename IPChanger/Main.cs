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
using System.Globalization;
using System.Diagnostics;
using System.Net;
using IPChanger.Services;
using IPChanger.Repository;
using IPChanger.SubForms;
using Telerik.WinControls.UI;

namespace IPChanger
{
    public partial class Main : Form
    {
        public static string name = System.Environment.MachineName;
        public static int personelId = int.Parse(name.Substring(7));
        ICompanyRepository CompanyRepository;
        //IPezeshkiRepository PezeshkiRepository;
        string coIP;
        int RowCode;
        public Main()
        {
            InitializeComponent();
            CompanyRepository = new CompanyRepository();
            //PezeshkiRepository = new PezeshkiRepository();
        }

        //private void BindGrid()
        //{

        //    //radGridView1 = new RadGridView();
        //    //this.Controls.Add(this.radGridView1);
        //    //this.radGridView1.Dock = DockStyle.Fill;

        //    this.radGridView1.BindingContext = new BindingContext();
        //    this.radGridView1.DataSource = PezeshkiRepository.SelectAll();
        //    //this.radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

        //    //this.SelectedControl = this.radGridView1;
        //    //this.radGridView1.Size = new Size(this.radGridView1.Width, 690);

        //    //this.radGridView1.TableElement.BeginUpdate();
           
       
            
        //    //this.customersTableAdapter.Fill(this.northwindDataSet.Customers);

        //    //radGridView1.MasterTemplate.AutoExpandGroups = true;
        //    //radGridView1.MasterTemplate.EnableFiltering = true;
        //    //radGridView1.ShowGroupPanel = true;
        //    //radGridView1.EnableHotTracking = true;


        //    //this.radGridView1.TableElement.EndUpdate(false);

        //    //radGridView1.TableElement.CellSpacing = -1;
        //    //radGridView1.TableElement.TableHeaderHeight = 35;
        //    //radGridView1.TableElement.GroupHeaderHeight = 30;
        //    //radGridView1.TableElement.RowHeight = 25;
        //}



        private void Form1_Load(object sender, EventArgs e)
        {
            if (System.Environment.MachineName == "GIG001P10345" || System.Environment.MachineName == "GIG001P10226")
            {
                button11.Visible = true;
            }
           
            this.companyTableAdapter.Fill(this.papDBDataSet.company); 
            Cultures.InitializePersianCulture();
            label5.Text = DateTime.Now.ToShortDateString();
            label6.Text = DateTime.Now.ToLongTimeString();
            string edate = DateTime.Now.AddDays(10).ToShortDateString();
            edate= edate.Substring(2, 2) + edate.Substring(5, 2) + edate.Substring(8, 2);
            string sdate = label5.Text.Substring(2, 2) + label5.Text.Substring(5, 2) + label5.Text.Substring(8, 2);
            
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("fa-IR"));

            richTextBox1.Text = File.ReadAllText("C:\\Program Files (x86)\\PapNet\\Pap.ini");

            TslPname.Text = "نام و نام خانوادگی : "+ this.personelTableAdapter.fillpersonel(personelId).ToString()  ;
            tslPId.Text = "کد پرسنلی : " + personelId;
            TslPCName.Text = "نام ایستگاه کاری : " + System.Environment.MachineName;
            TslIp.Text = "آدرس ایستگاه کاری: " + Get_Local_IP_Address();

        }

        private void companyDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowCode = Convert.ToInt32(companyDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
            coIP = companyDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            if (companyDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString()!="" )
            {
                groupBox1.Text = " "+"ویرایش شرکت" + " "+(companyDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString())+ " ";
                label1.Text = (companyDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString());
                label4.Visible = false;
            }
            else if (companyDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString() == "" || companyDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString() == null)
            {
                groupBox1.Text = " " + "ویرایش شرکت" + " " + (companyDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString()) + " ";
                label1.Text = (companyDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                label4.Visible = false;
            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            try
            {
                label1.Text = "";
                label4.Visible = false;
                this.companyTableAdapter.search(this.papDBDataSet.company,  "%" + textBox1.Text + "%", "%" + textBox1.Text + "%", "%" + textBox1.Text + "%");
                this.phonesBookTableAdapter.searchByAll(this.tell.PhonesBook, "%" + textBox1.Text + "%", "%" + textBox1.Text + "%");
                if (checkBox1.Checked == true)
                {
                    this.noteTableAdapter.Search(this.note.NoteDateTable, "%" + textBox1.Text + "%", "%" + textBox1.Text + "%", "%" + textBox1.Text + "%", int.Parse(textBox1.Text));
                }
                else
                {
                    this.noteTableAdapter.searchOwnNote(this.note.NoteDateTable, "%" + textBox1.Text + "%", "%" + textBox1.Text + "%", "%" + textBox1.Text + "%", personelId);

                }

               
                    dgCompany.AutoGenerateColumns = false;
                    DgJob.AutoGenerateColumns = false;
                    dgCompany.DataSource = CompanyRepository.SearchCompany(textBox1.Text);
               
            }

            catch
            {

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.companyTableAdapter.Fill(this.papDBDataSet.company);
            label4.Visible = false;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                      
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] lines = richTextBox1.Lines;
            lines[1] = "Server="+label1.Text;
            richTextBox1.Lines = lines;

            StreamWriter wr = new StreamWriter("C:\\Program Files (x86)\\PapNet\\Pap.ini");
            wr.Write(richTextBox1.Text);
            wr.Close();
            label4.Visible = true;

        }

        private void companyDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string[] lines = richTextBox1.Lines;
            lines[1] = "Server=" + label1.Text;
            richTextBox1.Lines = lines;
            Clipboard.SetText(companyDataGridView.CurrentRow.Cells[2].Value.ToString());

            StreamWriter wr = new StreamWriter("C:\\Program Files (x86)\\PapNet\\Pap.ini");
            wr.Write(richTextBox1.Text);
            wr.Close();

            label4.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(iPTextBox.Text=="" || dbnameTextBox.Text == "")
            {
                MessageBox.Show("لطفا در از صحت اطلاعات اطمینان حاصل فرمایید.","خطا");
            }
            this.companyTableAdapter.UpdateQuery(iPTextBox.Text, dbnameTextBox.Text, descTextBox.Text, int.Parse(codeLabel1.Text));
            groupBox1.Enabled = false;
            this.companyTableAdapter.Fill(this.papDBDataSet.company);
        }

        
        public void ExecuteCommand(string Command)
        {
            ProcessStartInfo ProcessInfo; Process Process;
            ProcessInfo = new ProcessStartInfo("cmd.exe", "/K " + Command);
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = true;
            Process = Process.Start(ProcessInfo);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ExecuteCommand("ping " + coIP + " -t");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = DateTime.Now.ToLongTimeString();
        }
        string Get_Local_IP_Address()
        {
            string LocalIP = null;
            IPHostEntry IPHostEntry = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress IPAddress in IPHostEntry.AddressList)
            {
                if (IPAddress.AddressFamily.ToString() == "InterNetwork")
                    LocalIP = IPAddress.ToString();
            }
            return LocalIP;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                //کپی کردن متن درون تکس باکس
                Clipboard.SetText("BlueDi@mond");
            }
            catch { }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                //کپی کردن متن درون تکس باکس
                Clipboard.SetText(name);
                

            }
            catch { }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button7_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                    Clipboard.SetText("BlueDi@mond");
            }
            if (e.KeyCode == Keys.F3)
            {
                    //کپی کردن متن درون تکس باکس
                    Clipboard.SetText(System.Environment.MachineName);
            }

        }

        private void notifyIcon2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
        }

    

        private void Main_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                ShowInTaskbar = false;
   
        }

        private void button9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\Program Files (x86)\\PapNet\\PapNet.exe");
        }

        private void button9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P)
            {
                System.Diagnostics.Process.Start("C:\\Program Files (x86)\\PapNet\\PapNet.exe");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = File.ReadAllText("C:\\Program Files (x86)\\PapNet\\Pap.ini");
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage3"])//your specific tabname
            {
                if (checkBox1.Checked == true)
                {
                    this.noteTableAdapter.Fill(this.note.NoteDateTable);       
                }
                else
                {
                    this.noteTableAdapter.FillOwnNote(this.note.NoteDateTable, personelId);
                }
                button12.Visible = true;
                richTextBox2.Visible = true;
                button7.Visible = false;
                button8.Visible = false;
                comboBox1.Visible = true;
                button10.Visible = true;
                checkBox1.Enabled = true;
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage1"])//your specific tabname
            {
                button12.Visible = false;
                button10.Visible = false;
                richTextBox2.Visible = false;
                button7.Visible = true;
                button8.Visible = true;
                comboBox1.Visible = false;
                checkBox1.Enabled = false;
                this.companyTableAdapter.Fill(this.papDBDataSet.company);
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage2"])//your specific tabname
            {
                this.phonesBookTableAdapter.Fill(this.tell.PhonesBook);
                button12.Visible = false;
                richTextBox2.Visible = false;
                button10.Visible = false;
                button7.Visible = true;
                button8.Visible = true;
                comboBox1.Visible = false;
                checkBox1.Enabled = false;
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage4"])//your specific tabname
            {
                button12.Visible = false;
                string edate = DateTime.Now.AddDays(10).ToShortDateString();
                edate = edate.Substring(2, 2) + edate.Substring(5, 2) + edate.Substring(8, 2);
                string sdate = label5.Text.Substring(2, 2) + label5.Text.Substring(5, 2) + label5.Text.Substring(8, 2);
                this.vw_k_ListFoodOrdersTableAdapter.FillFoodOrder(this.foodsorder.vw_k_ListFoodOrders, sdate, edate, personelId);
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage5"])//your specific tabname
            {
                try
                {
                    dgCompany.AutoGenerateColumns = false;
                    DgJob.AutoGenerateColumns = false;
                    dgCompany.DataSource = CompanyRepository.SelectAll();
                }
                catch
                {

                }

            }
            //else if (tabControl1.SelectedTab == tabControl1.TabPages["ServerInfo"])//your specific tabname
            //{
            //    try
            //    {
            //        BindGrid();
            //    }
            //    catch
            //    {

            //    }

            //}


        }
  

        private void BtnTavalod_Click(object sender, EventArgs e)
        {
            Tavalod m = new Tavalod();
            m.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            this.noteTableAdapter.InsertQuery(personelId, int.Parse(comboBox1.SelectedValue.ToString()), richTextBox2.Text, label5.Text, label6.Text);
            if (checkBox1.Checked == true)
            {
                this.noteTableAdapter.Fill(this.note.NoteDateTable);
            }
            else
            {
                this.noteTableAdapter.FillOwnNote(this.note.NoteDateTable, personelId);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           if( checkBox1.Checked == true)
            {
                button12.Enabled = true;
                this.noteTableAdapter.Fill(this.note.NoteDateTable);
            }
           else
            {
                button12.Enabled = false;
                this.noteTableAdapter.FillOwnNote(this.note.NoteDateTable, personelId);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
           
        }

        private void button12_Click(object sender, EventArgs e)
        {

            
            try
            {
                DialogResult dialogResult = MessageBox.Show("Sure", "آیا از حذف یادداشت اطمینان دارید ؟", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    this.noteTableAdapter.DeleteQuery(Int32.Parse(iDLabel1.Text));
                    this.noteTableAdapter.FillOwnNote(this.note.NoteDateTable, personelId);
                    
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
                
            }
            catch 
            {

                throw;
            }
           
        }

        private void richTextBox2_Click(object sender, EventArgs e)
        {

            richTextBox2.SelectAll();
        }

        private void noteDateTableDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = noteDateTableDataGridView.HitTest(e.X, e.Y);
                noteDateTableDataGridView.ClearSelection();
                noteDateTableDataGridView.Rows[hti.RowIndex].Selected = true;
            }
        }
        private void DeleteRow_Click(object sender, EventArgs e)
        {
            Int32 rowToDelete = noteDateTableDataGridView.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            noteDateTableDataGridView.Rows.RemoveAt(rowToDelete);
            noteDateTableDataGridView.ClearSelection();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {

            string a = noteDateTableDataGridView.SelectedRows[0].Cells[0].ToString();
            MessageBox.Show(a,a  ) ;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dgCompany_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string linkServer = dgCompany.CurrentRow.Cells[3].Value.ToString().Trim();
            string dbName = dgCompany.CurrentRow.Cells[2].Value.ToString().Trim();
            try
            {

                DgJob.DataSource = CompanyRepository.FillJob(linkServer, dbName);
            }
            catch
            {

            }
            Cursor.Current = Cursors.Default;
        }

        private void DgJob_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string serverIp = dgCompany.CurrentRow.Cells[4].Value.ToString().Trim();
            string dbName = dgCompany.CurrentRow.Cells[2].Value.ToString().Trim();
            string spName = DgJob.CurrentRow.Cells[0].Value.ToString().Trim();
            string spBody="";

            try
            {

                dgSpBody_hiden.DataSource = CompanyRepository.FillSpBody(serverIp, dbName," "+spName);
            }
            catch
            {

            }
            for (int i = 0; i < dgSpBody_hiden.Rows.Count; i++)
            {
                if (dgSpBody_hiden.Rows[i].Cells[0].Value != null)
                {
                    spBody = spBody + " " + dgSpBody_hiden.Rows[i].Cells[0].Value.ToString();
                }

                
            }
            richTextBox1.Text = "";
            PublicVariabl.spBody = spBody;
            richTextBox1.Text = spBody;
            Cursor.Current = Cursors.Default;
        }

        private void DgJob_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmSpBody f1 = new frmSpBody();
            f1.ShowDialog();
        }

        private void button11_Click_2(object sender, EventArgs e)
        {
            frmPezeshki f1 = new frmPezeshki();
            f1.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {

            frmCompanyGrouping f1 = new frmCompanyGrouping();
            f1.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            frmMdiDoc fr = new frmMdiDoc();
            fr.Show();
        }
    }

}
