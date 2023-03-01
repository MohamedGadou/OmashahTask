using Microsoft.AspNetCore.Mvc;
using OmashahTask.Application.Dtos;
using OmashahTask.Application.IServices;

namespace OmashahTask.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemAppService _itemAppService;
        public ItemsController(IItemAppService itemAppService)
        {
            _itemAppService = itemAppService;
        }
        public ActionResult Index()
        {
            return View(new List<ItemDto>());
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
    }
}
