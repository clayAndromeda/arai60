/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public bool HasCycle(ListNode head) {
        HashSet<int> valueSet = new();
        while (head != null)
        {
            if (valueSet.Contains(head.val))
            {
                return true;
            }
            valueSet.Add(head.val);
            head = head.next;
        }
        return false;
    }
}
