using System.ComponentModel.DataAnnotations.Schema;

namespace SampleTechnologyForTest.Entities.Entity.Orders
{
    public class Order : BaseEntity
    {
        public long OrderNumber { get; set; }
        public decimal FinalAmount { get; set; }
        public int NumberOfItems { get; set; }
        [Column("DicountPercent")]
        public int DiscountPercent { get; set; }

        public List<OrderItem> OrderItems { get; set; } = [];

        private Order()
        {

        }

        private Order(long orderNumber, decimal finalAmount, int numberOfItem, int discountPercent)
        {
            OrderNumber = orderNumber;
            FinalAmount = finalAmount;
            NumberOfItems = numberOfItem;
            DiscountPercent = discountPercent;
            InsertDate = DateTime.Now;
            IsDeleted = false;
        }


        public static Order Create(long orderNumber, decimal finalAmount, int numberOfItem, int discountPercent)
        {
            return new Order(orderNumber, finalAmount, numberOfItem, discountPercent);
        }
    }
}
