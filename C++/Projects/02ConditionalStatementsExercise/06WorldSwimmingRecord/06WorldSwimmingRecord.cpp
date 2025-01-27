#include <iostream>
#include<math.h>

using namespace std;

int main()
{
    double record, metresPerSec;

    int metres;

    cin >> record >> metres >> metresPerSec;

    double sum = metres * metresPerSec;

    double delay = ((metres / 15) * 12.5);

    sum += delay;



    cout.setf(ios::fixed);
    cout.precision(2);

    if (sum < record)
    {
        cout << "Yes, he succeeded! The new world record is " << sum << " seconds." << endl;
    }
    else if (sum >= record)
    {
        double left = sum - record;

        cout << "No, he failed! He was " << left << " seconds slower." << endl;
    }
}
