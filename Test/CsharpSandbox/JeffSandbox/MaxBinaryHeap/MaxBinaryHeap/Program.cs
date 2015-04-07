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

            theHeap.insert(new Node("First Class", 30));
            theHeap.insert(new Node("Second Class", 15));
            theHeap.insert(new Node("Third Class", 40));
            theHeap.insert(new Node("Fourth Class", 50));

            Console.WriteLine(theHeap.getMax().name);
            
            // Like system Pause
            Console.ReadLine();
        }
    } 

    class MaxBinaryHeap 
    {
        private List<Node> heapArray;

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

        private void percolateDown(int index)
        {

            int leftChild, rightChild, maximum;

            leftChild = getLeftChild(index);
            rightChild = getRightChild(index);

            // Failsafes
            if (rightChild >= (heapArray.Count - 1))
            {
                if (leftChild >= (heapArray.Count - 1))
                    return;

                else
                    maximum = leftChild;
            }

            // Finds the minimum child based on priority level
            else
            {
                if (heapArray[leftChild].getPriorityLevel() >= heapArray[rightChild].getPriorityLevel())
                    maximum = leftChild;
                else
                    maximum = rightChild;
            }

            // Swap and percolate down to keep heap order
            if (heapArray[index].getPriorityLevel() < heapArray[maximum].getPriorityLevel())
            {
                Node temp;

                temp = heapArray[index];
                heapArray[index] = heapArray[maximum];
                heapArray[maximum] = temp;

                percolateDown(maximum);
            }

        }

        public MaxBinaryHeap() 
        {
            heapArray = new List<Node>();
        }

        public Node getMax()
        {
            if (this.isEmpty())
                return new Node("Nothing entered!", 0);

            // copy root
            Node maximum = heapArray[0];

            // Instantiate place where I want to start the percolation process
            int index = 0;

            // Move the last node in the heap to the top root and reduce the num of items
            heapArray[0] = heapArray[heapArray.Count - 1];
            heapArray.RemoveAt(heapArray.Count - 1);

            // percolate the last node down the tree
            if (heapArray.Count > 0)
                percolateDown(index);

            return maximum;
        }

        public bool isEmpty() 
        {
            return heapArray.Count == 0;
        }

        public int getSizeOfHeap()
        {
            return heapArray.Count;
        }

        public void insert(Node newNode)
        {

            // If heap is empty
            if (isEmpty())
            {
                heapArray.Add(newNode);

                return;
            }

            int indexOfLastJob = heapArray.Count - 1;

            // Put the job in the newly created last spot
            heapArray[indexOfLastJob] = newNode;

            // BEGINNNNN PERCOLATION UPWARRRRDS!
            int parentIndex = 0;
            Node temp;

            // While the parent node's priority is greater than current, keep swappin
            // indexOfParent job gets changed quite often here
            while ((heapArray[getParent(indexOfLastJob)].getPriorityLevel() < newNode.priorityLevel) && (indexOfLastJob != 0))
            {
                parentIndex = getParent(indexOfLastJob);
                temp = heapArray[indexOfLastJob];
                heapArray[indexOfLastJob] = heapArray[parentIndex];
                heapArray[parentIndex] = temp;

                indexOfLastJob = getParent(indexOfLastJob);
            }

        }

        public void printHeap()
        { 
            
        }

   
    }

    class Node
    {
        public string name;
        public int priorityLevel;

        public Node() 
        {
            name = "None";
            priorityLevel = 0;
        }
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
