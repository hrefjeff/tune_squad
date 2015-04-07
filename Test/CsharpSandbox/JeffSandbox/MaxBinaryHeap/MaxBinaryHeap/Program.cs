using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxBinaryHeap
{
    class Driver
    {
        static void Main(string[] args)
        {
            MaxBinaryHeap theHeap = new MaxBinaryHeap();

            theHeap.insert(20);
            theHeap.insert(40);
            theHeap.insert(30);

            theHeap.popMax();

            Console.WriteLine();
            
            // Like system Pause
            Console.ReadLine();
        }
    } 

    class MaxBinaryHeap 
    {
        private List<Node> heapArray;
        private int currentSize;

        private int getParent(int index) 
        {
            if (index == 0)
            {
                return 0;
            }

            return (index - 1) / 2; 
        }

        private int getLeftChild(int index) 
        {
            return (index * 2) + 1;
        }

        private int getRightChild(int index)
        {
            return (index * 2) + 2;
        }

        private void percolateDown(int index);

        public MaxBinaryHeap() 
        {
            currentSize = 0;
            heapArray = new List<Node>();
        }

        public Node getMax();
        public Node popMax();

        public void checkMin();

        public bool isEmpty() 
        {
            return currentSize == 0;
        }

        public void  getNumberOfItems();

        public void insert(Node newNode)
        { 
            
        }

        public void  printHeap();

   
    }

    class Node
    {
        public string name;
        public int priorityLevel;

        public Node();
        public Node(string newName, int newPriorityLevel)
        {
            this.name = newName;
            this.priorityLevel = newPriorityLevel;
        }

        public string getName()
        {
            return this.name;
        }

        public int getPriorityLevel()
        {
            return this.priorityLevel;
        }

        public void setName(string newName)
        {
            this.name = newName;
        }

        public void setPriorityLevel(int newPriorityLevel)
        {
            this.priorityLevel = newPriorityLevel;
        }
    }
}
