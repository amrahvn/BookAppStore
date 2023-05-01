using BookService.Interfaces;
using BookStore.Core.Enum;
using BookStore.Core.Models;
using Repositories.Repository.Restorants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService.Implementations
{
    public class BookServices : IbookService
    {
       private readonly BookWriterRepository _repository= new BookWriterRepository();

        public async Task<string> CreateAsync(int id, string name, double price, double discountPrice, BookCategory category,bool bookInStock)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            BookWriter writter = await _repository.GetAsync(writter=>writter.Id==id);


            if(await ValidBooks(name, price, discountPrice)!=null)
            {
                return await ValidBooks(name, price,discountPrice);
            }

            Book book =new Book(name, price, discountPrice,category,writter,bookInStock);

            writter.books.Add(book);

            Console.ForegroundColor = ConsoleColor.Green;
            return "successfully created";

        }

        public async Task<string> DeleteAsync(int WritId, int BookId)
        {
           Console.ForegroundColor= ConsoleColor.Red;

            BookWriter bookWriter = await _repository.GetAsync(writ => writ.Id == WritId);

            if (bookWriter == null)
                return null;

            Book book = bookWriter.books.FirstOrDefault(Book=>Book.Id==BookId);

            if (book == null)
                return "Book not found";

            bookWriter.books.Remove(book);

            Console.ForegroundColor = ConsoleColor.Red;
            return "Deleted sucesfully";






        }

        public async Task GetAll()
        {
            foreach(var item in await _repository.GetAllAsync())
            {
                foreach(var book in item.books)
                {
                    Console.WriteLine(book);
                }
            }
        }

        public async Task<Book> GetAsync(int WritId, int BookId)
        {
        Console.ForegroundColor=ConsoleColor.Green;

            BookWriter bookWriter = await _repository.GetAsync(writ=>writ.Id == WritId);

            if(bookWriter == null)
            {
                Console.WriteLine("Author not found");
                return null;
            }

            Book book = bookWriter.books.FirstOrDefault(Book =>Book.Id==BookId);

            if( book == null)
            {
                Console.WriteLine("Book not found");
                return null;
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            return book;
            

            
        }

        public async Task<string> UpdateAsync(int WritId, int BookId, string name, double price, double discountPrice)
        {
            Console.ForegroundColor=ConsoleColor.Red;

            BookWriter bookWriter=await _repository.GetAsync(writ=>writ.Id== WritId);

            if (bookWriter == null)
                return "Author not found";

            if(await ValidBooks(name, price, discountPrice)!=null)
            {
                return await ValidBooks(name, price, discountPrice);
            }


            DateTime Update=DateTime.Now;
            Book book = bookWriter.books.FirstOrDefault(book=>book.Id==BookId);

            book.Name = name;
            book.Price = price;
            book.DiscountPrice = discountPrice;
            book.UpdatedTime = Update;

            Console.ForegroundColor = ConsoleColor.Green;
            return "Updated succesfully";




        }

        public async Task<string> BuyBookAsync(int WritId, int BookId, bool BookInStock)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            BookWriter bookWriter = await _repository.GetAsync(writ => writ.Id == WritId);
            if (bookWriter == null)
                return "Author not found";

            Book book = bookWriter.books.FirstOrDefault(Book => Book.Id == BookId);

            if (book == null)
                return "Book not found";

            if (book.BookInStock)
                return "This book is not stock";


            return "Succesfully sold";

        }

        private async Task <string> ValidBooks(string name,double Price,double discountPrice)
        {
            if (string.IsNullOrEmpty(name))
                return "Add valid Name";
            if (Price < 0)
                return "Add valid Price";
            if (discountPrice > Price || discountPrice < 0)
                return "Add valid DisCount";

            return null;


        }

      
    }
}
