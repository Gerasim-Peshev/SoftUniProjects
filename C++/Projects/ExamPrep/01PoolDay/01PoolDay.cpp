#include <iostream>
#include<math.h>

using namespace std;

int main()
{
    double people, entrance, pricePerSunBed, pricePerAmb;

    cin >> people >> entrance >> pricePerSunBed >> pricePerAmb;

    double sum = (people * entrance) + (ceil(people / 2) * pricePerAmb) + (ceil(people * 0.75) * pricePerSunBed);

    cout.setf(ios::fixed);
    cout.precision(2);

    cout << sum << " lv." << endl;
}
