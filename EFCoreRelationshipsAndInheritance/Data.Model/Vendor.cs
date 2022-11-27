
namespace EFCoreRelationshipsAndInheritance.Data.Model
{
    public class Vendor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BrickAvailability> Availability { get;}
    }
}
