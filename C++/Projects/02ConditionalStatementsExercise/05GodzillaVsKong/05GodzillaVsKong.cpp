#include <iostream>
#include<math.h>

using namespace std;

int main()
{
    double budget, extras, suitPrice;

    cin >> budget >> extras >> suitPrice;

    double decor = budget * 0.10;

    double suits = extras * suitPrice;

    if (extras > 150)
    {
        suits *= 0.90;
    }

    double sum = decor + suits;

    cout.setf(ios::fixed);
    cout.precision(2);

    if (budget >= sum)
    {
        double left = budget - sum;

        cout << "Action!" << endl;
        cout << "Wingard starts filming with " << left << " leva left." << endl;
    }
    else if (budget < sum)
    {
        double more = sum - budget;

        cout << "Not enough money!" << endl;
        cout << "Wingard needs " << more << " leva more." << endl;
    }
}
