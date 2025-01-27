#include <iostream>
#include<math.h>

using namespace std;

int main()
{
    double pricePerYear;

    cin >> pricePerYear;

    double jordans = pricePerYear * 0.60;
    double suit = jordans * 0.80;
    double ball = suit * 0.25;
    double accessories = ball * 0.20;

    double result = pricePerYear + jordans + suit + ball + accessories;

    cout << result << endl;
}
