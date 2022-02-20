using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace memokeria
{
    public class CircularDeque
    {
        // private List<string> member;
        private LinkedList<int> member;
        private int maxCount;
        
         public CircularDeque(int k)
        {
            maxCount = k;
            member = new LinkedList<int>();
        }
    
        public bool InsertFront(int value) {
            if (IsFull())
                return false;
            member.AddFirst(value);
            return true;
        }
    
        public bool InsertLast(int value) {
            if (IsFull())
                return false;
            member.AddLast(value);
            return true;
        }
    
        public bool DeleteFront() {
            if (IsEmpty())
                return false;
            member.RemoveFirst();
            return true;
        }
    
        public bool DeleteLast() {
            if (IsEmpty())
                return false;
            member.RemoveLast();
            return true;
        }
    
        public int GetFront()
        {
            return IsEmpty() ? 0 : member.ElementAt(0);
        }
    
        public int GetRear()
        {
            return IsEmpty() ? 0 : member.ElementAt(member.Count - 1);
        }
    
        public bool IsEmpty()
        {
            return member.Count == 0;
        }
    
        public bool IsFull()
        {
            return member.Count >= maxCount;
        }
    }
}