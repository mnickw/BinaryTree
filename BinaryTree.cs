using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable
    {
        T Value;
        BinaryTree<T> Left;
        BinaryTree<T> Right;
        bool isInitialized = false;
        public BinaryTree() { }
        BinaryTree(T value)
        {
            Value = value;
            isInitialized = true;
        }
        public void Add(T key)
        {
            if (!isInitialized)
            {
                Value = key;
                isInitialized = true;
            }
            else
            {
                BinaryTree<T> parentNodeToAdd = this;
                while (true)
                {
                    if (parentNodeToAdd.Value.CompareTo(key) > 0)
                    {
                        if (parentNodeToAdd.Left != null)
                            parentNodeToAdd = parentNodeToAdd.Left;
                        else
                        {
                            parentNodeToAdd.Left = new BinaryTree<T>(key);
                            break;
                        }
                    }
                    else
                    {
                        if (parentNodeToAdd.Right != null)
                            parentNodeToAdd = parentNodeToAdd.Right;
                        else
                        {
                            parentNodeToAdd.Right = new BinaryTree<T>(key);
                            break;
                        }
                    }
                }
            }
        }
        public bool Contains(T key)
        {
            if (!isInitialized)
                return false;
            else
            {
                BinaryTree<T> parentNodeToAdd = this;
                int compareResult;
                while (true)
                {
                    compareResult = parentNodeToAdd.Value.CompareTo(key);
                    if (compareResult == 0)
                        return true;
                    if (compareResult > 0)
                    {
                        if (parentNodeToAdd.Left != null)
                            parentNodeToAdd = parentNodeToAdd.Left;
                        else
                            return false;
                    }
                    else
                    {
                        if (parentNodeToAdd.Right != null)
                            parentNodeToAdd = parentNodeToAdd.Right;
                        else
                            return false;
                    }
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
