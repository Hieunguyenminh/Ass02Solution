namespace SalesWinApp
{
    partial class frmOrderManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbOrderID = new System.Windows.Forms.Label();
            this.lbMemberID = new System.Windows.Forms.Label();
            this.lbOrderDate = new System.Windows.Forms.Label();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.txtMemberID = new System.Windows.Forms.TextBox();
            this.txtOrderDate = new System.Windows.Forms.TextBox();
            this.lbRequiredDate = new System.Windows.Forms.Label();
            this.lbCountry = new System.Windows.Forms.Label();
            this.lbFreight = new System.Windows.Forms.Label();
            this.txtRequiredDate = new System.Windows.Forms.TextBox();
            this.txtShippedDate = new System.Windows.Forms.TextBox();
            this.txtFreight = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lbReport = new System.Windows.Forms.Label();
            this.txtFromNum = new System.Windows.Forms.TextBox();
            this.txtToNum = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvMemberList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemberList)).BeginInit();
            this.SuspendLayout();
            // 
            // lbOrderID
            // 
            this.lbOrderID.AutoSize = true;
            this.lbOrderID.Location = new System.Drawing.Point(85, 116);
            this.lbOrderID.Name = "lbOrderID";
            this.lbOrderID.Size = new System.Drawing.Size(66, 20);
            this.lbOrderID.TabIndex = 0;
            this.lbOrderID.Text = "Order ID";
            // 
            // lbMemberID
            // 
            this.lbMemberID.AutoSize = true;
            this.lbMemberID.Location = new System.Drawing.Point(85, 169);
            this.lbMemberID.Name = "lbMemberID";
            this.lbMemberID.Size = new System.Drawing.Size(84, 20);
            this.lbMemberID.TabIndex = 1;
            this.lbMemberID.Text = "Member ID";
            // 
            // lbOrderDate
            // 
            this.lbOrderDate.AutoSize = true;
            this.lbOrderDate.Location = new System.Drawing.Point(85, 218);
            this.lbOrderDate.Name = "lbOrderDate";
            this.lbOrderDate.Size = new System.Drawing.Size(83, 20);
            this.lbOrderDate.TabIndex = 2;
            this.lbOrderDate.Text = "Order Date";
            // 
            // txtOrderID
            // 
            this.txtOrderID.Location = new System.Drawing.Point(182, 109);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(218, 27);
            this.txtOrderID.TabIndex = 3;
            // 
            // txtMemberID
            // 
            this.txtMemberID.Location = new System.Drawing.Point(182, 166);
            this.txtMemberID.Name = "txtMemberID";
            this.txtMemberID.Size = new System.Drawing.Size(218, 27);
            this.txtMemberID.TabIndex = 4;
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.Location = new System.Drawing.Point(182, 215);
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.Size = new System.Drawing.Size(218, 27);
            this.txtOrderDate.TabIndex = 5;
            // 
            // lbRequiredDate
            // 
            this.lbRequiredDate.AutoSize = true;
            this.lbRequiredDate.Location = new System.Drawing.Point(465, 109);
            this.lbRequiredDate.Name = "lbRequiredDate";
            this.lbRequiredDate.Size = new System.Drawing.Size(105, 20);
            this.lbRequiredDate.TabIndex = 6;
            this.lbRequiredDate.Text = "Required Date";
            // 
            // lbCountry
            // 
            this.lbCountry.AutoSize = true;
            this.lbCountry.Location = new System.Drawing.Point(465, 169);
            this.lbCountry.Name = "lbCountry";
            this.lbCountry.Size = new System.Drawing.Size(100, 20);
            this.lbCountry.TabIndex = 7;
            this.lbCountry.Text = "Shipped Date";
            // 
            // lbFreight
            // 
            this.lbFreight.AutoSize = true;
            this.lbFreight.Location = new System.Drawing.Point(465, 218);
            this.lbFreight.Name = "lbFreight";
            this.lbFreight.Size = new System.Drawing.Size(55, 20);
            this.lbFreight.TabIndex = 8;
            this.lbFreight.Text = "Freight";
            // 
            // txtRequiredDate
            // 
            this.txtRequiredDate.Location = new System.Drawing.Point(576, 109);
            this.txtRequiredDate.Name = "txtRequiredDate";
            this.txtRequiredDate.Size = new System.Drawing.Size(218, 27);
            this.txtRequiredDate.TabIndex = 9;
            // 
            // txtShippedDate
            // 
            this.txtShippedDate.Location = new System.Drawing.Point(576, 169);
            this.txtShippedDate.Name = "txtShippedDate";
            this.txtShippedDate.Size = new System.Drawing.Size(218, 27);
            this.txtShippedDate.TabIndex = 10;
            // 
            // txtFreight
            // 
            this.txtFreight.Location = new System.Drawing.Point(576, 218);
            this.txtFreight.Name = "txtFreight";
            this.txtFreight.Size = new System.Drawing.Size(218, 27);
            this.txtFreight.TabIndex = 11;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(182, 273);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(94, 29);
            this.btnLoad.TabIndex = 12;
            this.btnLoad.Text = "&Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(441, 273);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(94, 29);
            this.btnNew.TabIndex = 13;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(685, 273);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 29);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lbReport
            // 
            this.lbReport.AutoSize = true;
            this.lbReport.Location = new System.Drawing.Point(85, 325);
            this.lbReport.Name = "lbReport";
            this.lbReport.Size = new System.Drawing.Size(92, 20);
            this.lbReport.TabIndex = 15;
            this.lbReport.Text = "Sales Report";
            // 
            // txtFromNum
            // 
            this.txtFromNum.Location = new System.Drawing.Point(182, 322);
            this.txtFromNum.Name = "txtFromNum";
            this.txtFromNum.Size = new System.Drawing.Size(218, 27);
            this.txtFromNum.TabIndex = 16;
            this.txtFromNum.Text = "From Date";
            // 
            // txtToNum
            // 
            this.txtToNum.Location = new System.Drawing.Point(441, 325);
            this.txtToNum.Name = "txtToNum";
            this.txtToNum.Size = new System.Drawing.Size(218, 27);
            this.txtToNum.TabIndex = 17;
            this.txtToNum.Text = "To Date";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(685, 325);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 29);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvMemberList
            // 
            this.dgvMemberList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMemberList.Location = new System.Drawing.Point(-2, 368);
            this.dgvMemberList.Name = "dgvMemberList";
            this.dgvMemberList.ReadOnly = true;
            this.dgvMemberList.RowHeadersWidth = 51;
            this.dgvMemberList.RowTemplate.Height = 29;
            this.dgvMemberList.Size = new System.Drawing.Size(864, 242);
            this.dgvMemberList.TabIndex = 19;
            // 
            // frmOrderManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 531);
            this.Controls.Add(this.dgvMemberList);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtToNum);
            this.Controls.Add(this.txtFromNum);
            this.Controls.Add(this.lbReport);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtFreight);
            this.Controls.Add(this.txtShippedDate);
            this.Controls.Add(this.txtRequiredDate);
            this.Controls.Add(this.lbFreight);
            this.Controls.Add(this.lbCountry);
            this.Controls.Add(this.lbRequiredDate);
            this.Controls.Add(this.txtOrderDate);
            this.Controls.Add(this.txtMemberID);
            this.Controls.Add(this.txtOrderID);
            this.Controls.Add(this.lbOrderDate);
            this.Controls.Add(this.lbMemberID);
            this.Controls.Add(this.lbOrderID);
            this.Name = "frmOrderManagement";
            this.Text = "frmOrderManagement";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemberList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbOrderID;
        private Label lbMemberID;
        private Label lbOrderDate;
        private TextBox txtOrderID;
        private TextBox txtMemberID;
        private TextBox txtOrderDate;
        private Label lbRequiredDate;
        private Label lbCountry;
        private Label lbFreight;
        private TextBox txtRequiredDate;
        private TextBox txtShippedDate;
        private TextBox txtFreight;
        private Button btnLoad;
        private Button btnNew;
        private Button btnDelete;
        private Label lbReport;
        private TextBox txtFromNum;
        private TextBox txtToNum;
        private Button btnSearch;
        private DataGridView dgvMemberList;
    }
}