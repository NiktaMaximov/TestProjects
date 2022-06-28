namespace EFCoreTestApp.Models
{
    public class ProductShipmentJunction
    {
        public long ID { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public long ShipmentId { get; set; }
        public Shipment Shipment { get; set; }
    }
}
