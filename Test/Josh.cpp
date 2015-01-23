#include <iostream>
using namespace std;


/**

Author  : Joshua Ford & Jeffrey Allen

Purpose : Testing github and doc++

Date    : 1/21/2014

blahblahblah

*/
int main() 
{

	int a = 5;
	int b = 3;
	int sum = 0;

	sum = a + b;

	cout << "The sum of " << a << " and " << b << " = " << sum << endl;
	return 0;

}

/** Common base class

	First class using doc++

*/
class TestClass
{
	private:
		/// 1_privateComment
		int testPrivate_1;
		/// 2_privateComment
		int testPrivate_2;
		/// 3_privateComment
		int testPrivate_3;

	protected:
		/// Double message?
		char testProtected_1;
		/// 2_protectedComment
		char testProtected_2;
		/// 3_protectedComment
		char testProtected_3;

	public:
		/// 1_publicComment
		bool testPublic_1;
		/// 2_publicComment
		bool testPublic_2;
		/// 3_publicComment
		bool testPublic_3;
};