using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class MinMaxHeap
    {
        
        void adjustMaxHeap(int[] nums, int parent, int length)
        {
            int left = parent * 2;
            int right = parent * 2 + 1;

            int maxi = -1;
            if (left <= length && nums[left - 1] > nums[parent - 1])
            {
                maxi = left;
            }
            else
            {
                maxi = parent;
            }
            if (right <= length && nums[right - 1] > nums[maxi - 1])
            {
                maxi = right;
            }

            if (maxi != parent)
            {
                int tmp = nums[maxi-1];
                nums[maxi - 1] = nums[parent - 1];
                nums[parent - 1] = tmp;
                adjustMaxHeap(nums, maxi, length);
            }

        }
        void adjustMinHeap(int[] nums, int parent, int length)
        {
            int left = parent * 2;
            int right = left + 1;

            int mini = -1;
            if (left <= length && nums[left - 1] < nums[parent - 1])
            {
                mini = left;
            }
            else
            {
                mini = parent;
            }
            if (right <= length && nums[right - 1] < nums[mini - 1])
            {
                mini = right;
            }

            if (mini != parent)
            {
                int tmp = nums[mini - 1];
                nums[mini - 1] = nums[parent - 1];
                nums[parent - 1] = tmp;

                adjustMinHeap(nums, mini, length);
            }
        }
        void buildMaxHeap(int[] nums, int length)
        {
            for (int i = length / 2; i >= 1; i--)
            {
                adjustMaxHeap(nums, i, length);
            }
        }
        void buildMinHeap(int[] nums, int length)
        {
            for (int i = length / 2; i >= 1; i--)
            {
                adjustMinHeap(nums, i, length);
            }
        }
        public void MaxHeapSort(int[] nums, int length)
        {
            buildMaxHeap(nums, length);
            for (int i = length-1; i >= 0; i--)
            {
                int tmp = nums[i];
                nums[i] = nums[0];
                nums[0] = tmp;
                length--;
                adjustMaxHeap(nums, 1, length);
            }
            foreach (int i in nums)
            {
                Console.Write(i + " ");
            }
        }
        public void MinHeapSort(int[] nums, int length)
        {
            buildMinHeap(nums, length);
            for (int i = length - 1; i >= 0; i--)
            {
                int tmp = nums[i];
                nums[i] = nums[0];
                nums[0] = tmp;
                length--;
                adjustMinHeap(nums, 1, length);
            }
            foreach (int i in nums)
            {
                Console.Write(i + " ");
            }
        }
    }
}
