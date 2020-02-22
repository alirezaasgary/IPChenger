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
    public partial class Login : Form
    {
        IAccountingRepository AccountingRepository;

        
        public Login()
        {
            InitializeComponent();
            AccountingRepository = new AccountingRepository();
            txtUserName.Text= System.Environment.MachineName.ToString();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            
            if (AccountingRepository.UserValidation(txtUserName.Text, txtpassWord.Text) == true)
            {
                
                Main f = new Main();
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("کلمه عبور اشتباه می باشد", " هشدار");
            }

           
        }
    }
}
