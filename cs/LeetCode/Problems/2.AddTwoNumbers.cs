namespace LeetCode.Problems.AddTwoNumbers;

public class ListNode {
    public int val;
    public ListNode? next;
    public ListNode(int val=0, ListNode? next=null) {
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
            if (sum >= 10)
            {
                buf = sum / 10;
                l1Node.val = sum % 10;
            }
            else
            {
                buf = 0;
                l1Node.val = sum;
            }

            if (l1Node.next is null && l2Node.next is null && buf == 0)
            {
                break;
            }

            l1Node.next ??= new(0);
            l2Node.next ??= new(0);
            l1Node = l1Node.next;
            l2Node = l2Node.next;
        }

        return l1;
    }

    public ListNode? BestAddTwoNumbers(ListNode? l1, ListNode? l2)
    {
        ListNode dummy = new(-1);
        ListNode temp = dummy;
        int carry = 0;
        int sum;

        while(l1 is not null || l2 is not null || carry != 0)
        {
            sum = 0;
            if(l1 is not null)
            {
                sum += l1.val;
                l1 = l1.next;
            }

            if(l2 is not null)
            {
                sum += l2.val;
                l2 = l2.next;
            }

            sum += carry;
            carry = sum / 10;
            temp.next = new(sum % 10);
            temp = temp.next;
        }

        return dummy.next;
    }
}