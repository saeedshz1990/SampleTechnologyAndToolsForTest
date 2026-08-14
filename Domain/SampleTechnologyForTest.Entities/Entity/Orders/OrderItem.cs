using SampleTechnologyForTest.Entities.Entity.Products;

namespace SampleTechnologyForTest.Entities.Entity.Orders
{
    public class OrderItem : BaseEntity
    {
        public int CountOfItem { get; set; }
        public int DiscountOfAmount { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }

        public long OrderId { get; set; }
        public Order Order { get; set; }


        private OrderItem()
        {

        }

        private OrderItem(int countOfItem, int discountnOfAmount, long productId, long orderId)
        {
            CountOfItem = countOfItem;
            DiscountOfAmount = discountnOfAmount;
            ProductId = productId;
            OrderId = orderId;
            InsertDate = DateTime.Now;
            IsDeleted = false;
        }

        public static OrderItem Create(int countOfItem, int discountnOfAmount, long productId, long orderId)
        {
            return new OrderItem(countOfItem, discountnOfAmount, productId, orderId);
        }
    }
}
