using DataAcess.Respository;
using Nancy.Json;
using SalesWinApp;
using System;
using System.IO;
using System.Windows.Forms;
namespace SalesWinApp
{
    public partial class frmLogin : Form
    {
        private MemberRespository member = new MemberRespository();
        public bool UserSuccessfullAuthentication { get; set; }
        public bool isAdmin { get; set; }
        public int id { get; private set; }
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            string json = string.Empty;

            //read json file
            using (StreamReader reader = new StreamReader("appsettings.json"))
            {
                json = reader.ReadToEnd();
            }

            JavaScriptSerializer jsConverter = new JavaScriptSerializer();

            //convert json string to dynamic type
            var obj = jsConverter.Deserialize<dynamic>(json);
            //get contents
            string email = obj["Default Account"]["Email"];
            string password = obj["Default Account"]["password"];
            bool isMem = false;

            if (email.Equals(txtUserName.Text) && password.Equals(txtPassword.Text))
            {
                frmMain frmMain = new frmMain()
                {
                    isAdmin = true
                };
                this.Close();
                frmMain.ShowDialog();
                UserSuccessfullAuthentication = true;
                isAdmin = true;
                isMem = true;
            }
            else
            {
                var members = member.GetMembers();

                foreach (var i in members)
                {
                    if (i.CompanyName.Equals(txtUserName.Text) && i.Password.Equals(txtPassword.Text))
                    {
                        frmMain frm = new frmMain()
                        {
                            isAdmin = false
                        };
                        this.Close();
                        frm.ShowDialog();
                        UserSuccessfullAuthentication = true;
                        isAdmin = false;
                        id = i.MemberId;
                        isMem = true;
                    }
                }
                if (isMem == true)
                {
                    MessageBox.Show("Login Successfully", "Right User");
                }
                else
                {
                    MessageBox.Show("Wrong user name or password, please try again", "Login Failed!!!");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtPassword.Text = "admin@@";
            txtUserName.Text = "admin@fstore.com";
        }
    }
}
