using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;

namespace P11Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int ballsN = int.Parse(Console.ReadLine());

            BigInteger snowballShow = 0;
            BigInteger snowballTime = 0;
            BigInteger snowballQuality = 0;
            BigInteger snowballValue = 0;

            for (int i = 0; i < ballsN; i++)
            {
                BigInteger tempShow = BigInteger.Parse(Console.ReadLine());
                BigInteger tempTime = BigInteger.Parse(Console.ReadLine());
                BigInteger tempQuality = BigInteger.Parse(Console.ReadLine());
                BigInteger tempCalc = tempShow / tempTime;
                BigInteger tempValue = BigInteger.Pow(tempCalc, (int)tempQuality);


                if (tempValue > snowballValue)
                {
                    snowballShow = tempShow;
                    snowballTime = tempTime;
                    snowballQuality = tempQuality;
                    snowballValue = tempValue;
                }
            }

            Console.WriteLine($"{snowballShow} : {snowballTime} = {snowballValue} ({snowballQuality})");

            
        }
    }
}
