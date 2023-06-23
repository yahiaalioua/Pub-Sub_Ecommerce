namespace Ecommerce_Pub_Sub_Orders.Models.DomainModels
{
    public class Product
    {
        public int ProductId { get; init; }
        public string ProductName { get; init; } = null!;
        public string ProductDescription { get; init; }= null!;
        public double Price { get; init; }

    }
}