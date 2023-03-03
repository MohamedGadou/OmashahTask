using Microsoft.AspNetCore.Mvc;
using OmashahTask.Application.Dtos;
using OmashahTask.Application.IServices;
using OmashahTask.Models;

namespace OmashahTask.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemAppService _itemAppService;
        public ItemsController(IItemAppService itemAppService)
        {
            _itemAppService = itemAppService;
        }
        public async Task<ActionResult> Index(string name, DateTime? from, DateTime? to)
        {
            var searchFilters = new QueryItemDto
            {
                Name = name,
                From = from,
                To = to
            };
            var items = await _itemAppService.GetAllAsync(searchFilters);

            var model = new ItemsIndexViewModel
            {
                Items = items,
                SearchFilters = searchFilters
            };
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateItemDto input)
        {
            try
            {
                await _itemAppService.CreateAsync(input);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> PublishedOnlyItems()
        {
            var searchFilters = new QueryItemDto
            {
                ShowPublishedOnly = true
            };
            var items = await _itemAppService.GetAllAsync(searchFilters);


            return View(items);
        }
        
    }
}
