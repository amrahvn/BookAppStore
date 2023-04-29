using BookService.Interfaces;
using BookStore.Core.Enum;
using BookStore.Core.Models;
using BookStore.Core.Repository.writters;
using Repositories.Repository.Restorants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService.Implementations
{
    public class BookWritterServices : IwritterService
    {
        private readonly BookWriterRepository _repository= new BookWriterRepository();

        public async Task<string> CreateAsync(string name, string surname, int Age)
        {
            
            Console.ForegroundColor = ConsoleColor.Red;

            if (string.IsNullOrWhiteSpace(name))
                return "Add valid Name";


            if (string.IsNullOrWhiteSpace(surname))
                return "Add valid Surname";

            if (Age <= 0)
                return "Add valid Age";

            Console.ForegroundColor = ConsoleColor.Green;

            BookWriter bookWriter=new BookWriter(name, surname, Age);
            await _repository.AddAsync(bookWriter);

            return "Succesfully created";
            



        }

        public async Task<string> DeleteAsynv(int id)
        {
            Console.ForegroundColor= ConsoleColor.Red;

            BookWriter bookWriter=await _repository.GetAsync(writter=>writter.Id==id);

            if (bookWriter == null)
                return "Author not found";

            await _repository.RemoveAsync(bookWriter);

            Console.ForegroundColor = ConsoleColor.Green;
            return "deleted successfully";





        }

        public async Task GetAllAsncy()
        {
           Console.ForegroundColor= ConsoleColor.Blue;

            foreach(var item in await _repository.GetAllAsync())
            {
                Console.WriteLine(item);
            }






        }

        public async Task<BookWriter> GetAsync(int id)
        {
           BookWriter bookWriter=await _repository.GetAsync(writter=>writter.Id== id);
            
            if (bookWriter == null)
            {
              Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Author not foun");
                return null;
            }
            return bookWriter;  


        }

        public async Task<string> UpDAteAsync(int id, string name, string surname, int age)
        {
            Console.ForegroundColor=ConsoleColor.Red;

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Add valid Name");
            }
                

            if (string.IsNullOrEmpty(surname))
            {
                Console.WriteLine("Add valid Surname");
            }

            if (age <= 0)
            {
                Console.WriteLine("Add valid Age");
            }

            BookWriter bookWriter=await _repository.GetAsync(X=>X.Id== id);

            if (bookWriter == null)
                return "Author not found";

            bookWriter.Name = name;
            bookWriter.Surname = surname;
            bookWriter.Age = age;

            Console.ForegroundColor = ConsoleColor.Green;

            return "Update sucesfully";
























        }

    
        public async Task<List<Book>> GetAllBookAsync(int id)
        {
            BookWriter bookWriter = await _repository.GetAsync(writ=>writ.Id== id);

            if (bookWriter == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Author not found");
                return null;
            }

            return bookWriter.books;
        }
    }
}
