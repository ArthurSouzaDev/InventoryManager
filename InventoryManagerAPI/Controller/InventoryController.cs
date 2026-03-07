using InventoryManagerAPI.Models;
using InventoryManagerAPI.Services;
using Microsoft.AspNetCore.Mvc;



namespace InventoryManagerAPI.Controller
{
    [ApiController] //  diz pro .NET que essa classe é um controller de API.
    [Route("inventory")] // Define todos os endpoints dessa classe comecam com /inventory
    public class InventoryController : ControllerBase
    {
        private readonly InventoryService _service; //Injencao de dependencia
        public InventoryController(InventoryService service)
        {
            _service = service;

        }
        [HttpGet]
        public ActionResult<List<InventoryItem>> GetAllItems()
        {
            return Ok(_service.GetAllItems());
        }
        [HttpPost]

        public ActionResult<InventoryItem> CreateItem([FromBody] CreateItemRequest request)
        {
            var item = _service.CreateItem(request.Name, request.Category);
            return Created($"/inventory/{item.Id}", item); //Dar uma estudada sobre as tabelas Created etc

        }

        [HttpPost("{id}/stock")]
        public ActionResult<InventoryItem> addStock([FromRoute]Guid id, [FromBody] AddItemRequest request)
        {
             _service.addStock(id, request.Quantity);
            return NoContent();
        }

    }
    public class CreateItemRequest
    {
        public String Name { get; set; } = string.Empty;
        public String Category { get; set; } = string.Empty;
    }
    public class AddItemRequest
    {
        public int Quantity { get; set; }
    }
}

