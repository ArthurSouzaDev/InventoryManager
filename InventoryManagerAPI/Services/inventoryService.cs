using InventoryManagerAPI.Models;


namespace InventoryManagerAPI.Services;

public class InventoryService
{
    public InventoryService() { }

    private List<InventoryItem> _items = new();

    public InventoryItem CreateItem(String name, String category)
    { //InventoryItem objeto, retorna uma instancia de Inventory Item
        var item = new InventoryItem
        {
            Id = Guid.NewGuid(),
            Name = name,
            Category = category,
            Quantity = 0,
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
        // InventoryItem? pode retornar o InventoryItem ou null! 
    {
        return _items.FirstOrDefault(s => s.Id == id);
    }
    public void DeleteItem(Guid id)
    {
        var stock = _items.FirstOrDefault(s => s.Id == id);
        if (stock == null) return;
        _items.Remove(stock);

    }

}