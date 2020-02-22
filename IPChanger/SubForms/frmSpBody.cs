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
    public partial class frmSpBody : Form
    {
        public frmSpBody()
        {
            InitializeComponent();
        }

        private void frmSpBody_Load(object sender, EventArgs e)
        {
            radRichTextEditor1.Text = PublicVariabl.spBody;
            
        }
    }
}
