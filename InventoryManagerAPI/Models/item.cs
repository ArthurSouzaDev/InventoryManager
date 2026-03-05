namespace item.Models;

public class Item

{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public override string ToString()
    {
        return $"Item: {Name} | Categoria: {Category} | Criado em: {CreatedAt}";
    }
}
