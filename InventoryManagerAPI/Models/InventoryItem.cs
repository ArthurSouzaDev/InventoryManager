namespace inventoryItem.Models
{
    public class InventoryItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public override string ToString()
        {
            return $"Item: {Name} |Categoria: {Category}| Quantidade: {Quantity} | Criado em: {CreateAt}";

        }
    }
}
