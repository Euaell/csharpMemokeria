using System.Collections.Generic;

namespace memokeria
{
    public class MyStack
    {
        private Queue<int> stk;
        
        public MyStack()
        {
            stk = new Queue<int>();
        }
    
        // public void Push(int x) {
        //
        // }
        //
        // public int Pop() {
        //
        // }
        //
        // public int Top() {
        //
        // }
        //
        // public bool Empty() {
        //
        // }

    }
    
    public class MyHashMap {
        private Dictionary<int, int> hashMap;
        public MyHashMap() {
            hashMap = new Dictionary<int, int> ();
        }
    
        public void Put(int key, int value) {
            if (hashMap.ContainsKey(key))
                hashMap[key] = value;
            hashMap.Add(key, value);
        }
    
        public int Get(int key) {
            if (hashMap.ContainsKey(key))
                return hashMap[key];
            return -1;
        }
    
        public void Remove(int key) {
            if (hashMap.ContainsKey(key))
                hashMap.Remove(key);
        }
    }
}