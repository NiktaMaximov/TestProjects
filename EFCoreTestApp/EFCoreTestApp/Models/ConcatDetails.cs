namespace EFCoreTestApp.Models
{
    public class ConcatDetails
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public ConcatLocation Location { get; set; }
        // Для обязательного отношения
        //public long SupplierId { get; set; }
        public long? SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
