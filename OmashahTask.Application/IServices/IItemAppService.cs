using OmashahTask.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmashahTask.Application.IServices
{
    public interface IItemAppService
    {
        Task<ItemDto> CreateAsync(CreateItemDto input);
    }
}
