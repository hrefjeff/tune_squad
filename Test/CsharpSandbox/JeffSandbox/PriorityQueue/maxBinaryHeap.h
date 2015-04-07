/****************************************************
    Names       : Geoffrey Morris & Jeffrey Allen
    Date        : CS420 Spring 2014
    Assignment  : Assignment 11, Group 3
    Description : 
    Due Date: November 20, 2012
*****************************************************/

#ifndef _maxbinaryheap_H
#define _maxbinaryheap_H

#include "job.h"
#include <vector>
using namespace std;

//template <class T>
class maxbinaryheap {
//private:

	// Array of pointers to <instert anything here>
	vector<Job *> heap;
	int numberOfItems;

	int getParent(int index);
	int getLeftChild(int index);
	int getRightChild(int index);
	void percolateDown(int index);

public:

	maxbinaryheap();
	maxbinaryheap(int size);
	maxbinaryheap(maxbinaryheap& heap);  // For copy constructor
	~maxbinaryheap();

	Job* getMax();
	void checkMin();
	//void insert(T* anything);
	void sort();
	bool isEmpty();

	//*******getters*********
	int getNumberOfItems();
	vector<Job *> getHeap();

	//*******setters*********
	void insertJob(Job *);
	void print();

};


#endif