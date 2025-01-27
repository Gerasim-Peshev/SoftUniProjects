#include <iostream>
#include<math.h>

using namespace std;

int main()
{
    int pens;
    int highliters;
    int cleanerLitres;
    double discount;

    cin >> pens;
    cin >> highliters;
    cin >> cleanerLitres;
    cin >> discount;

    double result = ((pens * 5.80) + 
        (highliters * 7.20) + 
        (cleanerLitres * 1.20)) * 
        (1 - (discount / 100));

    cout << result << endl;
}
