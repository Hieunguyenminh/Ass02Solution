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
    public partial class frmOrderDetail : Form
    {
        public bool isAdmin { get; set; }
        public int id { get; set; }
        public IOrderDetailRespository OrderDetailRepository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public OrderDetail OrderInfor { get; set; }
        public int OrderId { get; set; }
        IProductRespository productRepository = new ProductRespository();
        BindingSource source;
        public frmOrderDetail()
        {
            InitializeComponent();
        }

        private void frmOrders_Load(object sender, EventArgs e)
        {
            txtProductID.Enabled = !InsertOrUpdate;
            txtOrderID.Enabled = false;
            txtOrderID.Text = OrderId.ToString();

            if (InsertOrUpdate == true)//update mode
            {
                //Show member to perform updating
                txtProductID.Text = OrderInfor.ProductId.ToString();
                txtQuantity.Text = OrderInfor.Quantity.ToString();
                txtDiscount.Text = OrderInfor.Discount.ToString();
                txtUnitPrice.Text = OrderInfor.UnitPrice.ToString();
            }
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
                txtUnitPrice.DataBindings.Clear();


                txtProductID.DataBindings.Add("Text", source, "ProductId");
                txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");

                dgvMemberList.DataSource = null;
                dgvMemberList.DataSource = source;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load product list");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var OrderDetail = new OrderDetail
                {
                    OrderId = int.Parse(txtOrderID.Text),
                    ProductId = int.Parse(txtProductID.Text),
                    Discount = double.Parse(txtDiscount.Text.ToString()),
                    Quantity = int.Parse(txtQuantity.Text.ToString()),
                    UnitPrice = decimal.Parse(txtUnitPrice.Text.ToString()),
                };
                if (InsertOrUpdate == false)
                {
                    OrderDetailRepository.AddNewOrderDetail(OrderDetail);
                }
                else
                {
                    OrderDetailRepository.UpdateOrderDetail(OrderDetail);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new Order detail" : "Update an order detail");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadMemberList();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
