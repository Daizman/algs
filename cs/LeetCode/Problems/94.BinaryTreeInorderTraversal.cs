namespace LeetCode.Problems.BinaryTreeInorderTraversal;

public class TreeNode 
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) 
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution 
{
    // https://www.geeksforgeeks.org/tree-traversals-inorder-preorder-and-postorder/
    public IList<int> InorderTraversal(TreeNode root) 
    {
        return Traversal(root, new List<int>());
    }

    public IList<int> Traversal(TreeNode node, IList<int> result)
    {
        if (node is null)
        {
            return result;
        }

        Traversal(node.left, result);
        result.Add(node.val);
        Traversal(node.right, result);

        return result;
    }
}