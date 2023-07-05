using System.Globalization;
using System.Text;

namespace MusicHub
{
    using System;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            Console.WriteLine(ExportAlbumsInfo(context, 1));

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var albumsInfo = context.Albums
                                    .Where(a => a.ProducerId.HasValue && a.ProducerId.Value == producerId)
                                    .ToList()
                                    .OrderByDescending(a => a.Price)
                                    .Select(a => new
                                    {
                                        a.Name,
                                        ReleaseDate =
                                             a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                                        ProducerName = a.Producer.Name,
                                        Songs = a.Songs
                                                  .Select(s => new
                                                  {
                                                      SongName = s.Name,
                                                      Price = s.Price.ToString("f2"),
                                                      Writer = s.Writer.Name
                                                  })
                                                  .OrderByDescending(s => s.SongName)
                                                  .ThenBy(s => s.Writer)
                                                  .ToList(),
                                        AlbumPrice = a.Price.ToString("f2")
                                    }).ToList();

            foreach (var a in albumsInfo)
            {
                sb.AppendLine($"-AlbumName: {a.Name}")
                  .AppendLine($"-ReleaseDate: {a.ReleaseDate}")
                  .AppendLine($"-ProducerName: {a.ProducerName}")
                  .AppendLine($"-Songs:");

                int count = 1;
                foreach (var song in a.Songs)
                {
                    sb.AppendLine($"---#{count}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.Price:f2}");
                    sb.AppendLine($"---Writer: {song.Writer}");
                    count++;
                }

                sb.AppendLine($"-AlbumPrice: {a.AlbumPrice}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var sb = new StringBuilder();

            var songs = context.Songs
                               .AsEnumerable()
                               .Where(s => s.Duration.TotalSeconds > duration)
                               .Select(s => new
                                {
                                    s.Name,
                                    Performers = s.SongPerformers.Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                                                  .OrderBy(p => p)
                                                  .ToList(),
                                    WriterName = s.Writer.Name,
                                    AlbumProducerName = s.Album!.Producer!.Name,
                                    SongDuration = s.Duration.ToString("c")
                                })
                               .OrderBy(s => s.Name)
                               .ThenBy(s => s.WriterName)
                               .ToList();

            int count = 1;
            foreach (var s in songs)
            {
                sb.AppendLine($"-Song #{count}")
                  .AppendLine($"---SongName: {s.Name}")
                  .AppendLine($"---Writer: {s.WriterName}");

                foreach (var performer in s.Performers)
                {
                    sb.AppendLine($"---Performer: {performer}");
                }

                sb.AppendLine($"---AlbumProducer: {s.AlbumProducerName}")
                  .AppendLine($"---Duration: {s.SongDuration}");
                count++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
