using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 2, 3, 3, 2, 1 };
            ListNode head = new ListNode(-1);
            ListNode headp = head;
            foreach(int n in nums){
                ListNode p = new ListNode(n);
                headp.next = p;
                headp = headp.next;
            }

            PalindromeLinkedList pa = new PalindromeLinkedList();
            Console.Write(pa.IsPalindrome(head.next));

        }
    }
}
