using FluentValidation;
using InventoryManagerAPI.Models;
using InventoryManagerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace InventoryManagerAPI.Controller
{
    [ApiController] 
    [Route("inventories")] 
    public class InventoryController : ControllerBase
    {
        private readonly InventoryService _service;
        private readonly IValidator<InventoryItem> _validator;
        private readonly IValidator<AddItemRequest> _stockValidator;

        public InventoryController(InventoryService service, IValidator<InventoryItem> validator, IValidator<AddItemRequest> stockValidator)
        { //Injeção?
            _service = service;
            _validator = validator;
            _stockValidator = stockValidator;
        }

        [HttpGet]
        public ActionResult<List<InventoryItem>> GetAllItems()
        {
            return Ok(_service.GetAllItems());
        }

    public class CreateItemRequest
    {
        public String Name { get; set; } = string.Empty;
        public String Category { get; set; } = string.Empty;
        public int Quantity { get; set; } = 0;
    }
    public class AddItemRequest
    {
        public int Quantity { get; set; }
    }
            
    // Get Itens
    [HttpGet("{id}")]
        public ActionResult<InventoryItem> GetById([FromRoute] Guid id)
        {
            var item = _service.GetById(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem([FromRoute] Guid id)
        {
            var item = _service.GetById(id);
            if (item == null) return NotFound();
            _service.DeleteItem(id);
            return NoContent(); 
        }
        [HttpDelete("{id}/stock")]
        public ActionResult DeleteStock([FromRoute]Guid id, int Quantity)
        {
            var item = _service.GetById(id);
            if (item == null || Quantity < 0) return NotFound();
            _service.DeleteStock(id, Quantity);
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> AddItem(InventoryItem item)

        {
            var validation = await _validator.ValidateAsync(item);

            if (!validation.IsValid)
            {
                var errors = validation.Errors
                    .GroupBy(e => e.PropertyName)
                    .ToDictionary(
                    g => g.Key,
                    g => g.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(new { errors });
            }
            var createdItem = _service.CreateItem(item.Name, item.Category, item.Quantity);
            return Created($"/inventories/{createdItem.Id}", createdItem);
        }
        // Adicionar item ao estoque
        [HttpPost("{id}/stock")]
        public async Task<IActionResult> addStock(
            [FromRoute]Guid id,
            [FromBody] AddItemRequest request)  
        {
            var validator = new AddItemRequest();
            var validation = await _stockValidator.ValidateAsync(request);

            if (!validation.IsValid)
            {
                var errors = validation.Errors
                    .GroupBy(e => e.PropertyName)
                    .ToDictionary(
                    g => g.Key,
                    g => g.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(new { errors });
            }
            _service.addStock(id, request.Quantity);
            return NoContent();
        } 
    } 
}