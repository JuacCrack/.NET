namespace contactbook
{
    partial class contactdetails
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
            this.name = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtcompany = new System.Windows.Forms.TextBox();
            this.company = new System.Windows.Forms.Label();
            this.profile = new System.Windows.Forms.Label();
            this.image = new System.Windows.Forms.Label();
            this.txtimage = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.Label();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.birthdate = new System.Windows.Forms.Label();
            this.txtbirthdate = new System.Windows.Forms.TextBox();
            this.txtphonew = new System.Windows.Forms.TextBox();
            this.phonew = new System.Windows.Forms.Label();
            this.txtphonep = new System.Windows.Forms.TextBox();
            this.phonep = new System.Windows.Forms.Label();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.address = new System.Windows.Forms.Label();
            this.txtprof = new System.Windows.Forms.Label();
            this.txtprofile = new System.Windows.Forms.TextBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(14, 63);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(55, 20);
            this.name.TabIndex = 0;
            this.name.Text = "Name";
            this.name.Click += new System.EventHandler(this.name_Click);
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(75, 65);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(226, 20);
            this.txtname.TabIndex = 1;
            this.txtname.TextChanged += new System.EventHandler(this.txtname_TextChanged);
            // 
            // txtcompany
            // 
            this.txtcompany.Location = new System.Drawing.Point(102, 105);
            this.txtcompany.Name = "txtcompany";
            this.txtcompany.Size = new System.Drawing.Size(199, 20);
            this.txtcompany.TabIndex = 2;
            this.txtcompany.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // company
            // 
            this.company.AutoSize = true;
            this.company.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.company.Location = new System.Drawing.Point(13, 103);
            this.company.Name = "company";
            this.company.Size = new System.Drawing.Size(83, 20);
            this.company.TabIndex = 3;
            this.company.Text = "Company";
            this.company.Click += new System.EventHandler(this.label1_Click);
            // 
            // profile
            // 
            this.profile.AutoSize = true;
            this.profile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profile.Location = new System.Drawing.Point(14, 139);
            this.profile.Name = "profile";
            this.profile.Size = new System.Drawing.Size(60, 20);
            this.profile.TabIndex = 4;
            this.profile.Text = "Profile";
            this.profile.Click += new System.EventHandler(this.label2_Click);
            // 
            // image
            // 
            this.image.AutoSize = true;
            this.image.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.image.Location = new System.Drawing.Point(14, 180);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(59, 20);
            this.image.TabIndex = 6;
            this.image.Text = "Image";
            this.image.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtimage
            // 
            this.txtimage.Location = new System.Drawing.Point(75, 182);
            this.txtimage.Name = "txtimage";
            this.txtimage.Size = new System.Drawing.Size(226, 20);
            this.txtimage.TabIndex = 7;
            // 
            // email
            // 
            this.email.AutoSize = true;
            this.email.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email.Location = new System.Drawing.Point(15, 214);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(53, 20);
            this.email.TabIndex = 8;
            this.email.Text = "Email";
            this.email.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(80, 216);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(221, 20);
            this.txtemail.TabIndex = 9;
            // 
            // birthdate
            // 
            this.birthdate.AutoSize = true;
            this.birthdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.birthdate.Location = new System.Drawing.Point(15, 258);
            this.birthdate.Name = "birthdate";
            this.birthdate.Size = new System.Drawing.Size(83, 20);
            this.birthdate.TabIndex = 10;
            this.birthdate.Text = "Birthdate";
            this.birthdate.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtbirthdate
            // 
            this.txtbirthdate.Location = new System.Drawing.Point(102, 259);
            this.txtbirthdate.Name = "txtbirthdate";
            this.txtbirthdate.Size = new System.Drawing.Size(199, 20);
            this.txtbirthdate.TabIndex = 11;
            // 
            // txtphonew
            // 
            this.txtphonew.Location = new System.Drawing.Point(102, 298);
            this.txtphonew.Name = "txtphonew";
            this.txtphonew.Size = new System.Drawing.Size(199, 20);
            this.txtphonew.TabIndex = 13;
            this.txtphonew.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // phonew
            // 
            this.phonew.AutoSize = true;
            this.phonew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phonew.Location = new System.Drawing.Point(15, 296);
            this.phonew.Name = "phonew";
            this.phonew.Size = new System.Drawing.Size(81, 20);
            this.phonew.TabIndex = 12;
            this.phonew.Text = "Phone W";
            this.phonew.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtphonep
            // 
            this.txtphonep.Location = new System.Drawing.Point(102, 336);
            this.txtphonep.Name = "txtphonep";
            this.txtphonep.Size = new System.Drawing.Size(199, 20);
            this.txtphonep.TabIndex = 15;
            // 
            // phonep
            // 
            this.phonep.AutoSize = true;
            this.phonep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phonep.Location = new System.Drawing.Point(15, 334);
            this.phonep.Name = "phonep";
            this.phonep.Size = new System.Drawing.Size(76, 20);
            this.phonep.TabIndex = 14;
            this.phonep.Text = "Phone P";
            this.phonep.Click += new System.EventHandler(this.label7_Click);
            // 
            // txtaddress
            // 
            this.txtaddress.Location = new System.Drawing.Point(108, 371);
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(193, 20);
            this.txtaddress.TabIndex = 17;
            // 
            // address
            // 
            this.address.AutoSize = true;
            this.address.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address.Location = new System.Drawing.Point(21, 369);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(75, 20);
            this.address.TabIndex = 16;
            this.address.Text = "Address";
            // 
            // txtprof
            // 
            this.txtprof.AutoSize = true;
            this.txtprof.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtprof.Location = new System.Drawing.Point(97, 30);
            this.txtprof.Name = "txtprof";
            this.txtprof.Size = new System.Drawing.Size(141, 25);
            this.txtprof.TabIndex = 18;
            this.txtprof.Text = "Add Contact";
            // 
            // txtprofile
            // 
            this.txtprofile.Location = new System.Drawing.Point(75, 141);
            this.txtprofile.Name = "txtprofile";
            this.txtprofile.Size = new System.Drawing.Size(226, 20);
            this.txtprofile.TabIndex = 19;
            // 
            // btnsave
            // 
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.Location = new System.Drawing.Point(108, 410);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(33, 31);
            this.btnsave.TabIndex = 20;
            this.btnsave.Text = "✔️";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btncancel
            // 
            this.btncancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.Location = new System.Drawing.Point(172, 410);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(33, 31);
            this.btncancel.TabIndex = 21;
            this.btncancel.Text = "❌";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // contactdetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 450);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.txtprofile);
            this.Controls.Add(this.txtprof);
            this.Controls.Add(this.txtaddress);
            this.Controls.Add(this.address);
            this.Controls.Add(this.txtphonep);
            this.Controls.Add(this.phonep);
            this.Controls.Add(this.txtphonew);
            this.Controls.Add(this.phonew);
            this.Controls.Add(this.txtbirthdate);
            this.Controls.Add(this.birthdate);
            this.Controls.Add(this.txtemail);
            this.Controls.Add(this.email);
            this.Controls.Add(this.txtimage);
            this.Controls.Add(this.image);
            this.Controls.Add(this.profile);
            this.Controls.Add(this.company);
            this.Controls.Add(this.txtcompany);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.name);
            this.Name = "contactdetails";
            this.Text = "contactdetails";
            this.Load += new System.EventHandler(this.contactdetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label name;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtcompany;
        private System.Windows.Forms.Label company;
        private System.Windows.Forms.Label profile;
        private System.Windows.Forms.Label image;
        private System.Windows.Forms.TextBox txtimage;
        private System.Windows.Forms.Label email;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.Label birthdate;
        private System.Windows.Forms.TextBox txtbirthdate;
        private System.Windows.Forms.TextBox txtphonew;
        private System.Windows.Forms.Label phonew;
        private System.Windows.Forms.TextBox txtphonep;
        private System.Windows.Forms.Label phonep;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.Label address;
        private System.Windows.Forms.Label txtprof;
        private System.Windows.Forms.TextBox txtprofile;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btncancel;
    }
}