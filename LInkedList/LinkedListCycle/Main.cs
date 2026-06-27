public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x)
    {
        val = x;
        next = null;
    }
}

public class Solution {
    public bool HasCycle(ListNode head)
    {
        var slow = head;
        var fast = head;
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = slow.next.next;
            if (slow.val == fast.val)
            {
                return true;
            }
        }
        return false;
    }
}
