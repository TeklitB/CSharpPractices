
namespace EFCoreRelationshipsAndInheritance.Data.Model
{
    public class BrickAvailability
    {
        public int Id { get; set; }
        public Vendor Vendor { get; set; }       
        /// <summary>
        /// If you have one-to-Many or Many-to-one relationship
        /// add the foriegn key in addition to the navigation property
        /// </summary>
        public int VendorId { get; set; }
        public Brick Brick { get; set; }
        public int BrickId { get; set; }
        public int AvailableAmount { get; set; }
        public decimal Price { get; set; }

    }
}
