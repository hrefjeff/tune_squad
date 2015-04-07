#include "job.h"
#include "maxBinaryHeap.h"
#include <vector>
#include <string>
using namespace std;

int main () {
	
	maxbinaryheap PriorityQueue;

	PriorityQueue.insertJob(new Job("Class MWF --- 0800-0850, 30 Students", 30));
	PriorityQueue.insertJob(new Job("Class TR  --- 0800-0915, 15 Students", 15));
	PriorityQueue.insertJob(new Job("Class MWF --- 0900-0950, 21 Students", 21));
	PriorityQueue.insertJob(new Job("Class M   --- 1600-2045,  2 Students",  2));

	cout << "Number of elements in PriorityQueue: " << PriorityQueue.getNumberOfItems() << endl;

	PriorityQueue.print();

	cout << "**********POPPED THE MINIMUM I'M SWEATIN! WHOOO!**********" << endl; 
	cout << "Popped:" << PriorityQueue.getMax()->name << endl;
	cout << "**********************************************************" << endl;

	PriorityQueue.print();

		cout << "**********POPPED THE MINIMUM I'M SWEATIN! WHOOO!**********" << endl; 
	cout << "Popped:" << PriorityQueue.getMax()->name << endl;
	cout << "**********************************************************" << endl;

	PriorityQueue.print();


	return 0;
}