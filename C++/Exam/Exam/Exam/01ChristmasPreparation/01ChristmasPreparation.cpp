#include <iostream>
#include<string>
#include<math.h>

using namespace std;

int main()
{
    double paper, coton, glue, percents;

    cin >> paper >> coton >> glue >> percents;
    cin.ignore();

    double sum = ((paper * 5.80) + (coton * 7.20) + (glue * 1.20)) * (1 - (percents / 100));

    cout.setf(ios::fixed);
    cout.precision(3);

    cout << sum << endl;
}
