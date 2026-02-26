using item.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Xml.Linq;

namespace stock.Models;

public class Stock
{
    public Guid id { get; set; }

    public Guid itemID { get; set; } 

    private Item? item {  get; set; }

    public int quantity { get; set; }

    public DateTime updateAt { get; set; }


    public override string ToString()
    {
        return $"Item: {item} | Quantidade: {quantity} | Atualizado em: {updateAt}";
    }
}
