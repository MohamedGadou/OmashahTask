using OmashahTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmashahTask.Domain.IRepos
{
    public interface IItemRepo
    {
        Task<Item> InsertAsync(Item entity);
        Task<IList<Item>> GetAllAsync(string order, string name, DateTime? from, DateTime? to, bool showPublishedOnly);
        Task SaveAsync();

    }
}
