#include <iostream>
#include<math.h>

using namespace std;

int main()
{
    double budget, N, M, P;

    cin >> budget >> N >> M >> P;

    double Ns = N * 250;

    double sum = Ns + ((Ns * 0.35) * M) + ((Ns * 0.10) * P);

    if (N > M)
    {
        sum *= 0.85;
    }
    
    cout.setf(ios::fixed);
    cout.precision(2);

    if (budget >= sum)
    {
        double left = budget - sum;
        cout << "You have " << left << " leva left!" << endl;
    }
    else
    {
        double more = sum - budget;
        cout << "Not enough money! You need " << more << " leva more!" << endl;
    }
}
