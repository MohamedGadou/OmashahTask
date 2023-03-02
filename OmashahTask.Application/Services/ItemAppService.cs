using OmashahTask.Application.Dtos;
using OmashahTask.Application.IServices;
using OmashahTask.Domain.Entities;
using OmashahTask.Domain.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmashahTask.Application.Services
{
    public class ItemAppService: IItemAppService
    {
        private readonly IItemRepo _itemRepo;
        public ItemAppService(IItemRepo itemRepo)
        {
            _itemRepo = itemRepo;
        }

        public async Task CreateAsync(CreateItemDto input)
        {
            ValidateInput(input);
            
            var item = await _itemRepo.InsertAsync(new Item
            {
                Description = input.Description,
                From = input.From,
                To = input.To,
                Name = input.Name,
            });

           await _itemRepo.SaveAsync();
            
        }

        public async Task<IList<ItemDto>> GetAllAsync(QueryItemDto input)
        {
            var items = await _itemRepo.GetAllAsync(input.Order, input.Name, input.From, input.To, input.ShowPublishedOnly);

            return items.Select(i => new ItemDto { Id = i.Id, Name = i.Name, To = i.To.ToShortDateString(), From = i.From.Date.ToShortDateString(), Description = i.Description }).ToList();
        }

        private void ValidateInput(CreateItemDto input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            if (input.Description == null)
                throw new ArgumentNullException("Description is required");

            if (input.Name == null)
                throw new ArgumentNullException("Name is required");


            if (input.From > input.To)
                throw new InvalidOperationException("From Can't be greater than To");

        }
    }
}
