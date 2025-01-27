#include <iostream>
#include<string>

using namespace std;

int main()
{
    string weather;
    int temperature;

    cin >> temperature >> weather;

    string outfit, shoes;

    if (weather == "Morning")
    {
        if (temperature >= 10 && temperature <= 18)
        {
            outfit = "Sweatshirt";
            shoes = "Sneakers";
        }
        else if (temperature > 18 && temperature <= 24)
        {
            outfit = "Shirt";
            shoes = "Moccasins";
        }
        else if (temperature >= 25)
        {
            outfit = "T-Shirt";
            shoes = "Sandals";
        }
    }
    else if (weather == "Afternoon")
    {
        if (temperature >= 10 && temperature <= 18)
        {
            outfit = "Shirt";
            shoes = "Moccasins";
        }
        else if (temperature > 18 && temperature <= 24)
        {
            outfit = "T-Shirt";
            shoes = "Sandals";
        }
        else if (temperature >= 25)
        {
            outfit = "Swim Suit";
            shoes = "Barefoot";
        }
    }
    else if (weather == "Evening")
    {
        if (temperature >= 10 && temperature <= 18)
        {
            outfit = "Shirt";
            shoes = "Moccasins";
        }
        else if (temperature > 18 && temperature <= 24)
        {
            outfit = "Shirt";
            shoes = "Moccasins";
        }
        else if (temperature >= 25)
        {
            outfit = "Shirt";
            shoes = "Moccasins";
        }
    }

    cout << "It's " << temperature << " degrees, get your " << outfit << " and " << shoes << ".";
}
