using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();

            list.Add("KuraMiQnko");
            list.Add("Lopata");
            list.Add("MaikaMu");

            Console.WriteLine(list.RandomString());
        }
    }
}
