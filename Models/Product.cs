namespace Day19_AutoMapper_Serilog.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string Category { get; set; } = string.Empty;
    }
}