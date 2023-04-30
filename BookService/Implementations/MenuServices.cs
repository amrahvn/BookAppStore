

using BookStore.Core.Enum;
using BookStore.Core.Models;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;

namespace BookService.Implementations
{
    public class MenuServices
    {

        public bool IsAdmin=false;

        private User[] users = { new User { UserName = "Emrah", Password = "Emrah123" }, new User { UserName = "Emrah321", Password = "Emrah321" } };


        private BookWritterServices writterServices = new BookWritterServices();
        private BookServices bookService = new BookServices();

        public async Task<bool> Login()
        {
            Console.WriteLine("Add username");
            string username=Console.ReadLine();

            Console.WriteLine("Add pasword");
            string password=Console.ReadLine();

            if (users.Any(x => x.UserName == username && x.Password==password)) 
            {
                IsAdmin=true;
            }
            else
            {
                Console.WriteLine("Username or pasword incorrect");
                IsAdmin=false;
            }

            return IsAdmin;

        }

        public async Task ShowMenuAdmin()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            string sentence = "Dear admin welcome to BookStore.App";

            foreach (var item in sentence)
            {
                Thread.Sleep(100);
                Console.Write(item);
            }

            Console.ForegroundColor= ConsoleColor.DarkBlue;
            Console.WriteLine();
            Console.WriteLine("_______________________");
            Console.WriteLine("0.Close BookApp");
            Console.WriteLine("1.Create Author");
            Console.WriteLine("2.Show Author");
            Console.WriteLine("3.Show Author by id");
            Console.WriteLine("4.Show Author's books");
            Console.WriteLine("5.Update Author");
            Console.WriteLine("6.Delete Author");
            Console.WriteLine("7.Create Book");
            Console.WriteLine("8.Update Book");
            Console.WriteLine("9.Get books by Author");
            Console.WriteLine("10.Deleted book");
            Console.WriteLine("11.Show All books");
            Console.WriteLine("12.Buy Book");

            string Request = Console.ReadLine();


            while (Request != "0")
            {
                switch (Request)
                {
                    case "1":
                        Console.Clear();
                        await CreateWritterAsync();
                    break;

                        case "2":
                        Console.Clear();
                        await ShowAuthor();
                        break;

                        case "3":
                        Console.Clear();
                        await  ShowAuthorbyId();
                        break; 

                    case "4":
                        Console.Clear();
                        await ShowAuthorbooks();
                        break;

                        case "5":
                        Console.Clear();
                        await UpdateAuthor();
                        break;

                        case "6":
                        Console.Clear();
                        await DeleteAuthor();
                        break;

                    case "7":
                        Console.Clear();
                        await CreatedBOoks();
                        break;

                    case "8":
                        Console.Clear();
                        await BookUpDate();
                        break;

                        case "9":
                        Console.Clear();
                        await GetBookbyAuthor();
                        break;

                    case "10":

                        Console.Clear();
                        await DeletedBook();
                        break;

                    case "11":
                        Console.Clear();
                        await ShowAllBooks();
                        break;

                    case "12":
                        Console.Clear();
                        await BuyBook();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Chouse valid option");
                        break;

                }

                Console.WriteLine("make your choice");
                Console.WriteLine("0.Close BookApp");
                Console.WriteLine("1.Create Author");
                Console.WriteLine("2.Show Author");
                Console.WriteLine("3.Show Author by id");
                Console.WriteLine("4.Show Author's books");
                Console.WriteLine("5.Update Author");
                Console.WriteLine("6.Delete Author");
                Console.WriteLine("7.Create Book");
                Console.WriteLine("8.Update Book");
                Console.WriteLine("9.Get books by Author");
                Console.WriteLine("10.Deleted book");
                Console.WriteLine("11.Show All books");
                Console.WriteLine("12.Buy Book");

                 Request = Console.ReadLine();

            }  
            
        }

        public async Task ShowMenuUser()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            string sentence = "Welcome to my BookStore.app";

            foreach(var item in sentence)
            {
                Thread.Sleep(100);
                Console.Write(item);
            }


            Console.WriteLine("0.Close BookApp");
            Console.WriteLine("1.Show Author");
            Console.WriteLine("2.Show Author by id");
            Console.WriteLine("3.Show Author's books");
            Console.WriteLine("4.Get books by Author");
            Console.WriteLine("5.Show All books");
           
            string request = Console.ReadLine();

