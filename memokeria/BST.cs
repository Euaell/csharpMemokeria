// Binary Search Tree
namespace memokeria
{
    class BST
    {
        private Node root;
        BST()
        {
            root = null;
        }
        
        static int getHeight(Node root)
        {
            if (root.Right == null && root.Left == null)
                return 0;
            if (root.Right == null && root.Left != null)
                return 1 + getHeight(root.Left);
            if (root.Right != null && root.Left == null)
                return 1 + getHeight(root.Right);
           
            int r = getHeight(root.Right);
            int l = getHeight(root.Left);
            return 1 + (r > l ? r : l);
        }
        
    }
}