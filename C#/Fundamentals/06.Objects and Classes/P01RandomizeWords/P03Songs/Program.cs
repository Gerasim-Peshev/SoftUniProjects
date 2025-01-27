using System;
using System.Collections.Generic;
using System.Linq;

namespace P03Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split("_", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string type = commands[0];
                string name = commands[1];
                string time = commands[2];

                Song song = new Song()
                {
                    Type = type,
                    Name = name,
                    Time = time
                };

                songs.Add(song);
            }

            string songType = Console.ReadLine();

            if (songType == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (Song song in songs)
                {
                    if (song.Type == songType)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }
    }

    class Song
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
}
