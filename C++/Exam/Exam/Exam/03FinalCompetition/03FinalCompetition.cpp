#include <iostream>
#include<string>
#include<math.h>

using namespace std;

int main()
{
    double dancers{}, score{};
    string season, place;

    cin >> dancers >> score >> season >> place;
    cin.ignore();

    double sum;

    if (place == "Bulgaria")
    {
        sum = dancers * score;

        if (season == "summer")
        {
            sum *= 0.95;
        }
        else if (season == "winter")
        {
            sum *= 0.92;
        }
    }
    else if (place == "Abroad")
    {
        sum = (dancers * score) * 1.5;

        if (season == "summer")
        {
            sum *= 0.90;
        }
        else if (season == "winter")
        {
            sum *= 0.85;
        }
    }

    double charity = sum * 0.75;

    double perDancer = (sum - (sum * 0.75)) / dancers;

    cout.setf(ios::fixed);
    cout.precision(2);

    cout << "Charity - " << charity << endl;
    cout << "Money per dancer - " << perDancer << endl;
}
