using System.Text;

// LeetCode.Problems.AddTwoNumbers.ListNode l1 = new(2, new(4, new(3)));
// LeetCode.Problems.AddTwoNumbers.ListNode l2 = new(5, new(6, new(4)));

// LeetCode.Problems.AddTwoNumbers.ListNode l1 = new(0);
// LeetCode.Problems.AddTwoNumbers.ListNode l2 = new(0);

LeetCode.Problems.AddTwoNumbers.ListNode l1 = new(9, new(9, new(9, new(9, new(9, new(9, new(9)))))));
LeetCode.Problems.AddTwoNumbers.ListNode l2 = new(9, new(9, new(9, new(9))));

LeetCode.Problems.AddTwoNumbers.Solution solver = new();

var result = solver.AddTwoNumbers(l1, l2);
StringBuilder answerBuffer = new();
while(result is not null)
{
    answerBuffer.Append(result.val);
    result = result.next;
}

Console.WriteLine(answerBuffer.ToString());
