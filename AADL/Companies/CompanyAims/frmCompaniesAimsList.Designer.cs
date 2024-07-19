namespace AADL.Companies.CompanyAims
{
    partial class frmCompaniesAimsList
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalRecordsCount = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.dgvAims = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmsAims = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAddNew = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.editAimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAims)).BeginInit();
            this.cmsAims.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(41, 752);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(99, 25);
            this.label2.TabIndex = 178;
            this.label2.Text = "# السجلات:";
            // 
            // lblTotalRecordsCount
            // 
            this.lblTotalRecordsCount.AutoSize = true;
            this.lblTotalRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalRecordsCount.ForeColor = System.Drawing.Color.Black;
            this.lblTotalRecordsCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTotalRecordsCount.Location = new System.Drawing.Point(177, 752);
            this.lblTotalRecordsCount.Name = "lblTotalRecordsCount";
            this.lblTotalRecordsCount.Size = new System.Drawing.Size(24, 25);
            this.lblTotalRecordsCount.TabIndex = 179;
            this.lblTotalRecordsCount.Text = "0";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "لا شيء",
            "الرقم",
            "الاسم"});
            this.cbFilterBy.Location = new System.Drawing.Point(181, 295);
            this.cbFilterBy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbFilterBy.Size = new System.Drawing.Size(123, 28);
            this.cbFilterBy.TabIndex = 175;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(41, 298);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 25);
            this.label5.TabIndex = 177;
            this.label5.Text = "البحث بواسطة:";
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtFilterValue.Location = new System.Drawing.Point(310, 295);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFilterValue.Multiline = true;
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFilterValue.Size = new System.Drawing.Size(205, 28);
            this.txtFilterValue.TabIndex = 176;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // dgvAims
            // 
            this.dgvAims.AllowUserToAddRows = false;
            this.dgvAims.AllowUserToDeleteRows = false;
            this.dgvAims.AllowUserToOrderColumns = true;
            this.dgvAims.AllowUserToResizeRows = false;
            this.dgvAims.BackgroundColor = System.Drawing.Color.White;
            this.dgvAims.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvAims.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(54)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAims.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAims.ColumnHeadersHeight = 40;
            this.dgvAims.GridColor = System.Drawing.Color.DarkGray;
            this.dgvAims.Location = new System.Drawing.Point(46, 336);
            this.dgvAims.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvAims.Name = "dgvAims";
            this.dgvAims.ReadOnly = true;
            this.dgvAims.RowHeadersWidth = 51;
            this.dgvAims.RowTemplate.Height = 25;
            this.dgvAims.Size = new System.Drawing.Size(701, 403);
            this.dgvAims.StandardTab = true;
            this.dgvAims.TabIndex = 174;
            this.dgvAims.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAims_CellMouseDown);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 19.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(12, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(768, 52);
            this.label1.TabIndex = 173;
            this.label1.Text = "إدارة اهداف الشركات";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmsAims
            // 
            this.cmsAims.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmsAims.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsAims.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editAimToolStripMenuItem,
            this.deleteAimToolStripMenuItem});
            this.cmsAims.Name = "cmsJudgers";
            this.cmsAims.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmsAims.Size = new System.Drawing.Size(227, 113);
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackgroundImage = global::AADL.Properties.Resources.add;
            this.btnAddNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNew.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAddNew.Location = new System.Drawing.Point(684, 273);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(63, 50);
            this.btnAddNew.TabIndex = 180;
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AADL.Properties.Resources.companies_amis_512;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(278, 33);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(237, 162);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 172;
            this.pictureBox1.TabStop = false;
            // 
            // editAimToolStripMenuItem
            // 
            this.editAimToolStripMenuItem.Image = global::AADL.Properties.Resources.edit_32;
            this.editAimToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editAimToolStripMenuItem.Name = "editAimToolStripMenuItem";
            this.editAimToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 1, 0, 6);
            this.editAimToolStripMenuItem.Size = new System.Drawing.Size(226, 43);
            this.editAimToolStripMenuItem.Text = "تعديل";
            this.editAimToolStripMenuItem.Click += new System.EventHandler(this.editAimToolStripMenuItem_Click);
            // 
            // deleteAimToolStripMenuItem
            // 
            this.deleteAimToolStripMenuItem.Image = global::AADL.Properties.Resources.delete_32_abdalla;
            this.deleteAimToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteAimToolStripMenuItem.Name = "deleteAimToolStripMenuItem";
            this.deleteAimToolStripMenuItem.Size = new System.Drawing.Size(226, 38);
            this.deleteAimToolStripMenuItem.Text = "حذف";
            this.deleteAimToolStripMenuItem.Click += new System.EventHandler(this.deleteAimToolStripMenuItem_Click);
            // 
            // frmCompaniesAimsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(793, 796);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotalRecordsCount);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.dgvAims);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCompaniesAimsList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "إدارة اهداف الشركات";
            this.Load += new System.EventHandler(this.frmCompaniesAimsList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAims)).EndInit();
            this.cmsAims.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalRecordsCount;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.DataGridView dgvAims;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cmsAims;
        private System.Windows.Forms.ToolStripMenuItem editAimToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAimToolStripMenuItem;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}