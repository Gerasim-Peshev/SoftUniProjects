#include <iostream>
#include<math.h>

using namespace std;

int main()
{
    double holydayPrice;
    int puzzles, dolls, bears, minions, trucks;

    cin >> holydayPrice >> puzzles >> dolls >> bears >> minions >> trucks;

    int toysSum = puzzles + dolls + bears + minions + trucks;

    double sum = (puzzles * 2.60) + (dolls * 3) + (bears * 4.10) + (minions * 8.20) + (trucks * 2);

    if (toysSum >= 50)
    {
        sum *= 0.75;
    }

    sum *= 0.90;

    cout.setf(ios::fixed);
    cout.precision(2);

    if (sum >= holydayPrice)
    {
        double left = sum - holydayPrice;
        cout << "Yes! " << left << " lv left." << endl;
    }
    else
    {
        double more = holydayPrice - sum;
        cout << "Not enough money! " << more << " lv needed." << endl;
    }
}
