namespace AADL.Cases_Types
{
    partial class frmCasesTypesList
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvCases = new System.Windows.Forms.DataGridView();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalRecordsCount = new System.Windows.Forms.Label();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.cmsCases = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editCaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCases)).BeginInit();
            this.cmsCases.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 19.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(12, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(768, 52);
            this.label1.TabIndex = 147;
            this.label1.Text = "إدارة انواع القضايا";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AADL.Properties.Resources.casesTypes_512;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(278, 32);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(237, 162);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 146;
            this.pictureBox1.TabStop = false;
            // 
            // dgvCases
            // 
            this.dgvCases.AllowUserToAddRows = false;
            this.dgvCases.AllowUserToDeleteRows = false;
            this.dgvCases.AllowUserToOrderColumns = true;
            this.dgvCases.AllowUserToResizeRows = false;
            this.dgvCases.BackgroundColor = System.Drawing.Color.White;
            this.dgvCases.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCases.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(54)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCases.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCases.ColumnHeadersHeight = 40;
            this.dgvCases.GridColor = System.Drawing.Color.DarkGray;
            this.dgvCases.Location = new System.Drawing.Point(46, 335);
            this.dgvCases.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvCases.Name = "dgvCases";
            this.dgvCases.ReadOnly = true;
            this.dgvCases.RowHeadersWidth = 51;
            this.dgvCases.RowTemplate.Height = 25;
            this.dgvCases.Size = new System.Drawing.Size(701, 403);
            this.dgvCases.StandardTab = true;
            this.dgvCases.TabIndex = 148;
            this.dgvCases.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCases_CellMouseDown);
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
            this.cbFilterBy.Location = new System.Drawing.Point(181, 294);
            this.cbFilterBy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbFilterBy.Size = new System.Drawing.Size(123, 28);
            this.cbFilterBy.TabIndex = 166;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(41, 297);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 25);
            this.label5.TabIndex = 168;
            this.label5.Text = "البحث بواسطة:";
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtFilterValue.Location = new System.Drawing.Point(310, 294);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFilterValue.Multiline = true;
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFilterValue.Size = new System.Drawing.Size(205, 28);
            this.txtFilterValue.TabIndex = 167;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(41, 751);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(99, 25);
            this.label2.TabIndex = 169;
            this.label2.Text = "# السجلات:";
            // 
            // lblTotalRecordsCount
            // 
            this.lblTotalRecordsCount.AutoSize = true;
            this.lblTotalRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalRecordsCount.ForeColor = System.Drawing.Color.Black;
            this.lblTotalRecordsCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTotalRecordsCount.Location = new System.Drawing.Point(177, 751);
            this.lblTotalRecordsCount.Name = "lblTotalRecordsCount";
            this.lblTotalRecordsCount.Size = new System.Drawing.Size(24, 25);
            this.lblTotalRecordsCount.TabIndex = 170;
            this.lblTotalRecordsCount.Text = "0";
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackgroundImage = global::AADL.Properties.Resources.add;
            this.btnAddNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNew.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAddNew.Location = new System.Drawing.Point(684, 272);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(63, 50);
            this.btnAddNew.TabIndex = 171;
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // cmsCases
            // 
            this.cmsCases.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmsCases.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsCases.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editCaseToolStripMenuItem,
            this.deleteCaseToolStripMenuItem});
            this.cmsCases.Name = "cmsJudgers";
            this.cmsCases.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmsCases.Size = new System.Drawing.Size(227, 113);
            // 
            // editCaseToolStripMenuItem
            // 
            this.editCaseToolStripMenuItem.Image = global::AADL.Properties.Resources.edit_32;
            this.editCaseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editCaseToolStripMenuItem.Name = "editCaseToolStripMenuItem";
            this.editCaseToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 1, 0, 6);
            this.editCaseToolStripMenuItem.Size = new System.Drawing.Size(138, 43);
            this.editCaseToolStripMenuItem.Text = "تعديل";
            this.editCaseToolStripMenuItem.Click += new System.EventHandler(this.editCaseToolStripMenuItem_Click);
            // 
            // deleteCaseToolStripMenuItem
            // 
            this.deleteCaseToolStripMenuItem.Image = global::AADL.Properties.Resources.delete_32_abdalla;
            this.deleteCaseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteCaseToolStripMenuItem.Name = "deleteCaseToolStripMenuItem";
            this.deleteCaseToolStripMenuItem.Size = new System.Drawing.Size(226, 38);
            this.deleteCaseToolStripMenuItem.Text = "حذف";
            this.deleteCaseToolStripMenuItem.Click += new System.EventHandler(this.deleteCaseToolStripMenuItem_Click);
            // 
            // frmCasesTypesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(793, 796);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotalRecordsCount);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.dgvCases);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCasesTypesList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ادارة انواع القضايا";
            this.Load += new System.EventHandler(this.frmCasesTypesList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCases)).EndInit();
            this.cmsCases.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvCases;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalRecordsCount;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.ContextMenuStrip cmsCases;
        private System.Windows.Forms.ToolStripMenuItem editCaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteCaseToolStripMenuItem;
    }
}