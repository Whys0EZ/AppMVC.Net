namespace AppMVC.Net.Models
{
    public class ProductService : List<ProductModel>
    {
        public ProductService()
        {
            Add(new ProductModel { Id = 1, Name = "Product 1", Price = 10.99m });
            Add(new ProductModel { Id = 2, Name = "Product 2", Price = 20.99m });
            Add(new ProductModel { Id = 3, Name = "Product 3", Price = 30.99m });
        }
    }
}