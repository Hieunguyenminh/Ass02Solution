using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAcess.Respository;
using BussinessObject;
using System.Collections.Generic;
using BussinessObject.Models;

namespace SalesWinApp
{
    public partial class frmMemberManagements : Form
    {
        public bool isAdmin { get; set; }
        public int id { get; set; }
        IMemberRespository memberRespository = new MemberRespository();
        BindingSource source;
        public frmMemberManagements()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadMemberList();
        }
        public void LoadMemberList()
        {
            var members= memberRespository.GetMembers();
            try
            {
                source = new BindingSource();
                if (isAdmin == false)
                {
                    source.DataSource = memberRespository.GetMemberByID(this.id);
                }
                else
                {
                    source.DataSource = members.OrderByDescending(members => members.Email);
                }
                txtMemberID.DataBindings.Clear();
                txtMemberName.DataBindings.Clear();
                txtPassword.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                cboCountry.DataBindings.Clear();
                cboCity.DataBindings.Clear();

                txtMemberID.DataBindings.Add("Text", source, "MemberId");
                txtMemberName.DataBindings.Add("Text", source, "CompanyName");
                txtPassword.DataBindings.Add("Text", source, "Password");
                txtEmail.DataBindings.Add("Text", source, "Email");
                cboCountry.DataBindings.Add("Text", source, "Country");
                cboCity.DataBindings.Add("Text", source, "City");

                dgvMemberList.DataSource = null;
                dgvMemberList.DataSource = source;
                if (isAdmin == false)
                {
                    if (members.Count() == 0)
                    {
                        btnDelete.Enabled = false;

                    }
                    else
                    {
                        btnDelete.Enabled = false;
                    }
                }
                else
                {
                    if (members.Count() == 0)
                    {
                        ClearText();
                        btnDelete.Enabled = false;
                    }
                    else
                    {
                        btnDelete.Enabled = true;
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Load member list");
            }
        }
        private void ClearText()
        {
            txtMemberID.Text = string.Empty;
            txtMemberName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            cboCountry.Text= string.Empty;
            cboCity.Text=string.Empty;
        }
        private Member GetMemberObject()
        {
            Member member = null;
            try
            {
                member = new Member
                {
                    MemberId = int.Parse(txtMemberID.Text),
                    CompanyName = txtMemberName.Text,
                    Password = txtPassword.Text,
                    Email = txtEmail.Text,
                    Country = cboCountry.Text,
                    City = cboCity.Text,
                };
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Get member");
            }
            return member;
        }
        private void FilterMember()
        {
            Member member = new Member();
            List<Member> filterList = memberRespository.GetMembersByCityAndCountry(cboSearchCity.Text, cboSearchCountry.Text);
            try
            {
                if (filterList.Count == 0)
                {
                    MessageBox.Show("No member matched", "No result");
                }else if (filterList.Count != 0)
                {
                    source = new BindingSource();
                    source.DataSource = filterList.OrderByDescending(member => member.CompanyName);
                    txtMemberID.DataBindings.Clear();
                    txtMemberName.DataBindings.Clear();
                    txtPassword.DataBindings.Clear();
                    txtEmail.DataBindings.Clear();
                    cboCountry.DataBindings.Clear();
                    cboCity.DataBindings.Clear();

                    txtMemberID.DataBindings.Add("Text", source, "MemberId");
                    txtMemberName.DataBindings.Add("Text", source, "CompanyName");
                    txtPassword.DataBindings.Add("Text",source,"Password");
                    txtEmail.DataBindings.Add("Text", source, "Email");
                    cboCountry.DataBindings.Add("Text", source, "Country");
                    cboCity.DataBindings.Add("Text", source, "City");

                    dgvMemberList.DataSource = null;
                    dgvMemberList.DataSource = source;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Load member list");
            }
        }
        private void LoadMultiMember()
        {
            var members = memberRespository.GetMembers();
            List<Member> mem = new List<Member>();
            try
            {
                foreach (var i in members)
                {
                    if (i.CompanyName.Contains(txtSearch.Text))
                    {
                        mem.Add(i);
                    }
                    else if (i.MemberId.ToString().Equals(txtSearch.Text))
                    {
                        mem.Add(i);
                    }
                }
                source = new BindingSource();
                source.DataSource = mem;

                txtMemberID.DataBindings.Clear();
                txtMemberName.DataBindings.Clear();
                txtPassword.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                cboCountry.DataBindings.Clear();
                cboCity.DataBindings.Clear();

                txtMemberID.DataBindings.Add("Text", source, "MemberID");
                txtMemberName.DataBindings.Add("Text", source, "CompanyName");
                txtPassword.DataBindings.Add("Text", source, "Password");
                txtEmail.DataBindings.Add("Text", source, "Email");
                cboCountry.DataBindings.Add("Text", source, "Country");
                cboCity.DataBindings.Add("Text", source, "City");
                dgvMemberList.DataSource = null;
                dgvMemberList.DataSource = source;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load member list");
            }
        }

        private void LoadOneMember()
        {
            Member member = new Member();
            var members=memberRespository.GetMembers();
            try
            {
                foreach(var i in members)
                {
                    if (i.CompanyName.Contains(txtSearch.Text))
                    {
                        source = new BindingSource();
                        source.DataSource = memberRespository.GetMemberByID(i.MemberId);

                        txtMemberID.DataBindings.Clear();
                        txtMemberName.DataBindings.Clear();
                        txtPassword.DataBindings.Clear();
                        txtEmail.DataBindings.Clear();
                        cboCountry.DataBindings.Clear();
                        cboCity.DataBindings.Clear();

                        txtMemberID.DataBindings.Add("Text", source, "MemberID");
                        txtMemberName.DataBindings.Add("Text", source, "CompanyName");
                        txtPassword.DataBindings.Add("Text", source, "Password");
                        txtEmail.DataBindings.Add("Text", source, "Email");
                        cboCountry.DataBindings.Add("Text", source, "Country");
                        cboCity.DataBindings.Add("Text", source, "City");

                        dgvMemberList.DataSource = null;
                        dgvMemberList.DataSource = source;
                        break;
                    }
                    else if (i.MemberId.ToString().Equals(txtSearch.Text))
                    {
                        source = new BindingSource();
                        source.DataSource = memberRespository.GetMemberByID(i.MemberId);

                        txtMemberID.DataBindings.Clear();
                        txtMemberName.DataBindings.Clear();
                        txtPassword.DataBindings.Clear();
                        txtEmail.DataBindings.Clear();
                        cboCountry.DataBindings.Clear();
                        cboCity.DataBindings.Clear();

                        txtMemberID.DataBindings.Add("Text", source, "MemberID");
                        txtMemberName.DataBindings.Add("Text", source, "CompanyName");
                        txtPassword.DataBindings.Add("Text", source, "Password");
                        txtEmail.DataBindings.Add("Text", source, "Email");
                        cboCountry.DataBindings.Add("Text", source, "Country");
                        cboCity.DataBindings.Add("Text", source, "City");

                        dgvMemberList.DataSource = null;
                        dgvMemberList.DataSource = source;
                        break ;
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Load member list");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmMembers frmMemberDetails = new frmMembers
            {
                Text = "Add member",
                InsertOrUpdate = false,
                MemberRespository = memberRespository
            };
            if (frmMemberDetails.ShowDialog() == DialogResult.OK)
            {
                LoadMemberList();
                source.Position = source.Count - 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var member=GetMemberObject();
                memberRespository.DeleteMember(member.MemberId);
                LoadMemberList();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete a member");
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FilterMember();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadMultiMember();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvMemberList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvMemberList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmMembers frmMemberDetails = new frmMembers
            {
                Text = "Update member",
                InsertOrUpdate = true,
                MemberInfor = GetMemberObject(),
                MemberRepository = memberRepository
            };
            if (frmMemberDetails.ShowDialog() == DialogResult.OK)
            {
                LoadMemberList();
                //Set focus member updated
                source.Position = source.Count - 1;
            }

        }
        


        private void frmMemberManagements_Load(object sender, EventArgs e)
        {
            if (isAdmin == false)
            {
                btnDelete.Enabled = false;
                btnNew.Enabled = false;

                cboCity.Enabled = false;
                cboCountry.Enabled = false;
                txtEmail.Enabled = false;
                txtMemberID.Enabled = false;
                txtMemberName.Enabled = false;
                txtPassword.Enabled = false;
                btnDelete.Enabled = false;
                btnFind.Enabled = false;
                btnSearch.Enabled = false;
                txtSearch.Visible = false;
                cboSearchCountry.Enabled = false;
                cboSearchCity.Enabled = false;
                dgvMemberList.CellDoubleClick += dgvMemberList_CellDoubleClick;
            }
            else
            {
                btnDelete.Enabled = false;
                dgvMemberList.CellDoubleClick += dgvMemberList_CellDoubleClick;
            }
            
        }
    }
}
