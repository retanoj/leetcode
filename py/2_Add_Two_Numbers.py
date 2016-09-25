# coding:utf-8

# Definition for singly-linked list.
class ListNode(object):
    def __init__(self, x):
        self.val = x
        self.next = None

class Solution(object):

    def _sum(self, *args):
        tmp = sum(args)
        if tmp >= 10:
            return tmp-10, 1
        else:
            return tmp, 0

    def addTwoNumbers(self, l1, l2):
        """
        :type l1: ListNode
        :type l2: ListNode
        :rtype: ListNode
        """
        def append_listnode(ln, val):
            ln.next = ListNode(0)
            ln = ln.next
            ln.val = val
            return ln

        carry_bit = 0
        head = ListNode(0)
        _res = head
        while l1 or l2:
            tmp, carry_bit = self._sum(l1.val if l1 else 0, l2.val if l2 else 0, carry_bit)
            _res = append_listnode(_res, tmp)
            l1, l2 = l1.next if l1 else None, l2.next if l2 else None

        if carry_bit:
            _res = append_listnode(_res, carry_bit)

        return head.next
