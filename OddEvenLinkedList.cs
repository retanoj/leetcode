using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class OddEvenLinkedList
    {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public ListNode OddEvenList(ListNode head)
        {
            if (head == null) { return head; }

            ListNode h2 = new ListNode(-1);
            ListNode ph = head, ph2 = h2;

            while (ph.next != null)
            {
                ph2.next = ph.next;
                ph2 = ph2.next;

                ph.next = ph.next.next;
                if (ph.next != null) { ph = ph.next; }
            }
            ph2.next = null;
            ph.next = h2.next;

            return head;
        }

    }
}
