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
using BussinessObject.Models;

namespace SalesWinApp
{
    public partial class frmProductDetails : Form
    {
        public IProductRespository ProductRespository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public Product Product { get; set; }
        public frmProductDetails()
        {
            InitializeComponent();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(System.Text.RegularExpressions.Regex.IsMatch(txtProductID.Text, @"^(?!\s*$).+")
                   && System.Text.RegularExpressions.Regex.IsMatch(txtProductName.Text, @"^(?!\s*$).+")
                    && System.Text.RegularExpressions.Regex.IsMatch(txtProductName.Text, @"^(?!\s*$).+")
                    && System.Text.RegularExpressions.Regex.IsMatch(txtProductName.Text, @"^(?!\s*$).+")
                    && System.Text.RegularExpressions.Regex.IsMatch(txtProductName.Text, @"^(?!\s*$).+")
                    && System.Text.RegularExpressions.Regex.IsMatch(txtProductName.Text, @"^(?!\s*$).+"))
                {
                    var product = new Product
                    {
                        ProductId = int.Parse(txtProductID.Text),
                        ProductName = txtProductName.Text,
                        Weight = txtWeight.Text,
                        UnitPrice = decimal.Parse(txtUnitPrice.Text),
                        UnitInStock = int.Parse(txtUnitInStock.Text),
                        CategoryId = int.Parse(txtCategoryID.Text),
                    };
                    if (InsertOrUpdate == false)
                    {
                        ProductRespository.InsertProduct(product);
                    }
                    else
                    {
                        ProductRespository.UpdateProduct(product);
                    }
                }
                else
                {
                    MessageBox.Show("Please double check every fields must not be null, empty or spaces only!", InsertOrUpdate == false ? "Add a new Member" : "Update a Member");

                }
                        }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new Product" : "Update a Product");
            }
        }

        private void frmProductDetails_Load(object sender, EventArgs e)
        {
            txtProductID.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate == true)
            {
                txtProductID.Text = Product.ProductId.ToString();
                txtProductName.Text = Product.ProductName;
                txtCategoryID.Text = Product.CategoryId.ToString();
                txtWeight.Text = Product.Weight;
                txtUnitPrice.Text = Product.UnitPrice.ToString();
                txtUnitInStock.Text=Product.UnitInStock.ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
