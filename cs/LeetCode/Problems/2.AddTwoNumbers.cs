namespace LeetCode.Problems.AddTwoNumbers;

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        int buf = 0;
        int sum;
        ListNode l1Node = l1;
        ListNode l2Node = l2;
        while (true)
        {
            sum = l1Node.val + l2Node.val + buf;
            if (sum > 9)
            {
                buf = sum / 10;
                l1Node.val = sum % 10;
            }
            else
            {
                buf = 0;
                l1Node.val = sum;
            }

            if (l1Node.next is null && l2Node.next is null && l1Node.val == 0 && l2Node.val == 0)
            {
                if (buf > 0)
                {
                    l1Node.next = new(buf);
                }

                break;
            }

            l1Node = l1Node.next ?? new(0);
            l2Node = l2Node.next ?? new(0);
        }

        return l1;
    }
}