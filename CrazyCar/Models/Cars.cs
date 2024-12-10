namespace CrazyCar.Models
{
    public class Cars
    {
        public int ID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal PricePerDay { get; set; }
        public bool IsAvailable { get; set; }
        public string Image { get; set; }
        public decimal MaxPrice { get; set; }
        public decimal MinPrice { get; set; } 
    }
}
