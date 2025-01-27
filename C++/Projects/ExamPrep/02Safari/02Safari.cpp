#include <iostream>
#include<math.h>
#include<string>

using namespace std;

int main()
{
    double budget, letres;
    string day;

    cin >> budget >> letres >> day;

    double sum = 100 + (letres * 2.10);

    if (day == "Saturday")
    {
        sum *= 0.90;
    }
    else if (day == "Sunday")
    {
        sum *= 0.80;
    }

    cout.setf(ios::fixed);
    cout.precision(2);

    if (budget - sum >= 0)
    {
        cout << "Safari time! Money left: " << budget - sum << " lv." << endl;
    }
    else if (budget - sum < 0)
    {
        cout << "Not enough money! Money needed: " << sum - budget << " lv." << endl;
    }
}
