#include <iostream>
#include<math.h>

using namespace std;

int main()
{
    double deposit;
    double timespan;
    double increse;

    cin >> deposit;
    cin >> timespan;
    cin >> increse;

    increse /= 100;

    double result = deposit + timespan * ((deposit * increse) / 12);

    cout.setf(ios::fixed);
    cout.precision(2);

    cout << result << endl;
}
