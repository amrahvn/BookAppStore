

using BookStore.Core.Models;

namespace BookService.Interfaces
{
    public interface IwritterService
    {
        public Task<string> CreateAsync(string name,string surname,int Age);

        public Task<string> DeleteAsynv (int id);

        public Task<string> UpDAteAsync(int id,string name,string surname,int age);

        public Task<BookWriter> GetAsync (int id);

        public Task GetAllAsncy();

        public Task<List<Book>> GetAllBookAsync(int id);

        
    }
}
