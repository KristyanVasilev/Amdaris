using Data.Publications;
using Data.ForSchool.Bags;
using Data.ForSchool.Bags.Enums;
using Data.ForSchool.Notebooks;
using Data.ForSchool.Notebooks.Enums;
using Data.Hobbies;
using Data.Hobbies.Enums;

namespace BookShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bookGenre = new Genre("horror");
            var book = new Book(1, 10, "opa", "az", 123, bookGenre);

            Console.WriteLine(book.ToString());

            Console.WriteLine("-----------------------------");

            var bag = new Bagpack(2, 25, "ranica", "blue", "az", 123, Gender.Boy);
            Console.WriteLine(bag.ToString());

            Console.WriteLine("-----------------------------");

            var notebook = new NoteBook(2, 15, "tetradka", "blue", "sini", 100, LineType.Squares);
            Console.WriteLine(notebook.ToString());


            Console.WriteLine("-----------------------------");

            var chess = new Chess(2, 150, "shaho", "az", "qk shah", GameType.Strategy);
            Console.WriteLine(chess.ToString());

        }
    }
}