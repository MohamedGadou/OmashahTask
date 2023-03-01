using OmashahTask.Domain.Entities;
using OmashahTask.Domain.IRepos;
using OmashahTask.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmashahTask.Infrastructure.Repos
{
    public class ItemRepo : IItemRepo
    {
        private readonly OmashahTaskDbContext _dbContext;

        public ItemRepo(OmashahTaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Item> InsertAsync(Item entity)
        {
                await _dbContext.AddAsync(entity);
                return entity;
        }

        public async Task SaveAsync()
        {
           await _dbContext.SaveChangesAsync();
        }
    }
}
