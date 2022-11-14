namespace BookShop
{
    using BookShop.Data.ForSchool.Bags;
    using BookShop.Data.ForSchool.Bags.Enums;
    using BookShop.Data.ForSchool.Notebooks;
    using BookShop.Data.ForSchool.Notebooks.Enums;
    using BookShop.Data.Hobbies;
    using BookShop.Data.Hobbies.Enums;
    using BookShop.Data.Publications;

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