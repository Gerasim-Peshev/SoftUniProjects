#include <iostream>
#include<string>
#include<math.h>

using namespace std;

int main()
{
    int sea{}, mountain{};
    string command;
    double profit{};

    cin >> sea >> mountain;
    cin.ignore();

    cin >> command;
    cin.ignore();

    while (command != "Stop")
    {
        if (command == "sea" && sea > 0)
        {
            profit += 680;
            sea -= 1;
        }
        else if (command == "mountain" && mountain > 0)
        {
            profit += 499;
            mountain -= 1;
        }

        if (sea == 0 && mountain == 0)
        {
            break;
        }

        cin >> command;
        cin.ignore();
    }

    if (sea == 0 && mountain == 0)
    {
        cout << "Good job! Everything is sold." << endl;
    }

    cout << "Profit: " << profit << " leva." << endl;
}
