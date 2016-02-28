using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class RemoveNthNodeFromEndofList
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head == null || (head.next == null && n == 1)) { return null; }

            //维护一个queue，就像一个滑动窗口
            Queue<ListNode> q = new Queue<ListNode>();
            ListNode headp = head;
            while (headp.next != null)
            {
                if (q.Count == n)
                {
                    q.Dequeue();
                }
                q.Enqueue(headp);
                headp = headp.next;
            }

            //如果队列长度为n，那么队头元素后面的节点即要删
            //如果队列长度小于n，即队列未满即扫完了列表，说明要删的就是第一个节点
            if (q.Count == n)
            {
                headp = q.Dequeue();
                headp.next = headp.next.next;
            }
            else
            {
                head = head.next;
            }
            return head;
        }
    }
}
