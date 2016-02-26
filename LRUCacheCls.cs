using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class LRUNode
    {
        private int _key;
        private int _value;
        public LRUNode(int k, int v)
        {
            _key = k; _value = v;
        }
        public int Key
        {
            get { return _key; }
            set { _key = value; }
        }
        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
    class LRUCacheCls
    {
        LinkedList<LRUNode> CacheList;
        Dictionary<int, LRUNode> CacheDict;
        int CacheSize;

        public LRUCacheCls(int capacity)
        {
            CacheList = new LinkedList<LRUNode>();
            CacheDict = new Dictionary<int, LRUNode>();
            CacheSize = capacity;
        }
        
        
        public int Get(int key)
        {
            if (CacheDict.ContainsKey(key))
            {
                LRUNode tmp = CacheDict[key];
                
                CacheList.Remove(tmp);
                CacheList.AddFirst(tmp);
                return tmp.Value;
            }
            return -1;
        }
        public void Set(int key, int value)
        {
            
            if (CacheDict.ContainsKey(key))
            {
                //LRUNode tmp = CacheDict[key];
                //CacheList.Remove(tmp);

                //CacheDict[key].Value = value;
                //tmp.Value = value;
                //CacheList.AddFirst(tmp);
                CacheDict[key].Value = value;
                LRUNode tmp = CacheDict[key];
                
                CacheList.Remove(tmp);
                CacheList.AddFirst(tmp);
            }
            else
            {
                if (CacheList.Count == CacheSize)
                {
                    LRUNode last = CacheList.Last();
                    CacheList.RemoveLast();
                    CacheDict.Remove(last.Key);
                }

                LRUNode tmp = new LRUNode(key, value);
                CacheList.AddFirst(tmp);
                CacheDict.Add(key, tmp);
            }
           
        }
    }
}
