namespace NewWebAPI_MAB.Models
{
    public class OrderDetailModel
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public OrderModel Order { get; set; } // Navigation property for the related Order
        public int ProductID { get; set; }
        public ProductModel Product { get; set; } // Navigation property for the related Product
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public int UserID { get; set; }
        public UserModel User { get; set; }
    }
}
