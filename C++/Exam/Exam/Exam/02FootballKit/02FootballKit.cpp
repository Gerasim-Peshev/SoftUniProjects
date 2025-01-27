#include <iostream>
#include<string>
#include<math.h>

using namespace std;


int main()
{
    double shirt, monetToSpend;

    cin >> shirt >> monetToSpend;
    cin.ignore();

    double shorts = shirt * 0.75;
    double shoks = shorts * 0.20;
    double shoes = (shirt + shorts) * 2;

    double sum = (shirt + shorts + shoks + shoes) * 0.85;

    cout.setf(ios::fixed);
    cout.precision(2);

    if (sum >= monetToSpend)
    {
        cout << "Yes, he will earn the world-cup replica ball!" << endl;
        cout << "His sum is " << sum << " lv." << endl;
    }
    else if (sum < monetToSpend)
    {
        cout << "No, he will not earn the world-cup replica ball." << endl;
        cout << "He needs " << monetToSpend - sum << " lv. more." << endl;
    }
}
