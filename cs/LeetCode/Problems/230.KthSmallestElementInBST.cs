namespace LeetCode.Problems.KthSmallestElementInBST;

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
    public int KthSmallest(TreeNode root, int k) 
    {
        CalculateNodesCount(root, k);
        return _kthSmallest;
    }

    private int _kthSmallest = -1;
    private int _outputOrder = 0;

    private void CalculateNodesCount(TreeNode node, int k)
    {
        if (node is null)
        {
            return;
        }
        CalculateNodesCount(node.left, k);
        _outputOrder++;
        if (_outputOrder == k)
        {
            _kthSmallest = node.val;
        }
        CalculateNodesCount(node.right, k);
    }
}
