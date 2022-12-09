namespace Store.Application.DTO.Product
{
    public class BuyCartProductsDto
    {
        public IEnumerable<UpdateProductStockDto>? Products { get; set; }
    }

    public class UpdateProductStockDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class BuyCartProductsResponseDto
    {
        public IEnumerable<int>? UpdatedProducts { get; set; }
    }
}
