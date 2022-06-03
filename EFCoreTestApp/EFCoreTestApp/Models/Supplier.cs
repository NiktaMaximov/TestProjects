namespace EFCoreTestApp.Models
{
    public class Supplier
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public ConcatDetails Concat { get; set; }
    }
}
