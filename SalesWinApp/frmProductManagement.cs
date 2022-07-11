using BussinessObject.Models;
using DataAcess.Respository;
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
    public partial class frmProductManagement : Form
    {
        public bool isAdmin { get; set; }
        IProductRespository productRepository = new ProductRespository();
        BindingSource source;
        public frmProductManagement()
        {
            InitializeComponent();
        }
        private void frmProductManagements_Load(object sender, EventArgs e)
        {
            if (isAdmin == false)
            {
                btnDelete.Enabled = false;
                btnNew.Enabled = false;
                btnFind.Enabled = false;
                btnLoad.Enabled = false;
                btnSearch.Enabled = false;
                txtProductName.Enabled = false;
                txtCategoryID.Enabled = false;
                txtFind.Enabled = false;
                txtProductID.Enabled = false;
                txtSearch.Enabled = false;
                txtUnitPrice.Enabled = false;
                txtToNum.Enabled = false;
                txtUnitsInStock.Enabled = false;
                txtWeight.Enabled = false;

                dgvMemberList.CellDoubleClick += null;
            }
            else
            {
                btnDelete.Enabled = false;
                //Register this event to open the frmMemberDetail form that performs updating
                dgvMemberList.CellDoubleClick += dgvMemberList_CellDoubleClick;
            }
        }
        private void dgvMemberList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmProductDetails frm = new frmProductDetails
            {
                Text = "Update product",
                InsertOrUpdate = true,
                Product = GetProductObject(),
                ProductRespository = productRepository
            };
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadMemberList();
            }
        }
        private void ClearText()
        {
            txtWeight.Text = string.Empty;
            txtUnitsInStock.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtProductID.Text = string.Empty;
            txtCategoryID.Text = string.Empty;
        }
        //-----------------------------------------------
        private Product GetProductObject()
        {
            Product product = null;
            try
            {
                product = new Product
                {
                    ProductId = int.Parse(txtProductID.Text),
                    ProductName = txtProductName.Text.ToString(),
                    CategoryId = int.Parse(txtCategoryID.Text),
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    UnitInStock = int.Parse(txtUnitsInStock.Text),
                    Weight = txtWeight.Text.ToString()
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get product");
            }
            return product;
        }

        public void LoadMemberList()
        {
            var members = productRepository.GetProductsList();
            try
            {
                //The BindingSource component is designed to simplify
                //the process of binding controls to an underlying data source
                source = new BindingSource();
                source.DataSource = members.OrderByDescending(member => member.ProductName);
                txtProductID.DataBindings.Clear();
                txtProductName.DataBindings.Clear();
                txtCategoryID.DataBindings.Clear();
                txtUnitPrice.DataBindings.Clear();
                txtUnitsInStock.DataBindings.Clear();
                txtWeight.DataBindings.Clear();

                txtProductID.DataBindings.Add("Text", source, "ProductId");
                txtProductName.DataBindings.Add("Text", source, "ProductName");
                txtCategoryID.DataBindings.Add("Text", source, "CategoryId");
                txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
                txtUnitsInStock.DataBindings.Add("Text", source, "UnitInStock");
                txtWeight.DataBindings.Add("Text", source, "Weight");

                dgvMemberList.DataSource = null;
                dgvMemberList.DataSource = source;
                if (isAdmin == false)
                {
                    if (members.Count() == 0)
                    {
                        ClearText();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load product list");
            }
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadMemberList();
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            frmProductDetails frm = new frmProductDetails
            {
                Text = "Add product",
                InsertOrUpdate = false,
                ProductRespository = productRepository
            };
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadMemberList();
                //Set focus member inserted
                source.Position = source.Count - 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var member = GetProductObject();
                productRepository.DeleteProduct(member.ProductId);
                LoadMemberList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete a product");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadOneMember()
        {
            Product member = new Product();
            var members = productRepository.GetProductsList();
            try
            {
                foreach (var i in members)
                {
                    //The BindingSource omponent is designed to simplify
                    //the process of binding controls to an underlying data source
                    if (i.ProductName.Equals(txtSearch.Text))
                    {
                        source = new BindingSource();

                        source.DataSource = productRepository.GetProductByID(i.ProductId);

                        txtProductID.DataBindings.Clear();
                        txtProductName.DataBindings.Clear();
                        txtCategoryID.DataBindings.Clear();
                        txtUnitPrice.DataBindings.Clear();
                        txtUnitsInStock.DataBindings.Clear();
                        txtWeight.DataBindings.Clear();

                        txtProductID.DataBindings.Add("Text", source, "ProductId");
                        txtProductName.DataBindings.Add("Text", source, "ProductName");
                        txtCategoryID.DataBindings.Add("Text", source, "CategoryId");
                        txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
                        txtUnitsInStock.DataBindings.Add("Text", source, "UnitInStock");
                        txtWeight.DataBindings.Add("Text", source, "Weight");


                        dgvMemberList.DataSource = null;
                        dgvMemberList.DataSource = source;
                        break;
                    }
                    else if (i.ProductId.ToString().Equals(txtSearch.Text))
                    {
                        source = new BindingSource();
                        source.DataSource = productRepository.GetProductByID(i.ProductId);
                        txtProductID.DataBindings.Clear();
                        txtProductName.DataBindings.Clear();
                        txtCategoryID.DataBindings.Clear();
                        txtUnitPrice.DataBindings.Clear();
                        txtUnitsInStock.DataBindings.Clear();
                        txtWeight.DataBindings.Clear();

                        txtProductID.DataBindings.Add("Text", source, "ProductId");
                        txtProductName.DataBindings.Add("Text", source, "ProductName");
                        txtCategoryID.DataBindings.Add("Text", source, "CategoryId");
                        txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
                        txtUnitsInStock.DataBindings.Add("Text", source, "UnitInStock");
                        txtWeight.DataBindings.Add("Text", source, "Weight");

                        dgvMemberList.DataSource = null;
                        dgvMemberList.DataSource = source;
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load product list");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadOneMember();
        }
    }
}
