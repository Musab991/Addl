namespace AADL.Users.Controls
{
    partial class ctrPermissions
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("مدير للنظام");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("أضافة");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("تعديل");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("حذف");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("عرض الكل");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("إدارة مزاولي المهنة", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("إضافة");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("تعديل");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("حذف");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("عرض الكل");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("إدارة المستخدميين", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10});
            this.tvPermissions = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tvPermissions
            // 
            this.tvPermissions.CheckBoxes = true;
            this.tvPermissions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvPermissions.Location = new System.Drawing.Point(1, 2);
            this.tvPermissions.Name = "tvPermissions";
            treeNode1.Name = "Node0";
            treeNode1.Tag = "-1";
            treeNode1.Text = "مدير للنظام";
            treeNode2.Name = "Node1";
            treeNode2.Tag = "1";
            treeNode2.Text = "أضافة";
            treeNode3.Name = "Node2";
            treeNode3.Tag = "2";
            treeNode3.Text = "تعديل";
            treeNode4.Name = "Node3";
            treeNode4.Tag = "4";
            treeNode4.Text = "حذف";
            treeNode5.Name = "Node4";
            treeNode5.Tag = "8";
            treeNode5.Text = "عرض الكل";
            treeNode6.Name = "Node5";
            treeNode6.Tag = "0";
            treeNode6.Text = "إدارة مزاولي المهنة";
            treeNode7.Name = "Node7";
            treeNode7.Tag = "16";
            treeNode7.Text = "إضافة";
            treeNode8.Name = "Node8";
            treeNode8.Tag = "32";
            treeNode8.Text = "تعديل";
            treeNode9.Name = "Node9";
            treeNode9.Tag = "64";
            treeNode9.Text = "حذف";
            treeNode10.Name = "Node10";
            treeNode10.Tag = "128";
            treeNode10.Text = "عرض الكل";
            treeNode11.Name = "Node6";
            treeNode11.Tag = "0";
            treeNode11.Text = "إدارة المستخدميين";
            this.tvPermissions.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode6,
            treeNode11});
            this.tvPermissions.RightToLeftLayout = true;
            this.tvPermissions.Size = new System.Drawing.Size(527, 270);
            this.tvPermissions.TabIndex = 0;
            this.tvPermissions.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvPermissions_AfterCheck);
            // 
            // ctrPermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tvPermissions);
            this.Name = "ctrPermissions";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(531, 275);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvPermissions;
    }
}
