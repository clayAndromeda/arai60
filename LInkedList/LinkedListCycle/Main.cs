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
    public bool HasCycle(ListNode head) {
        HashSet<int> valueSet = new();
        ListNode current = head;
        while (current != null)
        {
            if (valueSet.Contains(current.val))
            {
                return true;
            }
            valueSet.Add(current.val);
            current = current.next;
        }
        return false;
    }
}
