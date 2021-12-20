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
        
        static int getHeight(Node root){
            //Write your code here
            if (root.Right == null && root.Left == null)
            {
                return 0;
            }
            else if (root.Right == null && root.Left != null)
            {
                return 1 + getHeight(root.Left);
            }
            else if (root.Right != null && root.Left == null)
            {
                return 1 + getHeight(root.Right);
            }
            else
            {
                int r = getHeight(root.Right);
                int l = getHeight(root.Left);
                return 1 + (r > l ? r : l);
                
            }
        }
        
    }
}