using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class MedianOfTwoSortedArrays
    {
        int findMedian(int[] nums1, int start1, int[] nums2, int start2, int k)
        {
            int len1 = nums1.Length - start1;
            int len2 = nums2.Length - start2;
            if (len1 > len2)
            {
                return findMedian(nums2, start2, nums1, start1, k);
            }
            if (len1 == 0)
            {
                return nums2[start2 + k - 1];
            }
            if (k == 1)
            {
                return Math.Min(nums1[start1], nums2[start2]);
            }

            int mid = Math.Min(k / 2, len1);
            int mid2 = k - mid;
            if (nums1[start1 + mid - 1] == nums2[start2 + mid2 - 1])
            {
                return nums1[start1 + mid - 1];
            }
            else if (nums1[start1 + mid - 1] < nums2[start2 + mid2 - 1])
            {
                return findMedian(nums1, start1 + mid, nums2, start2, k - mid);
            }
            else
            {
                return findMedian(nums1, start1, nums2, start2 + mid2, k - mid2);
            }

        }
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int length1 = nums1.Length;
            int length2 = nums2.Length;
            int lensum = length1 + length2;

            if (lensum % 2 == 0)
            {
                int m1 = findMedian(nums1, 0, nums2, 0, lensum / 2);
                int m2 = findMedian(nums1, 0, nums2, 0, lensum / 2 + 1);
                return (m1 + m2) / 2.0;
            }
            else
            {
                return 1.0 * findMedian(nums1, 0, nums2, 0, ( lensum + 1 ) / 2);
            }
        }
    }
}
