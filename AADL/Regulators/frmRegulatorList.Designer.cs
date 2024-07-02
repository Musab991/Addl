namespace AADL.Regulators
{
    partial class frmRegulatorList
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbIsActive = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cbPage = new System.Windows.Forms.ComboBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvRegulators = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalRecordsCount = new System.Windows.Forms.Label();
            this.cmsRegulators = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activateRegulatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deactivateRegulatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteJudgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbSubscriptionType = new System.Windows.Forms.ComboBox();
            this.cbSubscriptionWay = new System.Windows.Forms.ComboBox();
            this.btnPreviousPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegulators)).BeginInit();
            this.cmsRegulators.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 19.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(12, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1500, 52);
            this.label1.TabIndex = 144;
            this.label1.Text = "إدارة النظامين";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.cbIsActive.Location = new System.Drawing.Point(441, 297);
            this.cbIsActive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbIsActive.Size = new System.Drawing.Size(129, 28);
            this.cbIsActive.TabIndex = 150;
            this.cbIsActive.SelectedIndexChanged += new System.EventHandler(this.cbIsActive_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtFilterValue.Location = new System.Drawing.Point(441, 298);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFilterValue.Multiline = true;
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFilterValue.Size = new System.Drawing.Size(285, 28);
            this.txtFilterValue.TabIndex = 146;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // cbPage
            // 
            this.cbPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbPage.FormattingEnabled = true;
            this.cbPage.Location = new System.Drawing.Point(921, 297);
            this.cbPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbPage.Name = "cbPage";
            this.cbPage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbPage.Size = new System.Drawing.Size(129, 28);
            this.cbPage.TabIndex = 147;
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
            this.cbFilterBy.Location = new System.Drawing.Point(192, 297);
            this.cbFilterBy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbFilterBy.Size = new System.Drawing.Size(231, 28);
            this.cbFilterBy.TabIndex = 145;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(832, 299);
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
            this.label5.Location = new System.Drawing.Point(51, 302);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 25);
            this.label5.TabIndex = 148;
            this.label5.Text = "البحث بواسطة:";
            // 
            // dgvRegulators
            // 
            this.dgvRegulators.AllowUserToAddRows = false;
            this.dgvRegulators.AllowUserToDeleteRows = false;
            this.dgvRegulators.AllowUserToOrderColumns = true;
            this.dgvRegulators.AllowUserToResizeRows = false;
            this.dgvRegulators.BackgroundColor = System.Drawing.Color.White;
            this.dgvRegulators.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRegulators.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(54)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRegulators.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRegulators.ColumnHeadersHeight = 40;
            this.dgvRegulators.GridColor = System.Drawing.Color.DarkGray;
            this.dgvRegulators.Location = new System.Drawing.Point(44, 340);
            this.dgvRegulators.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvRegulators.Name = "dgvRegulators";
            this.dgvRegulators.ReadOnly = true;
            this.dgvRegulators.RowHeadersWidth = 51;
            this.dgvRegulators.RowTemplate.Height = 25;
            this.dgvRegulators.Size = new System.Drawing.Size(1437, 447);
            this.dgvRegulators.StandardTab = true;
            this.dgvRegulators.TabIndex = 151;
            this.dgvRegulators.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegulators_CellDoubleClick);
            this.dgvRegulators.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRegulators_CellMouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(51, 801);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(99, 25);
            this.label2.TabIndex = 152;
            this.label2.Text = "# السجلات:";
            // 
            // lblTotalRecordsCount
            // 
            this.lblTotalRecordsCount.AutoSize = true;
            this.lblTotalRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalRecordsCount.ForeColor = System.Drawing.Color.Black;
            this.lblTotalRecordsCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTotalRecordsCount.Location = new System.Drawing.Point(187, 801);
            this.lblTotalRecordsCount.Name = "lblTotalRecordsCount";
            this.lblTotalRecordsCount.Size = new System.Drawing.Size(24, 25);
            this.lblTotalRecordsCount.TabIndex = 153;
            this.lblTotalRecordsCount.Text = "0";
            // 
            // cmsRegulators
            // 
            this.cmsRegulators.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsRegulators.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsRegulators.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInfoToolStripMenuItem,
            this.activateRegulatorToolStripMenuItem,
            this.deactivateRegulatorToolStripMenuItem,
            this.deleteJudgerToolStripMenuItem});
            this.cmsRegulators.Name = "cmsRegulators";
            this.cmsRegulators.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmsRegulators.Size = new System.Drawing.Size(222, 116);
            this.cmsRegulators.Opening += new System.ComponentModel.CancelEventHandler(this.cmsRegulator_Opening);
            // 
            // showInfoToolStripMenuItem
            // 
            this.showInfoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showInfoToolStripMenuItem.Image = global::AADL.Properties.Resources.show_info_32;
            this.showInfoToolStripMenuItem.Name = "showInfoToolStripMenuItem";
            this.showInfoToolStripMenuItem.Size = new System.Drawing.Size(221, 28);
            this.showInfoToolStripMenuItem.Text = "عرض المعلومات";
            this.showInfoToolStripMenuItem.Click += new System.EventHandler(this.showInfoToolStripMenuItem_Click);
            // 
            // activateRegulatorToolStripMenuItem
            // 
            this.activateRegulatorToolStripMenuItem.Image = global::AADL.Properties.Resources.activate_32_abdalla;
            this.activateRegulatorToolStripMenuItem.Name = "activateRegulatorToolStripMenuItem";
            this.activateRegulatorToolStripMenuItem.Size = new System.Drawing.Size(221, 28);
            this.activateRegulatorToolStripMenuItem.Text = "تفعيل الحساب";
            this.activateRegulatorToolStripMenuItem.Click += new System.EventHandler(this.activateRegulatorToolStripMenuItem_Click);
            // 
            // deactivateRegulatorToolStripMenuItem
            // 
            this.deactivateRegulatorToolStripMenuItem.Image = global::AADL.Properties.Resources.deactivate_32;
            this.deactivateRegulatorToolStripMenuItem.Name = "deactivateRegulatorToolStripMenuItem";
            this.deactivateRegulatorToolStripMenuItem.Size = new System.Drawing.Size(221, 28);
            this.deactivateRegulatorToolStripMenuItem.Text = "إلغاء تفعيل الحساب";
            this.deactivateRegulatorToolStripMenuItem.Click += new System.EventHandler(this.deactivateRegulatorToolStripMenuItem_Click);
            // 
            // deleteJudgerToolStripMenuItem
            // 
            this.deleteJudgerToolStripMenuItem.Image = global::AADL.Properties.Resources.delete_32;
            this.deleteJudgerToolStripMenuItem.Name = "deleteJudgerToolStripMenuItem";
            this.deleteJudgerToolStripMenuItem.Size = new System.Drawing.Size(221, 28);
            this.deleteJudgerToolStripMenuItem.Text = "حذف الحساب نهائيا";
            this.deleteJudgerToolStripMenuItem.Click += new System.EventHandler(this.deleteJudgerToolStripMenuItem_Click);
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
            this.cbSubscriptionType.Location = new System.Drawing.Point(441, 297);
            this.cbSubscriptionType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSubscriptionType.Name = "cbSubscriptionType";
            this.cbSubscriptionType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbSubscriptionType.Size = new System.Drawing.Size(129, 28);
            this.cbSubscriptionType.TabIndex = 154;
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
            this.cbSubscriptionWay.Location = new System.Drawing.Point(441, 297);
            this.cbSubscriptionWay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSubscriptionWay.Name = "cbSubscriptionWay";
            this.cbSubscriptionWay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbSubscriptionWay.Size = new System.Drawing.Size(129, 28);
            this.cbSubscriptionWay.TabIndex = 155;
            this.cbSubscriptionWay.SelectedIndexChanged += new System.EventHandler(this.cbSubscriptionWay_SelectedIndexChanged);
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreviousPage.FlatAppearance.BorderSize = 0;
            this.btnPreviousPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviousPage.Image = global::AADL.Properties.Resources.right_arrow_24;
            this.btnPreviousPage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPreviousPage.Location = new System.Drawing.Point(1067, 294);
            this.btnPreviousPage.Margin = new System.Windows.Forms.Padding(4);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(44, 35);
            this.btnPreviousPage.TabIndex = 161;
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
            this.btnNextPage.Location = new System.Drawing.Point(1119, 294);
            this.btnNextPage.Margin = new System.Windows.Forms.Padding(4);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(44, 35);
            this.btnNextPage.TabIndex = 160;
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AADL.Properties.Resources.requlators_512;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(644, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(237, 162);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 143;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackgroundImage = global::AADL.Properties.Resources.add;
            this.btnAddNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNew.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAddNew.Location = new System.Drawing.Point(1418, 275);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(63, 50);
            this.btnAddNew.TabIndex = 162;
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // frmRegulatorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1524, 849);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnPreviousPage);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.cbSubscriptionType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotalRecordsCount);
            this.Controls.Add(this.dgvRegulators);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.cbPage);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbSubscriptionWay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRegulatorList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "نافذة النظامين";
            this.Load += new System.EventHandler(this.frmRegulatorList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegulators)).EndInit();
            this.cmsRegulators.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbIsActive;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cbPage;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvRegulators;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalRecordsCount;
        private System.Windows.Forms.ToolStripMenuItem showInfoToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsRegulators;
        private System.Windows.Forms.ToolStripMenuItem activateRegulatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deactivateRegulatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteJudgerToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbSubscriptionType;
        private System.Windows.Forms.ComboBox cbSubscriptionWay;
        private System.Windows.Forms.Button btnPreviousPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnAddNew;
    }
}