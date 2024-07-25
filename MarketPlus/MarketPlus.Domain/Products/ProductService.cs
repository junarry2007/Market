namespace MarketPlus.Domain.Products
{
    public class ProductService()
    {
        public decimal FinalPrice(decimal price, decimal percentage)
        {
            if(percentage< 0 || percentage> 100){
                throw new ArgumentException("Percentage debe estar entre 0 y 100.");
            }

            var finalPrice = price - (price * percentage / 100);

            return finalPrice;
        }
    }
}
