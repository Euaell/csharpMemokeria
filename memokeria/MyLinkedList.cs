using System.Collections.Generic;
using System.Linq;

public class MyLinkedList // works
{
    private LinkedList<int> list;
    public MyLinkedList()
    {
        list = new LinkedList<int>();
    }
    
    public int Get(int index) {
        if (index < list.Count)
            return list.ElementAt(index);
        return -1;
    }
    
    public void AddAtHead(int val)
    {
        list.AddFirst(val);
    }
    
    public void AddAtTail(int val) {
        list.AddLast(val);
    }
    
    public void AddAtIndex(int index, int val) {
        if (index < list.Count)
        {
            LinkedListNode<int> x = list.First;
            while (index > 0)
            {
                x = x.Next;
                index--;
            }
            list.AddBefore(x, val);
        }
        else if (index == list.Count)
            list.AddLast(val);
    }
    
    public void DeleteAtIndex(int index) {
        if (index >= list.Count)
            return;
        LinkedListNode<int> x = list.First;
        while (index > 0)
        {
            x = x.Next;
            index--;
        }
        list.Remove(x);
    }
}