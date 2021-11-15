using System;
using System.Collections.Generic;
using System.Linq;

namespace P03Articles20
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
    }

    class ArticleList
    {
        public ArticleList()
        {
            Articles = new List<Article>();
        }
        public List<Article> Articles { get; set; }

        
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            ArticleList article = new ArticleList();
            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split(", ").ToArray();
                article.Articles.Add(new Article(cmd[0], cmd[1], cmd[2]));
            }

            string command = Console.ReadLine();
            if (command == "title")
            {
                article.Articles = article.Articles.OrderBy(x => x.Title).ToList();
            }
            else if (command == "content")
            {
                article.Articles = article.Articles.OrderBy(x => x.Content).ToList();
            }
            else if (command == "author")
            {
                article.Articles = article.Articles.OrderBy(x => x.Autor).ToList();
            }

            foreach (Article artic in article.Articles)
            {
                Console.WriteLine($"{artic.Title} - {artic.Content}: {artic.Autor}");
            }
        }
    }
}
