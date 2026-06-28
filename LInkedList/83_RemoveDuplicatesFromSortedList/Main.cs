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
public class Solution {
    public ListNode DeleteDuplicates(ListNode head)
    {
        HashSet<int> vals = new();
        var prev = head;
        var current = head;
        while (current != null)
        {
            if (vals.Contains(current.val))
            {
                prev.next = current.next;
                current = current.next;
            }
            else
            {
                vals.Add(current.val);
                prev = current;
                current = current.next;
            }
        }
        return head;
    }
}
