using item.Models;
using stock.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Diagnostics.Eventing.Reader;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace InventoryManagerAPI.Services;

public class inventoryService
{
    public inventoryService() { }


    private List<Item> _items = new();
    private List<Stock> _stocks = new();

    public Item CreateItem(String name, String category)
    {
        var item = new Item
        {
            Id = Guid.NewGuid(),
            Name = name,
            Category = category,
            CreatedAt = DateTime.Now,

        };
        var stock = new Stock
        {
            Id = Guid.NewGuid(),
            ItemID = item.Id,
            Quantity = 0,
            updateAt = DateTime.Now,

        };
        _stocks.Add(stock);
        _items.Add(item);
        Console.WriteLine("Item criado com sucesso!");

        return item;
    }

    public void addStock(Guid itemId, int quantity)
    {
        var stock = _stocks.FirstOrDefault(s => s.ItemID == itemId);
        if (stock == null)
            throw new Exception("Estoque não encontrado para esse item!");

        stock.Quantity += quantity;
        stock.updateAt = DateTime.Now;
        Console.WriteLine("Item adicionado com sucesso!");


    }
    public void removeStock(Guid itemId) {
        var stock = _stocks.FirstOrDefault(s => s.ItemID == itemId);
        if (stock == null)
            throw new Exception("Item não existe");
        if (stock.Quantity <= 0)
            throw new Exception("item está zerado");
        stock.Quantity -= 1;
        stock.updateAt = DateTime.Now;
        Console.WriteLine("Item removido com sucesso!");

    }
    public String getStock()
    {
        return _stocks.ToString();
    }




} 