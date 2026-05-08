using FluentValidation;
using InventoryManagerAPI.Models;
using InventoryManagerAPI.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using static InventoryManagerAPI.Validator.InventoryItemValidator;

namespace InventoryManagerAPI.Controller
{
    [ApiController] 
    [Route("inventories")] 
    public class InventoryController : ControllerBase
    {
        private readonly InventoryService _service;
        private readonly IValidator<InventoryItem> _validator;
        private readonly IValidator<ItemRequest> _stockValidator;
        private readonly IValidator<RemoveStockRequest> _DeleteStockValidator;

        public InventoryController(InventoryService service, IValidator<InventoryItem> validator, IValidator<ItemRequest> stockValidator, IValidator<RemoveStockRequest> DeleteStockValidator)
        { 
            _service = service;
            _validator = validator;
            _stockValidator = stockValidator;
            _DeleteStockValidator = DeleteStockValidator;
        }

        [HttpGet]
        public ActionResult<List<InventoryItem>> GetAllItems()
        {
            return Ok(_service.GetAllItems());
        }
        [HttpGet("{id}")]
        public ActionResult<InventoryItem> GetById([FromRoute] Guid id)
        {
            var item = _service.GetById(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        public class CreateItemRequest
    {
        public String Name { get; set; } = string.Empty;
        public String Category { get; set; } = string.Empty;
        public int Quantity { get; set; } = 0;
    }
    public class ItemRequest
    {
        public int Quantity { get; set; }
    }
    public class RemoveStockRequest
        {
            public Guid ItemId { get; set; }
            public int Quantity { get; set; }
        }
                // Adicionar item ao estoque
        [HttpPost("{id}/stock")]
        public async Task<IActionResult> addStock(
            [FromRoute]Guid id,
            [FromBody] ItemRequest request)  
        {
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



        [HttpDelete("{id}")]
        public ActionResult DeleteItem([FromRoute] Guid id)
        {
            var item = _service.GetById(id);
            if (item == null) return NotFound();
            _service.DeleteItem(id);
            return NoContent(); 
        }

        [HttpDelete("{id}/stock")]
        public async Task<IActionResult> DeleteStock(
            [FromRoute] Guid id,
            [FromBody] RemoveStockRequest request
        )
        {
            var validation = await _DeleteStockValidator.ValidateAsync(request);

            if (!validation.IsValid)
            {
                var errors = validation.Errors
                    .GroupBy(e => e.PropertyName)
                    .ToDictionary(
                    g => g.Key,
                    g => g.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(new { errors });

            }
            _service.DeleteStock(id, request.Quantity);
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

    } 
}