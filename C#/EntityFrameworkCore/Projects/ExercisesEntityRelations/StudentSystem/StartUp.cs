using P01_StudentSystem.Data;

namespace P01_StudentSystem
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new StudentSystemContext();
            context.Database.EnsureDeleted();
            Console.WriteLine("deleted");
            context.Database.EnsureCreated();
            Console.WriteLine("created");
            Console.WriteLine("done");
        }
    }
}