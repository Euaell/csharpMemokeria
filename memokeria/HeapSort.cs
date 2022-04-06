using System.Collections.Generic;
using System.Linq;

namespace memokeria
{
    public class HeapSort
    {
        // Heapify function to maintain heap property.
        public void heapify(int[] arr, int n, int i)
        {
            // Your Code Here
            if (2 * i + 1 >= n) return;
            if (arr[i] > arr[2 * i + 1])
            {
                (arr[i], arr[2 * i + 1]) = (arr[2 * i + 1], arr[i]);
                heapify(arr, n, 2 * i + 1);
            }
            if (2 * i + 1 >= n) return;
            if (arr[i] > arr[2*i + 2])
            {
                (arr[i], arr[2 * i + 2]) = (arr[2 * i + 2], arr[i]);
                heapify(arr, n, 2 * i + 2);
            }
        }
        
        // Function to build a Heap from array.
        public void buildHeap(int[] arr, int n)  
        { 
            // Your Code Here
            for (var i = 0; i < n; i++)
                heapify(arr, n, i);
        }
         
        // Function to sort an array using Heap Sort.
        public void heapSort(int[] arr, int n)
        {
            // code here
            var ret = new int[n];
            for (var i = 0; i < n; i++)
            {
                buildHeap(arr.Skip(i).ToArray(), n);
            }
        }
        
    }
}