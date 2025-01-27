#include <iostream>
#include<string>

using namespace std;

int main()
{
    int n, backs{}, chest{}, legs{}, abs{}, shake{}, bar{};
	double workout{}, protein{};
	string input{};

    cin >> n;

	for (int i = 0; i <= n; i++)
	{
		getline(cin, input);

		if (input == "Back")
		{
			backs+=1;
			workout+=1;
		}
		else if (input == "Chest")
		{
			chest+=1;
			workout+=1;
		}
		else if (input == "Legs")
		{
			legs+=1;
			workout+=1;
		}
		else if (input == "Abs")
		{
			abs+=1;
			workout+=1;
		}
		else if (input == "Protein shake")
		{
			shake+=1;
			protein+=1;
		}
		else if (input == "Protein bar")
		{
			bar++;
			protein++;
		}
	}

	std::cout.setf(ios::fixed);
	std::cout.precision(2);

	std::cout << backs << " - back" << endl;
	std::cout << chest << " - chest" << endl;
	std::cout << legs << " - legs" << endl;
	std::cout << abs << " - abs" << endl;
	std::cout << shake << " - protein shake" << endl;
	std::cout << bar << " - protein bar" << endl;
	std::cout << workout / n * 100 << "% - work out" << endl;
	std::cout << protein / n * 100 << "% - protein" << endl;
}