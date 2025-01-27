#include <iostream>
#include<string>

using namespace std;

int main()
{
    double budget{}, income{};

    string input{};

    cin >> budget;
    cin.ignore();

    getline(cin, input);

    while (input != "Party!")
    {
        int quantity{};
        cin >> quantity;
        cin.ignore();

        double temp = input.length() * quantity;

        if ((input.length() * quantity) % 2 != 0)
        {
            temp *= 0.75;
        }

        income += temp;

        if (income >= budget)
        {
            break;
        }

        getline(cin, input);
    }

    cout.setf(ios::fixed);
    cout.precision(2);

    if (income >= budget)
    {
        cout << "Target acquired." << endl;
    }
    else if (income < budget)
    {
        cout << "We need " << budget - income << " leva more." << endl;
    }

    cout << "Club income - " << income << " leva." << endl;
}
