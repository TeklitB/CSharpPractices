
namespace EFCoreRelationshipsAndInheritance.Domain.Model
{
    public class Tag
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        // Many-to-Many relation between Tag and Bricks
        public ICollection<Brick> Bricks { get; set; }
    }
}
