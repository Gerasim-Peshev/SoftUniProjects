#include <iostream>
#include<math.h>
#include<string>

using namespace std;

int main()
{
    string typeMovie;
    int r, c;

    getline(cin, typeMovie);
    cin >> r >> c;

    double sum;

    if (typeMovie == "Premiere")
    {
        sum = (r * c) * 12;
    }
    else if (typeMovie == "Normal")
    {
        sum = (r * c) * 7.50;
    }
    else if (typeMovie == "Discount")
    {
        sum = (r * c) * 5;
    }

    cout.setf(ios::fixed);
    cout.precision(2);

    cout << sum << " leva" << endl;
}
