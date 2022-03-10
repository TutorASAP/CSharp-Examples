namespace BinaryTree
{
    public sealed partial class BinaryTree<T>
    { 
        public TreeNode? Root { get => root; }
        private TreeNode? root = null;

        private bool leftOrRightElection = true;

        public List<TreeNode?>? GetChildren { get => root?.GetChildren(); }

        public BinaryTree(TreeNode? root = null)
        {
            this.root = root;
        }

        public void Add(T value)
        {
            if (root == null)
            {
                root = new TreeNode(value, null);
                return;
            }
            else if (root.left == null)
            {
                root.left = new TreeNode(value, root);
                return;
            }
            else if (root.right == null)
            {
                root.right = new TreeNode(value, root);
                return;
            }
            else
            {
                var currentRoot = root;
                var lastCurrentRoot = currentRoot;

                while (true)
                {
                    if (currentRoot == null)
                    {
                        currentRoot = new TreeNode(value, lastCurrentRoot);
                        return;
                    }
                    else if (currentRoot.left == null)
                    {
                        currentRoot.left = new TreeNode(value, currentRoot);
                        return;
                    }
                    else if (currentRoot.right == null)
                    {
                        currentRoot.right = new TreeNode(value, currentRoot);
                        return;
                    }
                    else
                    {
                        lastCurrentRoot = currentRoot;

                        if (leftOrRightElection)
                        {
                            currentRoot = currentRoot.left;
                            leftOrRightElection = false;
                        }
                        else
                        {
                            currentRoot = currentRoot.right;
                            leftOrRightElection = true;
                        }

                    }
                }
            }
        }

        public void Remove(T value)
        {

        }

        public TreeNode? Find(T value)
        {
            return null;
        }
    }
}
