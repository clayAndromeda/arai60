/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    public ListNode DeleteDuplicates(ListNode head)
    {
        var current = head;
        while (current != null && current.next != null)
        {
            if (current.val == current.next.val)
            {
                int valToRemove = current.val;
                while (current.next != null && current.next.val == valToRemove)
                {
                    current.next = current.next.next;
                }
            }

            current = current.next;
        }
        return head;
    }
}
