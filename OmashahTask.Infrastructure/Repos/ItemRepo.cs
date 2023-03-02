using Microsoft.EntityFrameworkCore;
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

        public async Task<IList<Item>> GetAllAsync(string order, string name, DateTime? from, DateTime? to, bool showPublishedOnly)
        {
            var itemQuery = _dbContext.Items.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                itemQuery = itemQuery.Where(i => i.Name == name);

            if (from.HasValue && !showPublishedOnly)
                itemQuery = itemQuery.Where(i => i.From.Date <= from.Value.Date);

            if (to.HasValue && !showPublishedOnly)
                itemQuery = itemQuery.Where(i => i.To.Date >= to.Value.Date);

            if (showPublishedOnly)
                itemQuery = itemQuery.Where(i => DateTime.Now >= i.From.Date && DateTime.Now <= i.To.Date);

            //if (!string.IsNullOrEmpty(order))
            //    itemQuery.OrderByDescending(order);

            return await itemQuery.ToListAsync();
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
