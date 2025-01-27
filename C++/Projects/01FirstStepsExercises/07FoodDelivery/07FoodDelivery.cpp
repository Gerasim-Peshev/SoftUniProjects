#include <iostream>
#include<math.h>

using namespace std;

int main()
{
    double chicken;
    double fish;
    double vegan;

    cin >> chicken;
    cin >> fish;
    cin >> vegan;

    double sum = (chicken * 10.35) + (fish * 12.40) + (vegan * 8.15);

    double dessert = sum * 0.20;

    double result = sum + dessert + 2.50;

    cout << result << endl;
}
