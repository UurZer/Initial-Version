namespace Int.Application.Features.OrderTransactions.Upsert
{
    public class OrderTransactionRequest
    {
        public Guid Id { get; set; }
        
        public Guid UserId { get; set; }

        public Guid ProductId { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal TotalQuantity { get; set; }

        public string Status { get; set; }
    }
}