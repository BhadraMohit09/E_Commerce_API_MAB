namespace NewWebAPI_MAB.Models
{
    public class BillModel
    {
        public int BillID { get; set; }
        public string BillNumber { get; set; }
        public DateTime BillDate { get; set; }
        public int OrderID { get; set; }
        public OrderModel Order { get; set; } 
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal NetAmount { get; set; }
        public int UserID { get; set; }
        public UserModel User { get; set; }
    }
}
