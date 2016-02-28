using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class SortListCls
    {
        ListNode MergeList(ListNode l1, ListNode l2)
        {
            if (l1 == null) { return l2; }
            if (l2 == null) { return l1; }
            ListNode head;
            if (l1.val < l2.val)
            {
                head = l1;
                l1 = l1.next;
            }
            else
            {
                head = l2;
                l2 = l2.next;
            }

            ListNode p = head;
            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val) { p.next = l1; p = p.next; l1 = l1.next; }
                else { p.next = l2; p = p.next; l2 = l2.next; }
            }
            if (l1 != null) { p.next = l1; }
            if (l2 != null) { p.next = l2; }
            return head;
        }
        public ListNode SortList(ListNode head)
        {
            if (head == null || head.next == null) { return head; }

            ListNode fast = head, slow = head;
            //利用1倍速和2倍速指针，将链表从中间切开
            while (fast.next != null && fast.next.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            fast = slow.next;
            slow.next = null;

            return MergeList(SortList(head), SortList(fast));
        }
    }
}
