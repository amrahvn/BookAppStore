using BookStore.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Repository
{
    public interface IRepository<T> where T : BaseModels
    {
        public Task AddAsync(T model);

        public Task<T> GetAsync(Func<T,bool>expression);

        public Task<List<T>> GetAllAsync();

        public Task RemoveAsync(T model);

        

    }
}
