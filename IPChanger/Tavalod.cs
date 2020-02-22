using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace IPChanger
{
    public partial class Tavalod : Form
    {
        public static string mah;
        public Tavalod()
        {
            InitializeComponent();
             //var mah=  DateTime.Now.ToShortDateString();
            
        }

        private void Tavalod_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tavalodDS.Personel' table. You can move, or remove it, as needed.
            this.personelTableAdapter.Fill(this.tavalodDS.Personel);
            // TODO: This line of code loads data into the 'mahDS.mah' table. You can move, or remove it, as needed.
            
            mah = DateTime.Now.ToShortDateString().Substring(5,2);
            //this.mahTableAdapter.FillLoadMah(this.mahDS.mah, mah);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < personelDataGridView.RowCount; i++)
                {
                    if (personelDataGridView.Rows[i].Cells[5].Value == null || Convert.ToBoolean(personelDataGridView.Rows[i].Cells[5].Value) == false)
                    {
                        personelTableAdapter.UpdateQuery(false, Convert.ToInt32(personelDataGridView.Rows[i].Cells[0].Value));
                    }
                    else if (Convert.ToBoolean(personelDataGridView.Rows[i].Cells[5].Value) == true)
                    {
                        personelTableAdapter.UpdateQuery(true, Convert.ToInt32(personelDataGridView.Rows[i].Cells[0].Value));

                    }

                }
            }
            catch
            {

            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.personelTableAdapter.FillByMAH_IS_OK(this.tavalodDS.Personel, comboBox1.SelectedValue.ToString());
            }
            catch
            {
                this.personelTableAdapter.Fill(this.tavalodDS.Personel);
            }
           
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            this.mahTableAdapter.Fill(this.mahDS.mah);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                this.mahTableAdapter.FillLoadMah(this.mahDS.mah, mah);
                this.personelTableAdapter.FillByMAH_IS_OK(this.tavalodDS.Personel, comboBox1.SelectedValue.ToString());
            }
        }
    }
}
