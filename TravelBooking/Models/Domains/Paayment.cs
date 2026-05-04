namespace TravelBooking.Models.Domains
{
    public class Paayment
    {
        public Guid Id { get; set; }
        public Guid BookingId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionId { get; set; }

        public string TransactionStatus { get; set; }

        public DateTime PaymentDate { get; set; }

        //Navigation property

        public Booking Booking { get; set; }
    }
}
