namespace SampleTechnologyForTest.Entities.Entity.Orders
{
    public class Order : BaseEntity
    {
        public long OrderNumber { get; set; }
        public double FinalAmount { get; set; }
        public int NumberOfItems { get; set; }
        public int DicountPercent { get; set; }

        public List<OrderItem> OrderItems { get; set; } = [];

        private Order()
        {

        }

        private Order(long orderNumber, double finalAmount, int numberOfItem, int discountPercent)
        {
            OrderNumber = orderNumber;
            FinalAmount = finalAmount;
            NumberOfItems = numberOfItem;
            DicountPercent = discountPercent;
            UserId = Guid.NewGuid().ToString();
            InsertDate = DateTime.Now;
            IsDelete = false;
        }


        public static Order Create(long orderNumber, double finalAmount, int numberOfItem, int discountPercent)
        {
            return new Order(orderNumber, finalAmount, numberOfItem, discountPercent);
        }
    }
}
