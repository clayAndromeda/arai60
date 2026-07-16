public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode DeleteDuplicates(ListNode head)
    {
        var dummyHead = new ListNode(-1, head);
        var prev = dummyHead;
        var current = head;
        while (current != null)
        {
            if (current.next != null && current.val == current.next.val)
            {
                int valToDelete = current.val;
                while (current != null && current.val == valToDelete)
                {
                    current = current.next;
                }
                prev.next = current;
            }
            else
            {
                prev = current;
                current = current.next;
            }
        }

        return dummyHead.next;
    }
}
