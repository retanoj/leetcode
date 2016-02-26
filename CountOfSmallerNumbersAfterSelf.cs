using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class CountOfSmallerNumbersAfterSelf
    {
        class AVLTree<T>
        {
            private IComparer<T> _comparer;
            private AVLNode _root;

            public List<int> SmallerAfterSelfList;

            sealed class AVLNode
            {
                public T data;
                public AVLNode left;
                public AVLNode right;
                public int height;
                public int freq;
                public int leftNodesNum;

                public AVLNode(T value)
                {
                    data = value;
                    left = null;
                    right = null;
                    height = 0; freq = 1; leftNodesNum = 0;
                }
            }

            public AVLTree(IComparer<T> comparer)
            {
                _comparer = comparer;
            }

            public AVLTree()
                : this(Comparer<T>.Default)
            {
                SmallerAfterSelfList = new List<int>();
            }
            
            private int treeHeight(AVLNode node)
            {
                if (node != null)
                {
                    return node.height;
                }
                return -1;
            }

            private AVLNode Insertpri(AVLNode node, T NodeData, int smallerNum=0)
            {
                if (node == null)
                {
                    SmallerAfterSelfList.Add(smallerNum);
                    return  new AVLNode(NodeData);
                }
                else if (_comparer.Compare(NodeData, node.data) < 0) //插入左侧
                {
                    node.leftNodesNum++;
                    node.left = Insertpri(node.left, NodeData, smallerNum);
                    
                    if (treeHeight(node.left) - treeHeight(node.right) == 2)
                    {
                        if (_comparer.Compare(NodeData, node.left.data) < 0)
                        {
                            node = RotateLL(node);
                        }
                        else
                        {
                            node = RotateLR(node);
                        }
                    }
                }
                else if (_comparer.Compare(NodeData, node.data) > 0) //插入右侧
                {
                    node.right = Insertpri(node.right, NodeData, smallerNum +node.freq +node.leftNodesNum);
                    if (treeHeight(node.right) - treeHeight(node.left) == 2)
                    {
                        if (_comparer.Compare(NodeData, node.right.data) < 0)
                        {
                            node = RotateRL(node);
                        }
                        else
                        {
                            node = RotateRR(node);
                        }
                    }
                }
                else
                {
                    node.freq++;
                    smallerNum += node.leftNodesNum;
                    SmallerAfterSelfList.Add(smallerNum);
                }
                node.height = Math.Max(treeHeight(node.left), treeHeight(node.right)) + 1;
                return node;
            }

            public void Insert(T NodeData)
            {
                _root = Insertpri(_root, NodeData);
            }

            private AVLNode RotateLL(AVLNode node)
            {
                AVLNode leftNode = node.left;
                node.leftNodesNum -= node.left.leftNodesNum + node.left.freq; 
                node.left = leftNode.right;
                leftNode.right = node;

                node.height = Math.Max(treeHeight(node.left), treeHeight(node.right)) + 1;
                leftNode.height = Math.Max(treeHeight(leftNode.left), node.height) + 1;

                return leftNode;
            }

            private AVLNode RotateLR(AVLNode node)
            {
                node.left = RotateRR(node.left);
                node = RotateLL(node);
                return node;
            }

            private AVLNode RotateRL(AVLNode node)
            {
                node.right = RotateLL(node.right);
                node = RotateRR(node);
                return node;
            }

            private AVLNode RotateRR(AVLNode node)
            {
                AVLNode rightNode = node.right;
                rightNode.leftNodesNum += node.leftNodesNum + node.freq;
                node.right = rightNode.left;
                rightNode.left = node;
                
                node.height = Math.Max(treeHeight(node.left), treeHeight(node.right)) + 1;
                rightNode.height = Math.Max(node.height, treeHeight(rightNode.right)) + 1;

                return rightNode;
            }

        }
        public IList<int> CountSmaller(int[] nums)
        {
            AVLTree<int> avlt = new AVLTree<int>();
            for (int i = nums.Count() - 1; i >= 0; i-- )
            {
                avlt.Insert(nums[i]);
            }
            avlt.SmallerAfterSelfList.Reverse();
            return avlt.SmallerAfterSelfList;
        }
    }
}
