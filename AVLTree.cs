using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    
    class AVLTree<T>
    {
        private IComparer<T> _comparer;
        private AVLNode _root;

        sealed class AVLNode
        {
            public T data;
            public AVLNode left;
            public AVLNode right;
            public int height;
            public uint freq;

            public AVLNode(T value)
            {
                data = value;
                left = null;
                right = null;
                height = 0; freq = 1;
            }
        }

        public AVLTree(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        public AVLTree()
            : this(Comparer<T>.Default)
        {

        }

        private int treeHeight(AVLNode node)
        {
            if (node != null)
            {
                return node.height;
            }
            return -1;
        }

        private AVLNode Insertpri(AVLNode node, T NodeData)
        {
            if (node == null)
            {
                return new AVLNode(NodeData);
            }
            else if (_comparer.Compare(NodeData, node.data) < 0)
            {
                node.left = Insertpri(node.left, NodeData);
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
            else if (_comparer.Compare(NodeData, node.data) > 0)
            {
                node.right = Insertpri(node.right, NodeData);
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
            }
            node.height = Math.Max(treeHeight(node.left), treeHeight(node.right)) + 1;
            return node;
        }

        public void Insert(T NodeData)
        {
            _root = Insertpri(_root, NodeData);
        }

        private AVLNode Deletepri(AVLNode node, T NodeData)
        {
            if (node == null) { return null; }
            if (_comparer.Compare(NodeData, node.data) < 0) //删左侧
            {
                node.left = Deletepri(node.left, NodeData);
                if (treeHeight(node.right) - treeHeight(node.left) == 2)
                {
                    if (node.right.left != null && treeHeight(node.right.left) > treeHeight(node.right.right))
                    {
                        node = RotateRL(node);
                    }
                    else
                    {
                        node = RotateRR(node);
                    }
                }
            }
            else if (_comparer.Compare(NodeData, node.data) > 0) //删右侧
            {
                node.right = Deletepri(node.right, NodeData);
                if (treeHeight(node.left) - treeHeight(node.right) == 2)
                {
                    if (node.left.right != null && treeHeight(node.left.right) > treeHeight(node.left.left))
                    {
                        node = RotateLR(node);
                    }
                    else
                    {
                        node = RotateLL(node);
                    }
                }
            }
            else //删当前
            {
                if (node.left != null && node.right != null) //当前节点有左右孩子
                {
                    AVLNode rightSmallest = node.right;
                    while (rightSmallest.left != null) rightSmallest = rightSmallest.left;
                    CopyNodeData(node, rightSmallest); //将右侧最小节点赋值到当前节点
                    node.right = Deletepri(node.right, rightSmallest.data); //删掉右侧最小节点

                    if (treeHeight(node.left) - treeHeight(node.right) == 2)
                    {
                        if (node.left.right != null && treeHeight(node.left.right) > treeHeight(node.left.left))
                        {
                            node = RotateLR(node);
                        }
                        else
                        {
                            node = RotateLL(node);
                        }
                    }
                }
                else //当前节点有1或0个孩子
                {
                    if (node.left != null) { node = node.left; }
                    else if (node.right != null) { node = node.right; }
                    else { node = null; }
                }
            }
            if (node != null) node.height = Math.Max(treeHeight(node.left), treeHeight(node.right)) + 1;
            return node;
        }

        public void Delete(T NodeData)
        {
            _root = Deletepri(_root, NodeData);
        }

        private AVLNode Searchpri(AVLNode node, T NodeData)
        {
            if (node == null) { return default(AVLNode); }
            if (_comparer.Compare(NodeData, node.data) < 0)
            {
                return Searchpri(node.left, NodeData);
            }
            else if (_comparer.Compare(NodeData, node.data) > 0)
            {
                return Searchpri(node.right, NodeData);
            }
            else
            {
                return node;
            }

        }

        public bool Search(T NodeData)
        {
            return Searchpri(_root, NodeData) == null;
        }

        private AVLNode RotateLL(AVLNode node)
        {
            AVLNode leftNode = node.left;
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
            node.right = rightNode.left;
            rightNode.left = node;

            node.height = Math.Max(treeHeight(node.left), treeHeight(node.right)) + 1;
            rightNode.height = Math.Max(node.height, treeHeight(rightNode.right)) + 1;

            return rightNode;
        }

        private void CopyNodeData(AVLNode n1, AVLNode n2)
        {
            n1.data = n2.data;
            n1.freq = n2.freq;
        }
        private void inorderTraversal(AVLNode node)
        {
            if (node == null) { return ; }
            inorderTraversal(node.left);
            Console.WriteLine(node.data);
            inorderTraversal(node.right);
        }

        public void traversal()
        {
            inorderTraversal(_root);
        }
    }
}
