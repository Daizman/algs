namespace LeetCode.Problems.InvertBinaryTree;

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
    public TreeNode? InvertTree(TreeNode? root) 
    {
        return Invert(root);
    }

    private TreeNode? Invert(TreeNode? root)
    {
        if (root?.left is null && root?.right is null)
        {
            return root;
        }

        if (root.left is not null)
        {
            Invert(root.left);
        }

        if (root.right is not null)
        {
            Invert(root.right);
        }

        var temp = root.left;
        root.left = root.right;
        root.right = temp;

        return root;
    }
}