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
        public int id{ get; private set; }
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            string json=string.Empty;

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

            if (email.Equals(txtEmail.Text) && password.Equals(txtPassword.Text))
            {
                frmMain frmMain = new frmMain()
                {
                    isAdmin = true
                };
                Close();
                UserSuccessfullAuthentication = true;
                isAdmin = true;
                isMem = true;
            }

            var members = member.GetMembers();

            foreach(var i in members)
            {
                if (i.Email.Equals(txtEmail.Text) && i.Password.Equals(txtPassword.Text))
                {
                    frmMain frm = new frmMain()
                    {
                        isAdmin = false
                    };
                Close();
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
                MessageBox.Show("Wrong Email or password, please try again", "Login Failed!!!");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
