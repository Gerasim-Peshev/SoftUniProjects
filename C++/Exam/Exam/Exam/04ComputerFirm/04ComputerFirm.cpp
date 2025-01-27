#include <iostream>
#include<string>
#include<math.h>

using namespace std;

int main()
{
    int n{}, num{};

    double sales{}, rate{}, rating{};

    cin >> n;
    cin.ignore();

    for (int i = 0; i < n; i++)
    {
        cin >> num;
        cin.ignore();

        rate = num % 10;
        rating += rate;
        
        num /= 10;

        if (rate == 2)
        {
            
        }
        else if (rate == 3)
        {
            sales += num * 0.50;
        }
        else if (rate == 4)
        {
            sales += num * 0.70;
        }
        else if (rate == 5)
        {
            sales += num * 0.85;
        }
        else if (rate == 6)
        {
            sales += num;
        }
    }

    rating = rating / n;

    cout.setf(ios::fixed);
    cout.precision(2);

    cout << sales << endl;
    cout << rating << endl;
}
