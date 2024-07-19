namespace AADL.Experts
{
    partial class frmExpertDraft
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cbPage = new System.Windows.Forms.ComboBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalRecordsCount = new System.Windows.Forms.Label();
            this.dgvExpertsDraft = new System.Windows.Forms.DataGridView();
            this.cmsRegulatorsDraft = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnPreviousPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpertsDraft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtFilterValue.Location = new System.Drawing.Point(321, 242);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(2);
            this.txtFilterValue.Multiline = true;
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFilterValue.Size = new System.Drawing.Size(214, 23);
            this.txtFilterValue.TabIndex = 190;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // cbPage
            // 
            this.cbPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbPage.FormattingEnabled = true;
            this.cbPage.Location = new System.Drawing.Point(925, 247);
            this.cbPage.Margin = new System.Windows.Forms.Padding(2);
            this.cbPage.Name = "cbPage";
            this.cbPage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbPage.Size = new System.Drawing.Size(98, 24);
            this.cbPage.TabIndex = 191;
            this.cbPage.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
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
            "اسم المستخدم الذي قام بالتعديل"});
            this.cbFilterBy.Location = new System.Drawing.Point(134, 245);
            this.cbFilterBy.Margin = new System.Windows.Forms.Padding(2);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbFilterBy.Size = new System.Drawing.Size(174, 24);
            this.cbFilterBy.TabIndex = 189;
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
            this.label2.TabIndex = 194;
            this.label2.Text = "# السجلات:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(858, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 197;
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
            this.label5.TabIndex = 196;
            this.label5.Text = "البحث بواسطة:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 19.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(9, 152);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1125, 42);
            this.label1.TabIndex = 193;
            this.label1.Text = "مسودة الخبراء";
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
            this.lblTotalRecordsCount.TabIndex = 195;
            this.lblTotalRecordsCount.Text = "0";
            // 
            // dgvExpertsDraft
            // 
            this.dgvExpertsDraft.AllowUserToAddRows = false;
            this.dgvExpertsDraft.AllowUserToDeleteRows = false;
            this.dgvExpertsDraft.AllowUserToOrderColumns = true;
            this.dgvExpertsDraft.AllowUserToResizeRows = false;
            this.dgvExpertsDraft.BackgroundColor = System.Drawing.Color.White;
            this.dgvExpertsDraft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvExpertsDraft.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(54)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExpertsDraft.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvExpertsDraft.ColumnHeadersHeight = 40;
            this.dgvExpertsDraft.GridColor = System.Drawing.Color.DarkGray;
            this.dgvExpertsDraft.Location = new System.Drawing.Point(32, 278);
            this.dgvExpertsDraft.Margin = new System.Windows.Forms.Padding(2);
            this.dgvExpertsDraft.Name = "dgvExpertsDraft";
            this.dgvExpertsDraft.ReadOnly = true;
            this.dgvExpertsDraft.RowHeadersWidth = 51;
            this.dgvExpertsDraft.RowTemplate.Height = 25;
            this.dgvExpertsDraft.Size = new System.Drawing.Size(1078, 363);
            this.dgvExpertsDraft.StandardTab = true;
            this.dgvExpertsDraft.TabIndex = 188;
            // 
            // cmsRegulatorsDraft
            // 
            this.cmsRegulatorsDraft.Name = "cmsRegulatorsDraft";
            this.cmsRegulatorsDraft.Size = new System.Drawing.Size(61, 4);
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreviousPage.FlatAppearance.BorderSize = 0;
            this.btnPreviousPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviousPage.Image = global::AADL.Properties.Resources.right_arrow_24;
            this.btnPreviousPage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPreviousPage.Location = new System.Drawing.Point(1037, 244);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(33, 28);
            this.btnPreviousPage.TabIndex = 199;
            this.btnPreviousPage.UseVisualStyleBackColor = true;
            // 
            // btnNextPage
            // 
            this.btnNextPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextPage.FlatAppearance.BorderSize = 0;
            this.btnNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextPage.Image = global::AADL.Properties.Resources.left_arrow_24;
            this.btnNextPage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNextPage.Location = new System.Drawing.Point(1076, 244);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(33, 28);
            this.btnNextPage.TabIndex = 198;
            this.btnNextPage.UseVisualStyleBackColor = true;
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
            this.pictureBox1.TabIndex = 192;
            this.pictureBox1.TabStop = false;
            // 
            // frmExpertDraft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 690);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.cbPage);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTotalRecordsCount);
            this.Controls.Add(this.dgvExpertsDraft);
            this.Controls.Add(this.btnPreviousPage);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmExpertDraft";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "نافذة الخبراء المسودة";
            this.Load += new System.EventHandler(this.frmExpertDraftList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpertsDraft)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvExpertsDraft;
        private System.Windows.Forms.ContextMenuStrip cmsRegulatorsDraft;
        private System.Windows.Forms.Button btnPreviousPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}