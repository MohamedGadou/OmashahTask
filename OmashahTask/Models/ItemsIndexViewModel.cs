using OmashahTask.Application.Dtos;

namespace OmashahTask.Models
{
    public class ItemsIndexViewModel
    {
        public QueryItemDto SearchFilters { get; set; }
        public IList<ItemDto> Items { get; set; }
    }
}
