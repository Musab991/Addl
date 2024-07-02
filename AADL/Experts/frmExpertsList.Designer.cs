namespace AADL.Experts
{
    partial class frmExpertsList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cbPage = new System.Windows.Forms.ComboBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalRecordsCount = new System.Windows.Forms.Label();
            this.dgvExperts = new System.Windows.Forms.DataGridView();
            this.cmsExperts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activateExpertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deactivateExpertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteExpertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbIsActive = new System.Windows.Forms.ComboBox();
            this.btnPreviousPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbSubscriptionType = new System.Windows.Forms.ComboBox();
            this.cbSubscriptionWay = new System.Windows.Forms.ComboBox();
            this.btnAddNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExperts)).BeginInit();
            this.cmsExperts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtFilterValue.Location = new System.Drawing.Point(428, 301);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFilterValue.Multiline = true;
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFilterValue.Size = new System.Drawing.Size(285, 28);
            this.txtFilterValue.TabIndex = 142;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // cbPage
            // 
            this.cbPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbPage.FormattingEnabled = true;
            this.cbPage.Location = new System.Drawing.Point(908, 301);
            this.cbPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbPage.Name = "cbPage";
            this.cbPage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbPage.Size = new System.Drawing.Size(129, 28);
            this.cbPage.TabIndex = 143;
            this.cbPage.SelectedIndexChanged += new System.EventHandler(this.cbPage_SelectedIndexChanged);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "لا شيء",
            "الرقم التعريفي",
            "الاسم",
            "رقم الهاتف",
            "البريد الالكتروني",
            "نوع الاشتراك",
            "طريقة الاشتراك",
            "هل فعال ؟"});
            this.cbFilterBy.Location = new System.Drawing.Point(179, 301);
            this.cbFilterBy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbFilterBy.Size = new System.Drawing.Size(231, 28);
            this.cbFilterBy.TabIndex = 141;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(37, 802);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(99, 25);
            this.label2.TabIndex = 146;
            this.label2.Text = "# السجلات:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(819, 304);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 25);
            this.label3.TabIndex = 149;
            this.label3.Text = "الصفحة:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(37, 304);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 25);
            this.label5.TabIndex = 148;
            this.label5.Text = "البحث بواسطة:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 19.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(12, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1500, 52);
            this.label1.TabIndex = 145;
            this.label1.Text = "إدارة الخبراء";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalRecordsCount
            // 
            this.lblTotalRecordsCount.AutoSize = true;
            this.lblTotalRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalRecordsCount.ForeColor = System.Drawing.Color.Black;
            this.lblTotalRecordsCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTotalRecordsCount.Location = new System.Drawing.Point(173, 802);
            this.lblTotalRecordsCount.Name = "lblTotalRecordsCount";
            this.lblTotalRecordsCount.Size = new System.Drawing.Size(24, 25);
            this.lblTotalRecordsCount.TabIndex = 147;
            this.lblTotalRecordsCount.Text = "0";
            // 
            // dgvExperts
            // 
            this.dgvExperts.AllowUserToAddRows = false;
            this.dgvExperts.AllowUserToDeleteRows = false;
            this.dgvExperts.AllowUserToOrderColumns = true;
            this.dgvExperts.AllowUserToResizeRows = false;
            this.dgvExperts.BackgroundColor = System.Drawing.Color.White;
            this.dgvExperts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvExperts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(54)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExperts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvExperts.ColumnHeadersHeight = 40;
            this.dgvExperts.GridColor = System.Drawing.Color.DarkGray;
            this.dgvExperts.Location = new System.Drawing.Point(43, 342);
            this.dgvExperts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvExperts.Name = "dgvExperts";
            this.dgvExperts.ReadOnly = true;
            this.dgvExperts.RowHeadersWidth = 51;
            this.dgvExperts.RowTemplate.Height = 25;
            this.dgvExperts.Size = new System.Drawing.Size(1437, 447);
            this.dgvExperts.StandardTab = true;
            this.dgvExperts.TabIndex = 140;
            this.dgvExperts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExperts_CellDoubleClick);
            this.dgvExperts.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvExperts_CellMouseDown);
            // 
            // cmsExperts
            // 
            this.cmsExperts.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmsExperts.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsExperts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInfoToolStripMenuItem,
            this.activateExpertToolStripMenuItem,
            this.deactivateExpertToolStripMenuItem,
            this.deleteExpertToolStripMenuItem});
            this.cmsExperts.Name = "cmsJudgers";
            this.cmsExperts.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmsExperts.Size = new System.Drawing.Size(234, 171);
            this.cmsExperts.Opening += new System.ComponentModel.CancelEventHandler(this.cmsExperts_Opening);
            // 
            // showInfoToolStripMenuItem
            // 
            this.showInfoToolStripMenuItem.Image = global::AADL.Properties.Resources.show_info_32;
            this.showInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showInfoToolStripMenuItem.Name = "showInfoToolStripMenuItem";
            this.showInfoToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 1, 0, 6);
            this.showInfoToolStripMenuItem.Size = new System.Drawing.Size(233, 43);
            this.showInfoToolStripMenuItem.Text = "عرض المعلومات";
            this.showInfoToolStripMenuItem.Click += new System.EventHandler(this.showInfoToolStripMenuItem_Click);
            // 
            // activateExpertToolStripMenuItem
            // 
            this.activateExpertToolStripMenuItem.Image = global::AADL.Properties.Resources.activate_32_abdalla;
            this.activateExpertToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.activateExpertToolStripMenuItem.Name = "activateExpertToolStripMenuItem";
            this.activateExpertToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 1, 0, 6);
            this.activateExpertToolStripMenuItem.Size = new System.Drawing.Size(233, 43);
            this.activateExpertToolStripMenuItem.Text = "تفعيل الحساب";
            this.activateExpertToolStripMenuItem.Click += new System.EventHandler(this.activateExpertToolStripMenuItem_Click);
            // 
            // deactivateExpertToolStripMenuItem
            // 
            this.deactivateExpertToolStripMenuItem.Image = global::AADL.Properties.Resources.deactivate_32_abdalla;
            this.deactivateExpertToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deactivateExpertToolStripMenuItem.Name = "deactivateExpertToolStripMenuItem";
            this.deactivateExpertToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 1, 0, 6);
            this.deactivateExpertToolStripMenuItem.Size = new System.Drawing.Size(233, 43);
            this.deactivateExpertToolStripMenuItem.Text = "إلغاء تفعيل الحساب";
            this.deactivateExpertToolStripMenuItem.Click += new System.EventHandler(this.deactivateExpertToolStripMenuItem_Click);
            // 
            // deleteExpertToolStripMenuItem
            // 
            this.deleteExpertToolStripMenuItem.Image = global::AADL.Properties.Resources.delete_32_abdalla;
            this.deleteExpertToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteExpertToolStripMenuItem.Name = "deleteExpertToolStripMenuItem";
            this.deleteExpertToolStripMenuItem.Size = new System.Drawing.Size(233, 38);
            this.deleteExpertToolStripMenuItem.Text = "حذف الحساب نهائيا";
            this.deleteExpertToolStripMenuItem.Click += new System.EventHandler(this.deleteExpertToolStripMenuItem_Click);
            // 
            // cbIsActive
            // 
            this.cbIsActive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbIsActive.FormattingEnabled = true;
            this.cbIsActive.Items.AddRange(new object[] {
            "الكل",
            "نعم",
            "لا"});
            this.cbIsActive.Location = new System.Drawing.Point(428, 301);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbIsActive.Size = new System.Drawing.Size(130, 28);
            this.cbIsActive.TabIndex = 150;
            this.cbIsActive.SelectedIndexChanged += new System.EventHandler(this.cbIsActive_SelectedIndexChanged);
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreviousPage.FlatAppearance.BorderSize = 0;
            this.btnPreviousPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviousPage.Image = global::AADL.Properties.Resources.right_arrow_24;
            this.btnPreviousPage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPreviousPage.Location = new System.Drawing.Point(1061, 297);
            this.btnPreviousPage.Margin = new System.Windows.Forms.Padding(4);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(44, 35);
            this.btnPreviousPage.TabIndex = 163;
            this.btnPreviousPage.UseVisualStyleBackColor = true;
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextPage.FlatAppearance.BorderSize = 0;
            this.btnNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextPage.Image = global::AADL.Properties.Resources.left_arrow_24;
            this.btnNextPage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNextPage.Location = new System.Drawing.Point(1113, 297);
            this.btnNextPage.Margin = new System.Windows.Forms.Padding(4);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(44, 35);
            this.btnNextPage.TabIndex = 162;
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AADL.Properties.Resources.expert_512;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(644, 22);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(237, 162);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 144;
            this.pictureBox1.TabStop = false;
            // 
            // cbSubscriptionType
            // 
            this.cbSubscriptionType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbSubscriptionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubscriptionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbSubscriptionType.FormattingEnabled = true;
            this.cbSubscriptionType.Items.AddRange(new object[] {
            "الكل",
            "نعم",
            "لا"});
            this.cbSubscriptionType.Location = new System.Drawing.Point(429, 300);
            this.cbSubscriptionType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSubscriptionType.Name = "cbSubscriptionType";
            this.cbSubscriptionType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbSubscriptionType.Size = new System.Drawing.Size(129, 28);
            this.cbSubscriptionType.TabIndex = 164;
            this.cbSubscriptionType.SelectedIndexChanged += new System.EventHandler(this.cbSubscriptionType_SelectedIndexChanged);
            // 
            // cbSubscriptionWay
            // 
            this.cbSubscriptionWay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbSubscriptionWay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubscriptionWay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbSubscriptionWay.FormattingEnabled = true;
            this.cbSubscriptionWay.Items.AddRange(new object[] {
            "الكل",
            "نعم",
            "لا"});
            this.cbSubscriptionWay.Location = new System.Drawing.Point(429, 300);
            this.cbSubscriptionWay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSubscriptionWay.Name = "cbSubscriptionWay";
            this.cbSubscriptionWay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbSubscriptionWay.Size = new System.Drawing.Size(129, 28);
            this.cbSubscriptionWay.TabIndex = 165;
            this.cbSubscriptionWay.SelectedIndexChanged += new System.EventHandler(this.cbSubscriptionWay_SelectedIndexChanged);
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackgroundImage = global::AADL.Properties.Resources.add;
            this.btnAddNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNew.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAddNew.Location = new System.Drawing.Point(1417, 278);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(63, 50);
            this.btnAddNew.TabIndex = 166;
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // frmExpertsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1524, 849);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.cbSubscriptionWay);
            this.Controls.Add(this.cbSubscriptionType);
            this.Controls.Add(this.btnPreviousPage);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.cbPage);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTotalRecordsCount);
            this.Controls.Add(this.dgvExperts);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtFilterValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmExpertsList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نافذة الخبراء";
            this.Load += new System.EventHandler(this.frmExpertsList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExperts)).EndInit();
            this.cmsExperts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cbPage;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalRecordsCount;
        private System.Windows.Forms.DataGridView dgvExperts;
        private System.Windows.Forms.ContextMenuStrip cmsExperts;
        private System.Windows.Forms.ToolStripMenuItem showInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activateExpertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deactivateExpertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteExpertToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbIsActive;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnPreviousPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.ComboBox cbSubscriptionType;
        private System.Windows.Forms.ComboBox cbSubscriptionWay;
        private System.Windows.Forms.Button btnAddNew;
    }
}