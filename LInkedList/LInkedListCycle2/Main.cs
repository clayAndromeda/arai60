public class Solution
{
    public ListNode DetectCycle(ListNode head)
    {
        var slow = head;
        var fast = head;
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
            if (slow == fast)
            {
                fast = head;
                while (slow != fast)
                {
                    slow = slow.next;
                    fast = fast.next;
                }
                return slow;
            }
        }

        return null;
    }
}
