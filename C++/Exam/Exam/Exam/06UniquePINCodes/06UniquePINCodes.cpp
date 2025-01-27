#include <iostream>
#include<string>
#include<math.h>

using namespace std;

int main()
{
    int first, second, third;

    cin >> first >> second >> third;
    cin.ignore();

    for (int i = 1; i <= first; i++)
    {
        if (i % 2 == 0)
        {
            for (int j = 1; j <= second; j++)
            {
                if (j == 2 || j == 3 || j == 5 || j == 7)
                {
                    for (int z = 1; z <= third; z++)
                    {
                        if (z % 2 == 0)
                        {
                            cout << i << " " << j << " " << z << endl;
                        }
                    }
                }
            }
        }
    }
}
