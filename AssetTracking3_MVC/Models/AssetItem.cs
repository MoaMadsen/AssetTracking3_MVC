namespace AssetTracking3_MVC.Models
{
    public class AssetItem
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public Office Office { get; set; }
        public int OfficeId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime EndOfLife { get; set; }
    }
}
