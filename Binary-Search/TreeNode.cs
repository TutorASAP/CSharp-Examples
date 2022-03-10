namespace BinaryTree
{
    public sealed partial class BinaryTree<T>
    {
        public class TreeNode
        {
            public TreeNode? left;
            public TreeNode? right;
            public TreeNode? parent;

            public readonly bool IsRoot;

            public readonly T Data;

            public TreeNode(T data, TreeNode? parent = null, TreeNode? left = null, TreeNode? right = null)
            {
                this.parent = parent;
                
                this.left = left;
                this.right = right;

                Data = data;

                IsRoot = parent == null;
            }

            public List<TreeNode?> GetChildren()
            {
                var temp = new List<TreeNode?>
                {
                    this
                };

                if (left != null)
                {
                    var tempLeft = left.GetChildren();
                    temp.AddRange(tempLeft);
                }

                if (right != null)
                {
                    var tempRight = right.GetChildren();
                    temp.AddRange(tempRight);
                }

                return temp;
            }
        }
    }
    
}
