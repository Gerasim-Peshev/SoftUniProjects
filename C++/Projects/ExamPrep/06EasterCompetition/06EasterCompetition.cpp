#include <iostream>
#include<string>

using namespace std;

int main()
{
    int n{}, bestPoints{};
    std::string name{}, bestName{};

    std::cin >> n;
    cin.ignore();


    for (int i = 0; i < n; i++)
    {
        int points{};
        std::string temp{};

        getline(cin, name);

        std::cin >> temp;
        std::cin.ignore();
        while (temp != "Stop")
        {
            points += stoi(temp);
            std::cin >> temp;
            std::cin.ignore();
        }

        std::cout << name << " has " << points << " points." << endl;

        if (points > bestPoints)
        {
            bestName = name;
            bestPoints = points;

            std::cout << bestName << " is the new number 1!" << endl;
        }
    }

    std::cout << bestName << " won competition with " << bestPoints << " points!" << endl;

    return 0;
}
