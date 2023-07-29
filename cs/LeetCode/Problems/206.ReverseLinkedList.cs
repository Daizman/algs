using System.Diagnostics.Tracing;

namespace LeetCode.Problems.ReverseLinkedList;

public class ListNode 
{
    public int val;
    public ListNode? next;
    public ListNode(int val=0, ListNode? next=null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode? ReverseList(ListNode? head, ListNode? reverse=null)
    {
        if (head is null)
        {
            return reverse;
        }
        ListNode old = new(head.val, reverse);
        return ReverseList(head.next, old);
    }
}