#include <iostream>
#include<math.h>

using namespace std;

int main()
{
    int first;
    int second;
    int third;

    cin >> first;
    cin >> second;
    cin >> third;

    int totalTime = first + second + third;

    double minutes = totalTime / 60;
    double seconds = totalTime % 60;

    if (seconds < 10)
    {
        cout << minutes << ":0" << seconds << endl;
    }
    else
    {
        cout << minutes << ":" << seconds << endl;
    }
}
