/****************************************************
    Names       : Geoffrey Morris & Jeffrey Allen
    Date        : CS420 Spring 2014
    Assignment  : Assignment 11, Group 3
    Description : 
    Due Date: November 20, 2012
*****************************************************/

#include "job.h"
#include <string>
using namespace std;

Job::Job() {

    name = "";
    priorityLevel = 0;

}

Job::Job(string newname, int plvl){

    name = newname;
    priorityLevel = plvl;

}

Job::~Job(){

    name = "";
    priorityLevel = 0;

}

int Job::getPriorityLevel() {

    return priorityLevel;

}

//friend ostream& operator<< <>(ostream& os, const LinkedList<T>& l);