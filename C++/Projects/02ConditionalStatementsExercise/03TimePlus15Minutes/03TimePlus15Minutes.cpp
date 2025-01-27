#include <iostream>
#include<math.h>

using namespace std;

int main()
{
    double hours, minutes;
    
    cin >> hours >> minutes;

    int sum = (hours * 60) + minutes + 15;

    double resultH = sum / 60;
    double resultM = sum % 60;

    if (resultH == 24)
    {
        resultH = 0;
    }

    if (resultM < 10)
    {
        cout << resultH << ":0" << resultM << endl;
    }
    else
    {
        cout << resultH << ":" << resultM << endl;
    }
}
