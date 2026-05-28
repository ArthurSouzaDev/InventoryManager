using FluentValidation;
using FluentValidation.Results;
using InventoryManagerAPI.Models;


namespace InventoryManagerAPI.Services;

public class InventoryService
{

    private static List<InventoryItem> _items = new();
    public InventoryItem CreateItem(String name, String category,int quantity)
    { //InventoryItem objeto, retorna uma instancia de Inventory 
        var item = new InventoryItem
        {
            Id = Guid.NewGuid(),
            Name = name,
            Category = category,
            Quantity = quantity,
            CreateAt = DateTime.Now,

        };

        _items.Add(item);
        Console.WriteLine("Item criado com sucesso!");

        return item;
    }

    public void addStock(Guid Id, int quantity)
    {
        var stock = _items.FirstOrDefault(s => s.Id == Id);
        if (stock == null)
            throw new Exception("Estoque não encontrado para esse item!");

        stock.Quantity += quantity;
        stock.UpdateAt = DateTime.Now;
        Console.WriteLine("Item adicionado com sucesso!");

    }
    public void removeStock(Guid Id, int quantity)
    {
        var stock = _items.FirstOrDefault(s => s.Id == Id);
        if (stock == null)
            throw new Exception("Item não existe");
        if (stock.Quantity <= 0)
            throw new Exception("item está zerado");
        if (stock.Quantity < quantity)
            throw new Exception("Quantidade insuficiente em estoque");
        stock.Quantity -= quantity;
        stock.UpdateAt = DateTime.Now;
        Console.WriteLine("Item removido com sucesso!");

    }
    public List<InventoryItem> GetAllItems()
    {
        return _items;
    }
    public InventoryItem? GetById(Guid id)
    {
        return _items.FirstOrDefault(s => s.Id == id);
    }
    public bool DeleteStock(Guid id, int Quantity)
    {
        var item = _items.FirstOrDefault(s => s.Id == id);
        if (item == null) 
            return false;

        if (Quantity <= 0) 
            return false;

        if (item.Quantity < Quantity) return false;

        item.Quantity -= Quantity;
        return true;

    }
    public void DeleteItem(Guid id)
    {
        var item = _items.FirstOrDefault(s => s.Id == id);
        if (item == null) return;
        _items.Remove(item);

    }
    private readonly IValidator<InventoryItem> _validator;

    public InventoryService(IValidator<InventoryItem> validator)
    {
        _validator = validator;
    }

    public async Task<ValidationResult> AddItem(InventoryItem item)
    {
        return await _validator.ValidateAsync(item);
    }



}
