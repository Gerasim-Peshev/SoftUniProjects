#include <iostream>
#include<math.h>
#include<string>

using namespace std;

int main()
{
    string place, typePack, isVip;
    int days;

    cin >> place >> typePack >> isVip >> days;

    if (place != "Bansko" && place != "Borovets" && place != "Varna" && place != "Burgas")
    {
        cout << "Invalid input!";
        return 0;
    }

    if (typePack != "noEquipment" && typePack != "withEquipment" && typePack != "noBreakfast" && typePack != "withBreakfast")
    {
        cout << "Invalid input!";
        return 0;
    }

    if (days < 1)
    {
        cout << "Days must be positive number!";
        return 0;
    }

    if (days > 7)
    {
        days--;
    }

    double sum;

    if (place == "Bansko" || place == "Borovets")
    {
        if (typePack == "noEquipment")
        {
            sum = days * 80;

            if (isVip == "yes")
            {
                sum *= 0.95;
            }
        }
        else if (typePack == "withEquipment")
        {
            sum = days * 100;

            if (isVip == "yes")
            {
                sum *= 0.90;
            }
        }
    }
    else if (place == "Varna" || place == "Burgas")
    {
        if (typePack == "noBreakfast")
        {
            sum = days * 100;

            if (isVip == "yes")
            {
                sum *= 0.93;
            }
        }
        else if (typePack == "withBreakfast")
        {
            sum = days * 130;

            if (isVip == "yes")
            {
                sum *= 0.88;
            }
        }
    }

    cout.setf(ios::fixed);
    cout.precision(2);

    cout << "The price is " << sum << "lv! Have a nice time!" << endl;
}
