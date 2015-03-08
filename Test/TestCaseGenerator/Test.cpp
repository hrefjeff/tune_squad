#include <iostream>
#include <fstream>
#include <stdlib.h>
#include <time.h>
#include <ctime>
#include <string.h>

using namespace std;

/* run this program using the console pauser or add your own getch, system("pause") or input loop */

int main(int argc, char** argv) {
  
  string fileName ="";	
  ofstream myfile;
  
  cout<<"Please enter test file name:"<<endl;
  cout<<"ex:something.txt"<<endl;
  getline(cin, fileName);
  
  myfile.open (fileName.c_str());
 // myfile << "Writing this to a file.\n";
 
 int length =0;
 
 srand(time(NULL));
 
 //Parameters
 cout << "Please enter the length of the file :";
 cin >> length;
 
for(int i=0;i<length;i++) {
  int alpha = 0; 
/////////////////////////////
 srand(rand());
 alpha = rand()%29+1;
 //GET SCOTT CODE
//////////////////////////// 
 
 //Switch for day
 switch (alpha)
{
  case 0:
  	myfile <<"MTWRF";
  	break;
  case 1:
     myfile << "M";
     break;
  case 2:
     myfile << "T";
     break;
  case 3:
     myfile << "W";
     break;
  case 4:
     myfile << "R";
     break;
  case 5:
     myfile << "F";
     break;
  case 6:
     myfile << "MT";
     break;
  case 7:
     myfile << "MW";
     break;
  case 8:
     myfile << "MR";
     break;
  case 9:
     myfile << "MF";
     break;
  case 10:
     myfile << "MT";
     break;
  case 11:
     myfile << "MTW";
     break;
  case 12:
     myfile << "MTR";
     break;
  case 13:
     myfile << "MTF";
     break;
  case 14:
  	 myfile << "MRF";
  	 break;
  case 15:
     myfile << "MWR";
     break;
  case 16:
     myfile << "MWF";
     break;
  case 17:
     myfile << "MRF";
     break;
     
  case 18:
     myfile << "TW";
     break;
  case 19:
     myfile << "TR";
     break;
  case 20:
     myfile << "TF";
     break;
  case 21:
  	myfile << "MTWRF";
  	break;
  case 22:
     myfile << "TR";
     break;
  case 23:
     myfile << "TF";
     break;
  case 24:
     myfile << "TWR";
     break;
  case 25:
     myfile << "TWF";
     break;
  case 26:
     myfile << "TRF";
     break;
     
  case 27:
     myfile << "WR";
     break;
  case 28:
     myfile << "WF";
     break;
  case 29:
     myfile << "WRF";
     break;
  case 30:
  	myfile << "RF";
  	break;
  default:
     myfile << "error";
}
myfile << " ";
//Time 1
srand(rand());
int timeOne =(rand() % 1000) + 700;
//timeOne = random between 0700 and  1700
myfile << timeOne;

//
myfile << " - ";
//Time 2
srand(rand());
int caseswitch = rand()%3;
int timeTwo =0;
switch(caseswitch)
{
	case 0:
		timeTwo = timeOne+50;
		break;
	case 1:
		timeTwo =timeOne +110;
		break;
	case 2:
		timeTwo = timeOne+140;
		break;
	default:
		myfile << "error Time two";
}
//timeTwo = timeOne + (50||110||140) 
myfile << timeTwo;
//
myfile << ",";
//Pop Number
srand(rand());
int pop = 0;
pop = rand()%200;
myfile << pop;

//
myfile << "\n";
}
  myfile.close();
	cout << "Test file created" <<endl;	
	return 0;
}

/*
Created by Jordan Beck, dynamic random number generator given by Scott Smoke.
*/
