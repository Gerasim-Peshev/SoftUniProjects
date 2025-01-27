using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace P02Articles
{
    class Article
    {
        public Article(string title, string content, string autor)
        {
            Title = title;
            Content = content;
            Autor = autor;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Autor { get; set; }

        public void Edit(string content)
        {
            Content = content;
        }

        public void ChangeAutor(string autor)
        {
            Autor = autor;
        }

        public void Rename(string title) => Title = title;
        

        public override string ToString()
        {
            return $"{Title} - {Content}: {Autor}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] cmd = Console.ReadLine().Split(", ").ToArray();

            Article article = new Article(cmd[0], cmd[1], cmd[2]);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                cmd = Console.ReadLine().Split(": ").ToArray();
                switch (cmd[0])
                {
                    case "Edit":
                        article.Edit(cmd[1]);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAutor(cmd[1]);
                        break;
                    case "Rename":
                        article.Rename(cmd[1]);
                        break;
                }
            }

            Console.WriteLine(article);
        }
    }
}
