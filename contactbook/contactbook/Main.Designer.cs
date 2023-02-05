namespace contactbook
{
    partial class Main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gridcontacts = new System.Windows.Forms.DataGridView();
            this.search = new System.Windows.Forms.Label();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.btnsearch = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Label();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtcompanyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtprofileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtimageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtemailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtbirthdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtphonewDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtphonepDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtaddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridcontacts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridcontacts
            // 
            this.gridcontacts.AutoGenerateColumns = false;
            this.gridcontacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridcontacts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.txtnameDataGridViewTextBoxColumn,
            this.txtcompanyDataGridViewTextBoxColumn,
            this.txtprofileDataGridViewTextBoxColumn,
            this.txtimageDataGridViewTextBoxColumn,
            this.txtemailDataGridViewTextBoxColumn,
            this.txtbirthdateDataGridViewTextBoxColumn,
            this.txtphonewDataGridViewTextBoxColumn,
            this.txtphonepDataGridViewTextBoxColumn,
            this.txtaddressDataGridViewTextBoxColumn,
            this.Edit,
            this.Delete});
            this.gridcontacts.DataSource = this.contactBindingSource;
            this.gridcontacts.Location = new System.Drawing.Point(12, 89);
            this.gridcontacts.Name = "gridcontacts";
            this.gridcontacts.Size = new System.Drawing.Size(776, 349);
            this.gridcontacts.TabIndex = 0;
            this.gridcontacts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridcontacts_CellContentClick);
            // 
            // search
            // 
            this.search.AutoSize = true;
            this.search.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search.Location = new System.Drawing.Point(12, 37);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(64, 23);
            this.search.TabIndex = 1;
            this.search.Text = "Search";
            // 
            // txtsearch
            // 
            this.txtsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearch.Location = new System.Drawing.Point(82, 37);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(324, 26);
            this.txtsearch.TabIndex = 2;
            // 
            // btnsearch
            // 
            this.btnsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearch.Location = new System.Drawing.Point(412, 30);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(41, 36);
            this.btnsearch.TabIndex = 3;
            this.btnsearch.Text = "🔎";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // btnadd
            // 
            this.btnadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.Location = new System.Drawing.Point(750, 27);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(38, 33);
            this.btnadd.TabIndex = 4;
            this.btnadd.Text = "+";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // add
            // 
            this.add.AutoSize = true;
            this.add.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add.Location = new System.Drawing.Point(704, 30);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(40, 23);
            this.add.TabIndex = 5;
            this.add.Text = "Add";
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Edit";
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Text = "Edit";
            this.Edit.UseColumnTextForLinkValue = true;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "Delete";
            this.Delete.UseColumnTextForLinkValue = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // txtnameDataGridViewTextBoxColumn
            // 
            this.txtnameDataGridViewTextBoxColumn.DataPropertyName = "txtname";
            this.txtnameDataGridViewTextBoxColumn.HeaderText = "txtname";
            this.txtnameDataGridViewTextBoxColumn.Name = "txtnameDataGridViewTextBoxColumn";
            // 
            // txtcompanyDataGridViewTextBoxColumn
            // 
            this.txtcompanyDataGridViewTextBoxColumn.DataPropertyName = "txtcompany";
            this.txtcompanyDataGridViewTextBoxColumn.HeaderText = "txtcompany";
            this.txtcompanyDataGridViewTextBoxColumn.Name = "txtcompanyDataGridViewTextBoxColumn";
            // 
            // txtprofileDataGridViewTextBoxColumn
            // 
            this.txtprofileDataGridViewTextBoxColumn.DataPropertyName = "txtprofile";
            this.txtprofileDataGridViewTextBoxColumn.HeaderText = "txtprofile";
            this.txtprofileDataGridViewTextBoxColumn.Name = "txtprofileDataGridViewTextBoxColumn";
            // 
            // txtimageDataGridViewTextBoxColumn
            // 
            this.txtimageDataGridViewTextBoxColumn.DataPropertyName = "txtimage";
            this.txtimageDataGridViewTextBoxColumn.HeaderText = "txtimage";
            this.txtimageDataGridViewTextBoxColumn.Name = "txtimageDataGridViewTextBoxColumn";
            // 
            // txtemailDataGridViewTextBoxColumn
            // 
            this.txtemailDataGridViewTextBoxColumn.DataPropertyName = "txtemail";
            this.txtemailDataGridViewTextBoxColumn.HeaderText = "txtemail";
            this.txtemailDataGridViewTextBoxColumn.Name = "txtemailDataGridViewTextBoxColumn";
            // 
            // txtbirthdateDataGridViewTextBoxColumn
            // 
            this.txtbirthdateDataGridViewTextBoxColumn.DataPropertyName = "txtbirthdate";
            this.txtbirthdateDataGridViewTextBoxColumn.HeaderText = "txtbirthdate";
            this.txtbirthdateDataGridViewTextBoxColumn.Name = "txtbirthdateDataGridViewTextBoxColumn";
            // 
            // txtphonewDataGridViewTextBoxColumn
            // 
            this.txtphonewDataGridViewTextBoxColumn.DataPropertyName = "txtphonew";
            this.txtphonewDataGridViewTextBoxColumn.HeaderText = "txtphonew";
            this.txtphonewDataGridViewTextBoxColumn.Name = "txtphonewDataGridViewTextBoxColumn";
            // 
            // txtphonepDataGridViewTextBoxColumn
            // 
            this.txtphonepDataGridViewTextBoxColumn.DataPropertyName = "txtphonep";
            this.txtphonepDataGridViewTextBoxColumn.HeaderText = "txtphonep";
            this.txtphonepDataGridViewTextBoxColumn.Name = "txtphonepDataGridViewTextBoxColumn";
            // 
            // txtaddressDataGridViewTextBoxColumn
            // 
            this.txtaddressDataGridViewTextBoxColumn.DataPropertyName = "txtaddress";
            this.txtaddressDataGridViewTextBoxColumn.HeaderText = "txtaddress";
            this.txtaddressDataGridViewTextBoxColumn.Name = "txtaddressDataGridViewTextBoxColumn";
            // 
            // contactBindingSource
            // 
            this.contactBindingSource.DataSource = typeof(contactbook.Contact);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.add);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.search);
            this.Controls.Add(this.gridcontacts);
            this.Name = "Main";
            this.Text = "Contacts";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridcontacts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridcontacts;
        private System.Windows.Forms.Label search;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Label add;
        private System.Windows.Forms.BindingSource contactBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtcompanyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtprofileDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtimageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtemailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtbirthdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtphonewDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtphonepDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtaddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
    }
}

