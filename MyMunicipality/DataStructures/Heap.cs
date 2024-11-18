using MyMunicipality.Models; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMunicipality.DataStructures
{
    /// <summary>
    /// A Min-Heap data structure for managing service requests based on relevance.
    /// </summary>
    public class Heap
    {
        private List<ServiceRequests> heap;

        private readonly Func<ServiceRequests, int> _getRelevance;

        /// <summary>
        /// Constructor to initialize the heap with a relevance function.
        /// </summary>
        /// <param name="getRelevance">A function to determine the relevance of a service request.</param>
        public Heap(Func<ServiceRequests, int> getRelevance)
        {
            heap = new List<ServiceRequests>();
            _getRelevance = getRelevance;
        }

        /// <summary>
        /// Property to get the number of elements in the heap.
        /// </summary>
        public int Count => heap.Count;

        /// <summary>
        /// Inserts a new service request into the heap.
        /// </summary>
        /// <param name="value">The service request to be inserted.</param>
        public void Insert(ServiceRequests value)
        {
            heap.Add(value);
            HeapifyUp(heap.Count - 1);
        }

        /// <summary>
        /// Removes and returns the service request with the minimum relevance.
        /// </summary>
        /// <returns>The service request with the lowest relevance value.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the heap is empty.</exception>
        public ServiceRequests ExtractMin()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Heap is empty.");

            var minValue = heap[0];

            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            HeapifyDown(0);

            return minValue;
        }

        /// <summary>
        /// Maintains the heap property by adjusting elements upwards.
        /// </summary>
        /// <param name="index">The index of the element to adjust.</param>
        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;

                if (_getRelevance(heap[index]) >= _getRelevance(heap[parentIndex]))
                    break;

                Swap(index, parentIndex);

                index = parentIndex;
            }
        }

        /// <summary>
        /// Maintains the heap property by adjusting elements downwards.
        /// </summary>
        /// <param name="index">The index of the element to adjust.</param>
        private void HeapifyDown(int index)
        {
            int lastIndex = heap.Count - 1;

            while (index < lastIndex)
            {
                int leftChildIndex = 2 * index + 1;
                int rightChildIndex = 2 * index + 2;
                int smallestIndex = index;

                if (leftChildIndex <= lastIndex && _getRelevance(heap[leftChildIndex]) < _getRelevance(heap[smallestIndex]))
                    smallestIndex = leftChildIndex;

                if (rightChildIndex <= lastIndex && _getRelevance(heap[rightChildIndex]) < _getRelevance(heap[smallestIndex]))
                    smallestIndex = rightChildIndex;

                if (smallestIndex == index)
                    break;

                Swap(index, smallestIndex);

                index = smallestIndex;
            }
        }

        /// <summary>
        /// Swaps two elements in the heap.
        /// </summary>
        /// <param name="index1">Index of the first element.</param>
        /// <param name="index2">Index of the second element.</param>
        private void Swap(int index1, int index2)
        {
            var temp = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = temp;
        }
    }
}
