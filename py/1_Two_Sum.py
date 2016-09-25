# coding:utf-8

class Solution(object):
    def twoSum(self, nums, target):
        """
        :type nums: List[int]
        :type target: int
        :rtype: List[int]
        """
        nums_dict = {nums[i]:i for i in xrange(len(nums))}
        for (idx, num) in enumerate(nums):
            if (target - num) in nums_dict and nums_dict[target-num] != idx:
                return [nums_dict[target-num], idx] if idx > nums_dict[target-num] else [idx, nums_dict[target-num]]


if __name__ == "__main__":
    s = Solution()
    print s.twoSum([3, 2, 4], 6)