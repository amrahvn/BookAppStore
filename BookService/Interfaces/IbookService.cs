

using BookStore.Core.Enum;
using BookStore.Core.Models;

namespace BookService.Interfaces
{
    public interface IbookService
    {
        public Task<string> CreateAsync(int id, string name,double price,double discountPrice, BookCategory category, bool bookInStock);

        public Task<string> DeleteAsync(int WritId, int BookId);

        public Task<string> UpdateAsync(int WritId, int BookId, string name, double price, double discountPrice);

        public Task<Book> GetAsync(int WritId, int BookId);

        public Task<string> BuyBookAsync(int WritId, int BookId,bool bookInStock);

        public Task GetAll();
    }
}
