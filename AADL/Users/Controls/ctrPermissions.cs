using System.Windows.Forms;

namespace AADL.Users.Controls
{
    public partial class ctrPermissions : UserControl
    {
        public ctrPermissions()
        {
            InitializeComponent();
        }

        public int Permissions => _sumCheckedNodeTags(tvPermissions);

        private void _checkTreeViewNodes(TreeNode node, bool isChecked)
        {
            foreach (TreeNode n in node.Nodes)
            {
                n.Checked = isChecked;
                if(n.Nodes.Count > 0)
                    _checkTreeViewNodes(n, isChecked);
            }
        }

        private int _sumCheckedNodeTags(TreeView treeView)
        {
            // Check if the first node has a Tag value of -1 and is checked
            if (treeView.Nodes.Count > 0)
            {
                TreeNode firstNode = treeView.Nodes[0];
                if (firstNode.Checked && firstNode.Tag != null && int.Parse(firstNode.Tag.ToString()) == -1)
                {
                    return -1;
                }
            }

            // Sum the tags of all other checked nodes
            int sum = 0;
            foreach (TreeNode node in treeView.Nodes)
                sum += _sumCheckedNodeTagsRecursive(node);

            return sum;
        }

        private int _sumCheckedNodeTagsRecursive(TreeNode node)
        {
            int sum = 0;

            if (node.Checked && node.Tag != null)
                sum += int.Parse(node.Tag.ToString());

            foreach (TreeNode childNode in node.Nodes)
                sum += _sumCheckedNodeTagsRecursive(childNode);

            return sum;
        }

        private void _checkNodesByPermissions(TreeView treeView, int combinedPermissions)
        {
            if (combinedPermissions == -1)
            {
                if (treeView.Nodes.Count > 0)
                {
                    TreeNode firstNode = treeView.Nodes[0];
                    if (firstNode.Tag != null && int.TryParse(firstNode.Tag.ToString(), out int nodePermission))
                    {
                        if (nodePermission == combinedPermissions)
                        {
                            firstNode.Checked = true;
                        }
                    }
                }
                return;
            }

            foreach (TreeNode node in treeView.Nodes)
            {
                _checkNodesByPermissionsRecursive(node, combinedPermissions);
            }
        }

        private void _checkNodesByPermissionsRecursive(TreeNode node, int combinedPermissions)
        {
            if (node.Tag != null && int.TryParse(node.Tag.ToString(), out int nodePermission) && nodePermission != 0)
            {
                if ((combinedPermissions & nodePermission) == nodePermission)
                {
                    node.Checked = true;
                }
            }

            foreach (TreeNode childNode in node.Nodes)
            {
                _checkNodesByPermissionsRecursive(childNode, combinedPermissions);
            }

            // After processing child nodes, check the parent if all child nodes are checked
            _checkParentNode(node);
        }

        private void _checkParentNode(TreeNode node)
        {
            if (node.Parent != null)
            {
                bool allChecked = true;
                foreach (TreeNode sibling in node.Parent.Nodes)
                {
                    if (!sibling.Checked && (sibling.Tag != null && int.TryParse(sibling.Tag.ToString(), out int siblingPermission) && siblingPermission != 0))
                    {
                        allChecked = false;
                        break;
                    }
                }

                if (allChecked)
                {
                    node.Parent.Checked = true;
                }
            }
        }

        public void CheckUserPermisions(int combinedPermissions)
        {
            _checkNodesByPermissions(tvPermissions, combinedPermissions);
        }

        private void tvPermissions_AfterCheck(object sender, TreeViewEventArgs e)
        {
            _checkTreeViewNodes(e.Node, e.Node.Checked);
        }
    }
}
