#include <iostream>
#include <string>
#include <math.h>

using namespace std;

int main()
{
    string name;
    double time, breakTime;

    getline(cin, name);

    cin >> time >> breakTime;

    breakTime = breakTime - (breakTime / 8) - (breakTime / 4);

    breakTime = breakTime;

    cout.setf(ios::fixed);
    cout.precision(2);

    if (breakTime >= time)
    {
        int left = ceil(breakTime - time);

        cout << "You have enough time to watch " << name << " and left with " << left << " minutes free time." << endl;
    }
    else
    {
        int more = ceil(time - breakTime);

        cout << "You don't have enough time to watch " << name << ", you need " << more << " more minutes.";
    }
}
