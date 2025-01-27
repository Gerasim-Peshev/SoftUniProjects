#include <iostream>

using namespace std;

int main()
{
    double plastic;
    double dye;
    double thinner;
    double hours;

    cin >> plastic;
    cin >> dye;
    cin >> thinner;
    cin >> hours;

    plastic += 2;
    dye *= 1.10;

    double sum = ((plastic * 1.50) +
                     (dye * 14.50) +
                     (thinner * 5) +
                     0.40);

    double result = sum + ((sum * 0.3) * hours);

    cout << result << endl;
}
