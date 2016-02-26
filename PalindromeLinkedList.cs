using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    class PalindromeLinkedList
    {
        
        public bool IsPalindrome(ListNode head)
        {
            ListNode fast1 = head, fast2 = head;
            while (fast2 != null)
            {
                fast1 = fast1.next;
                fast2 = fast2.next;
                if (fast2 != null) { fast2 = fast2.next; }
            }

            ListNode p = new ListNode(-1);
            ListNode tmp = fast1;
            while (fast1 != null)
            {
                tmp = fast1.next;
                fast1.next = p.next;
                p.next = fast1;

                fast1 = tmp;
            }

            p = p.next;
            while (p != null)
            {
                if (p.val != head.val) { return false; }
                p = p.next;
                head = head.next;
            }
            return true;
        }
    }
}
