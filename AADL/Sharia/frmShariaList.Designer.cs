namespace AADL.Sharia
{
    partial class frmShariaList
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
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnPreviousPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.cbSubscriptionWay = new System.Windows.Forms.ComboBox();
            this.cbIsActive = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cbPage = new System.Windows.Forms.ComboBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalRecordsCount = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvSharias = new System.Windows.Forms.DataGridView();
            this.cbSubscriptionType = new System.Windows.Forms.ComboBox();
            this.cmsSharias = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activateShariaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deactivateShariaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteShariaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSharias)).BeginInit();
            this.cmsSharias.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackgroundImage = global::AADL.Properties.Resources.add;
            this.btnAddNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNew.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAddNew.Location = new System.Drawing.Point(1063, 227);
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(47, 41);
            this.btnAddNew.TabIndex = 176;
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreviousPage.FlatAppearance.BorderSize = 0;
            this.btnPreviousPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviousPage.Image = global::AADL.Properties.Resources.right_arrow_24;
            this.btnPreviousPage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPreviousPage.Location = new System.Drawing.Point(793, 242);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(33, 28);
            this.btnPreviousPage.TabIndex = 175;
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
            this.btnNextPage.Location = new System.Drawing.Point(832, 242);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(33, 28);
            this.btnNextPage.TabIndex = 174;
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
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
            this.cbSubscriptionWay.Location = new System.Drawing.Point(321, 245);
            this.cbSubscriptionWay.Margin = new System.Windows.Forms.Padding(2);
            this.cbSubscriptionWay.Name = "cbSubscriptionWay";
            this.cbSubscriptionWay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbSubscriptionWay.Size = new System.Drawing.Size(98, 24);
            this.cbSubscriptionWay.TabIndex = 172;
            this.cbSubscriptionWay.SelectedIndexChanged += new System.EventHandler(this.cbSubscriptionWay_SelectedIndexChanged);
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
            this.cbIsActive.Location = new System.Drawing.Point(321, 245);
            this.cbIsActive.Margin = new System.Windows.Forms.Padding(2);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbIsActive.Size = new System.Drawing.Size(98, 24);
            this.cbIsActive.TabIndex = 171;
            this.cbIsActive.SelectedIndexChanged += new System.EventHandler(this.cbIsActive_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtFilterValue.Location = new System.Drawing.Point(321, 245);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(2);
            this.txtFilterValue.Multiline = true;
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFilterValue.Size = new System.Drawing.Size(214, 23);
            this.txtFilterValue.TabIndex = 163;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // cbPage
            // 
            this.cbPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbPage.FormattingEnabled = true;
            this.cbPage.Location = new System.Drawing.Point(681, 245);
            this.cbPage.Margin = new System.Windows.Forms.Padding(2);
            this.cbPage.Name = "cbPage";
            this.cbPage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbPage.Size = new System.Drawing.Size(98, 24);
            this.cbPage.TabIndex = 164;
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
            "رقم الاجازة الشرعية",
            "نوع الاشتراك",
            "طريقة الاشتراك",
            "هل فعال ؟"});
            this.cbFilterBy.Location = new System.Drawing.Point(134, 245);
            this.cbFilterBy.Margin = new System.Windows.Forms.Padding(2);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbFilterBy.Size = new System.Drawing.Size(174, 24);
            this.cbFilterBy.TabIndex = 162;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(28, 652);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 167;
            this.label2.Text = "# السجلات:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(614, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 170;
            this.label3.Text = "الصفحة:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(28, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 169;
            this.label5.Text = "البحث بواسطة:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 19.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(9, 152);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1125, 42);
            this.label1.TabIndex = 166;
            this.label1.Text = "إدارة الشرعيين";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalRecordsCount
            // 
            this.lblTotalRecordsCount.AutoSize = true;
            this.lblTotalRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalRecordsCount.ForeColor = System.Drawing.Color.Black;
            this.lblTotalRecordsCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTotalRecordsCount.Location = new System.Drawing.Point(130, 652);
            this.lblTotalRecordsCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalRecordsCount.Name = "lblTotalRecordsCount";
            this.lblTotalRecordsCount.Size = new System.Drawing.Size(19, 20);
            this.lblTotalRecordsCount.TabIndex = 168;
            this.lblTotalRecordsCount.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AADL.Properties.Resources.judge_512;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(483, 18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 132);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 165;
            this.pictureBox1.TabStop = false;
            // 
            // dgvSharias
            // 
            this.dgvSharias.AllowUserToAddRows = false;
            this.dgvSharias.AllowUserToDeleteRows = false;
            this.dgvSharias.AllowUserToOrderColumns = true;
            this.dgvSharias.AllowUserToResizeRows = false;
            this.dgvSharias.BackgroundColor = System.Drawing.Color.White;
            this.dgvSharias.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSharias.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(54)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSharias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSharias.ColumnHeadersHeight = 40;
            this.dgvSharias.GridColor = System.Drawing.Color.DarkGray;
            this.dgvSharias.Location = new System.Drawing.Point(32, 278);
            this.dgvSharias.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSharias.Name = "dgvSharias";
            this.dgvSharias.ReadOnly = true;
            this.dgvSharias.RowHeadersWidth = 51;
            this.dgvSharias.RowTemplate.Height = 25;
            this.dgvSharias.Size = new System.Drawing.Size(1078, 363);
            this.dgvSharias.StandardTab = true;
            this.dgvSharias.TabIndex = 161;
            this.dgvSharias.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSharias_CellDoubleClick);
            this.dgvSharias.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSharias_CellMouseDown);
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
            this.cbSubscriptionType.Location = new System.Drawing.Point(321, 245);
            this.cbSubscriptionType.Margin = new System.Windows.Forms.Padding(2);
            this.cbSubscriptionType.Name = "cbSubscriptionType";
            this.cbSubscriptionType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbSubscriptionType.Size = new System.Drawing.Size(98, 24);
            this.cbSubscriptionType.TabIndex = 173;
            this.cbSubscriptionType.SelectedIndexChanged += new System.EventHandler(this.cbSubscriptionType_SelectedIndexChanged);
            // 
            // cmsSharias
            // 
            this.cmsSharias.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInfoToolStripMenuItem,
            this.activateShariaToolStripMenuItem,
            this.deactivateShariaToolStripMenuItem,
            this.deleteShariaToolStripMenuItem});
            this.cmsSharias.Name = "cmsSharias";
            this.cmsSharias.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmsSharias.Size = new System.Drawing.Size(186, 171);
            this.cmsSharias.Opening += new System.ComponentModel.CancelEventHandler(this.cmsSharias_Opening);
            // 
            // showInfoToolStripMenuItem
            // 
            this.showInfoToolStripMenuItem.Image = global::AADL.Properties.Resources.show_info_32;
            this.showInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showInfoToolStripMenuItem.Name = "showInfoToolStripMenuItem";
            this.showInfoToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 1, 0, 6);
            this.showInfoToolStripMenuItem.Size = new System.Drawing.Size(185, 43);
            this.showInfoToolStripMenuItem.Text = "عرض المعلومات";
            this.showInfoToolStripMenuItem.Click += new System.EventHandler(this.showInfoToolStripMenuItem_Click);
            // 
            // activateShariaToolStripMenuItem
            // 
            this.activateShariaToolStripMenuItem.Image = global::AADL.Properties.Resources.activate_32_abdalla;
            this.activateShariaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.activateShariaToolStripMenuItem.Name = "activateShariaToolStripMenuItem";
            this.activateShariaToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 1, 0, 6);
            this.activateShariaToolStripMenuItem.Size = new System.Drawing.Size(185, 43);
            this.activateShariaToolStripMenuItem.Text = "تفعيل الحساب";
            this.activateShariaToolStripMenuItem.Click += new System.EventHandler(this.activateShariaToolStripMenuItem_Click);
            // 
            // deactivateShariaToolStripMenuItem
            // 
            this.deactivateShariaToolStripMenuItem.Image = global::AADL.Properties.Resources.deactivate_32_abdalla;
            this.deactivateShariaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deactivateShariaToolStripMenuItem.Name = "deactivateShariaToolStripMenuItem";
            this.deactivateShariaToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 1, 0, 6);
            this.deactivateShariaToolStripMenuItem.Size = new System.Drawing.Size(185, 43);
            this.deactivateShariaToolStripMenuItem.Text = "إلغاء تفعيل الحساب";
            this.deactivateShariaToolStripMenuItem.Click += new System.EventHandler(this.deactivateShariaToolStripMenuItem_Click);
            // 
            // deleteShariaToolStripMenuItem
            // 
            this.deleteShariaToolStripMenuItem.Image = global::AADL.Properties.Resources.delete_32_abdalla;
            this.deleteShariaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteShariaToolStripMenuItem.Name = "deleteShariaToolStripMenuItem";
            this.deleteShariaToolStripMenuItem.Size = new System.Drawing.Size(185, 38);
            this.deleteShariaToolStripMenuItem.Text = "حذف الحساب نهائيا";
            this.deleteShariaToolStripMenuItem.Click += new System.EventHandler(this.deleteShariaToolStripMenuItem_Click);
            // 
            // frmShariaList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 690);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnPreviousPage);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.cbSubscriptionWay);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.cbPage);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTotalRecordsCount);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvSharias);
            this.Controls.Add(this.cbSubscriptionType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShariaList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "نافذة الشرعيين";
            this.Load += new System.EventHandler(this.frmShariasList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSharias)).EndInit();
            this.cmsSharias.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnPreviousPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.ComboBox cbSubscriptionWay;
        private System.Windows.Forms.ComboBox cbIsActive;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cbPage;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalRecordsCount;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvSharias;
        private System.Windows.Forms.ComboBox cbSubscriptionType;
        private System.Windows.Forms.ContextMenuStrip cmsSharias;
        private System.Windows.Forms.ToolStripMenuItem showInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deactivateShariaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteShariaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activateShariaToolStripMenuItem;
    }
}