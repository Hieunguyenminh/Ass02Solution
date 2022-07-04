using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class frmMain : Form
    {
        public bool isAdmin { get; set; }
        public int id { get; set; }
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void memberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmMembers")) 
            {
                frmMembers frm = new frmMembers() { isAdmin = this.isAdmin, id = this.id };
                frm.MdiParent = this;
                frm.Show();
            }
            else AcctiveChildForm("frmMembers");
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmProducts"))
            {
                frmProducts frm = new frmProducts() { isAdmin = this.isAdmin };
                frm.MdiParent = this;
                frm.Show();
            }
            else AcctiveChildForm("frmProducts");
        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmOrders"))
            {
                frmOrderDetail frm = new frmOrderDetail() { isAdmin = this.isAdmin };
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                AcctiveChildForm("frmOrders");
            }
        }

        //check form exist
        private bool CheckExistForm(string name)
        {
            bool check=false;
            foreach(Form frm in this.MdiChildren)
            {
                if(frm.Name == name)
                {
                    check=true;
                    break;
                }
            }
            return check;
        }

        private void AcctiveChildForm(string name)
        {
            foreach(Form frm in this.MdiChildren)
            {
                if(frm.Name == name)
                {
                    frm.Activate();
                    break;
                }
            }
        }

    }
}
