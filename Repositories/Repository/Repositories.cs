
using BookStore.Core.Models.Base;
using BookStore.Core.Repository;
using System.Resources;

namespace Repositories.Repository
{
    public class Repositories<T> : IRepository<T> where T : BaseModels
    {
        private readonly static List<T> _items=new List<T>();

        public  async Task AddAsync(T model)
        {
           _items.Add(model);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return _items;
        }

        public async Task<T> GetAsync(Func<T, bool> expression)
        {
            return _items.FirstOrDefault(expression);
        }

        public async Task RemoveAsync(T model)
        {
            _items.Remove(model);
        }  
    }
}
