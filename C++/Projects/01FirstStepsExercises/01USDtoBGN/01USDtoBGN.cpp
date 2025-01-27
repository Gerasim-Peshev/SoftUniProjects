#include <iostream>

using namespace std;

int main()
{
    double dollars;
    cin >> dollars;

    double levs = dollars * 1.79549;

    cout.setf(ios::fixed);
    cout.precision(2);

    cout << levs << endl;
}
