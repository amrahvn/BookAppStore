

using BookStore.Core.Models.Base;

namespace BookStore.Core.Models
{
    public class BookWriter:BaseModels
    {
        private static int _id;
        public string Surname { get; set; }
        public int Age { get; set; }
        public List<Book> books;

        public BookWriter(string name,string surname,int age)
        {
            _id++;
            Id = _id;

            Name = name;
            Surname= surname;
            Age = age;
            books = new List<Book>();
            CreatedTime = DateTime.UtcNow.AddHours(4);
        }

        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            return $"Name{Name},Surname{Surname},Age{Age},CreateDate{CreatedTime},UpDate{UpdatedTime}";
        }
    }
}
