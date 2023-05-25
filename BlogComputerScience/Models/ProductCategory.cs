namespace BlogComputerScience.Models
{
    public class ProductCategory
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }

        // Mappiamo la relazione 1-N con i prodotti
        public List<Product> Products { get; set; }

        public ProductCategory()
        {

        }

        public ProductCategory(string title, string? description)
        {
            Title = title;
            Description = description;
            Products = new List<Product>();
        }

    }
}
