﻿#include <iostream>
#include<math.h>

using namespace std;

int main()
{
    int number;

    cin >> number;

	double bonus;

	if (number <= 100)
	{
		bonus = 5;
	}
	else if (number > 1000)
	{
		bonus = number * 0.1;
	}
	else
	{
		bonus = number * 0.2;
	}

	if (number % 2 == 0)
	{
		bonus += 1;
	}
	else if (number % 10 == 5)
	{
		bonus += 2;
	}

	double total = number + bonus;

	cout << bonus << endl;
	cout << total << endl;
}
