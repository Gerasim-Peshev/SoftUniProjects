#include <iostream>
#include<math.h>

using namespace std;

int main()
{
    double length;
    double wide;
    double height;
    double percents;

    cin >> length;
    cin >> wide;
    cin >> height;
    cin >> percents;

    double volume = (length / 10) * (wide / 10) * (height / 10);

    double result = volume * (1 - (percents / 100));

    cout << result << endl;
}