            while (request != "0")
            {
                switch(request)
                {
                    case "1":
                        await ShowAuthor();
                        break;

                        case "2":
                        await ShowAuthorbyId();
                        break;

                        case "3":
                        await ShowAuthorbooks();
                        break; 

                    case "4":
                        await GetBookbyAuthor();
                        break;

                        case "5":
                        await ShowAllBooks();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Chouse valid option");
                        break;

                }
                Console.WriteLine("0.Close BookApp");
                Console.WriteLine("1.Show Author");
                Console.WriteLine("2.Show Author by id");
                Console.WriteLine("3.Show Author's books");
                Console.WriteLine("4.Get books by Author");
                Console.WriteLine("5.Show All books");

                 request = Console.ReadLine();
            }
        }

        private async Task CreateWritterAsync()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("Add Name");
            string name = Console.ReadLine();

            Console.WriteLine("Add Surname");
            string surname = Console.ReadLine();

            Console.WriteLine("Add Age");
            int.TryParse(Console.ReadLine(), out int age);

            string message = await writterServices.CreateAsync(name, surname, age);

            Console.WriteLine(message);
        } 

        private async Task ShowAuthor()
        {
            await writterServices.GetAllAsncy();
        }

        private async Task ShowAuthorbyId()
        {
            Console.ForegroundColor= ConsoleColor.Green;

            Console.WriteLine("Add Author id");
            int.TryParse(Console.ReadLine(), out int id);

            BookWriter bookWriter=await writterServices.GetAsync(id);
            if(bookWriter != null)
            { 
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(bookWriter);
            }

        }

        private async Task ShowAuthorbooks()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("Add Author id");
            int.TryParse(Console.ReadLine(),out int id);

            List<Book>books=await writterServices.GetAllBookAsync(id);

            if(books != null)
            {
                foreach(Book book in books)
                {
                    Console.WriteLine(book);
                    Console.WriteLine("--------------");
                }
            }
        }

        private async Task UpdateAuthor()
        {
            Console.ForegroundColor=(ConsoleColor) ConsoleColor.Blue;

            Console.WriteLine("Add Author id");
            int.TryParse(Console.ReadLine(), out int id);

            Console.WriteLine("Add Author Name");
            string name=Console.ReadLine();

            Console.WriteLine("Add Author Surname");
            string surname=Console.ReadLine();

            Console.WriteLine("Add Author Age");
            int.TryParse(Console.ReadLine(), out int age);


            string message = await writterServices.UpDAteAsync(id, name, surname, age);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);





        }

        private async Task DeleteAuthor()
        {
            Console.ForegroundColor= ConsoleColor.Blue;

            Console.WriteLine("Add Author id");
            int.TryParse(Console.ReadLine(), out int id);

            string message = await writterServices.DeleteAsynv(id);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(message);
        }

        private async Task CreatedBOoks()
        {
            Console.ForegroundColor =(ConsoleColor) ConsoleColor.Blue;

            Console.WriteLine("Add Author id");
            int.TryParse(Console.ReadLine(),out int id);

            Console.WriteLine("Add Book Name");
            string name=Console.ReadLine();

            Console.WriteLine("Add Price");
            int.TryParse(Console.ReadLine(), out int price);
                
                Console.WriteLine("Add Discount price");
            int.TryParse(Console.ReadLine(), out int discount);

            BookCategory category;

            Console.WriteLine("Chouse category");

            foreach(var item in Enum.GetValues(typeof(BookCategory)))
            {
                Console.WriteLine((int)item + " " + item);
            }

            int.TryParse(Console.ReadLine(), out int categoryindex);

            var result = Enum.GetName(typeof(BookCategory), categoryindex);

            while(result == null)
            {
                Console.WriteLine("Chouse valid Category");
                int.TryParse(Console.ReadLine(),out categoryindex); 

                result =Enum.GetName(typeof(BookCategory),categoryindex);

            }
            category = (BookCategory)categoryindex;

            string message=await bookService.CreateAsync(id, name, price,discount,category);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);




        }

        private async Task BookUpDate()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("Add Author id");
            int.TryParse(Console.ReadLine(), out int Authorid);

            Console.WriteLine("Add Book id");
            int.TryParse(Console.ReadLine(),out int Bookid);    

            Console.WriteLine("Add Name");
            string name = Console.ReadLine();

            Console.WriteLine("Add Price");
            int.TryParse(Console.ReadLine(), out int Price);

            Console.WriteLine("Add DisCountPrice");
            int.TryParse(Console.ReadLine(), out int DiscountPrice);


            string messsage=await bookService.UpdateAsync(Authorid, Bookid,name,Price,DiscountPrice);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(messsage);

        }

        private async Task GetBookbyAuthor()
        {

            Console.ForegroundColor= ConsoleColor.Blue;

            Console.WriteLine("Add Author id");
            int.TryParse(Console.ReadLine(), out int authorid);

            Console.WriteLine("Add Book id");
                int.TryParse(Console.ReadLine(), out int bookid);

            Book book = await bookService.GetAsync(authorid, bookid);

            if(book != null)
            { 
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(book);
            }

        }

        private async Task DeletedBook()
        {
            Console.ForegroundColor=ConsoleColor.Blue;
            Console.WriteLine("Add author id");
            int.TryParse(Console.ReadLine(), out int authorid);

            Console.WriteLine("Add Book id");
            int.TryParse (Console.ReadLine(), out int bookid);

            string message = await bookService.DeleteAsync(bookid, authorid);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);




        }

        private async Task ShowAllBooks()
        {
            Console.ForegroundColor= ConsoleColor.Yellow;
            await bookService.GetAll();
        }

        private async Task BuyBook()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("Add Author id");
            int.TryParse(Console.ReadLine(),out int authorid);

            Console.WriteLine("Add Book id");
                int.TryParse(Console.ReadLine(), out int bookid);

            string message=await bookService.BuyBook(bookid, authorid);
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
                

        }
    }
}









