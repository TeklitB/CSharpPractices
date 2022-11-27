using EFCoreRelationshipsAndInheritance.EFCommon;

namespace EFCoreRelationshipsAndInheritance.Data.Model
{
    public class Brick
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public Color? Color { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<BrickAvailability> Availability { get; set; }
    }
}
