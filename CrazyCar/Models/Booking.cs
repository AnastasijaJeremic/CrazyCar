namespace CrazyCar.Models
{
    public class Booking
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }

        public bool ValidateBooking(out string errorMessage)
        {
            if (StartDate <= DateTime.Now)
            {
                errorMessage = "StartDate mora biti u budućnosti.";
                return false;
            }

            if (EndDate <= StartDate)
            {
                errorMessage = "EndDate mora biti nakon StartDate.";
                return false;
            }

            decimal expectedPrice = (EndDate - StartDate).Days * 100;
            if (TotalPrice != expectedPrice)
            {
                errorMessage = $"Ukupna cena nije tačna. Očekivana cena je {expectedPrice}.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}
