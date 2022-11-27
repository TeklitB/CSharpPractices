using EFCoreRelationshipsAndInheritance.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRelationshipsAndInheritance.Domain.DataAccess.Repository
{
    public class Repository
    {
        private BrickDbContext _context;
        public Repository() {
            var factory = new BrickDbContextFactory();
            _context = factory.CreateDbContext(new string[] { });
        }
        public async Task AddData()
        {
            var brickKing = new Vendor { Name = "Brick King" }; 
            var heldDerSteine = new Vendor { Name = "Held Der Steine" };
            var vendors = new List<Vendor> { brickKing, heldDerSteine };

            await _context.AddRangeAsync(vendors);
            await _context.SaveChangesAsync();

            var rare = new Tag { Title = "Rare" };
            var ninjago = new Tag { Title = "Ninjago" };
            var minecraft = new Tag { Title = "MineCraft" };
            var tags = new List<Tag> { rare, ninjago, minecraft };
            
            await _context.AddRangeAsync(tags);
            await _context.SaveChangesAsync();

            var plate1 = new BasePlate
            {
                Title = "BasePlate 16 x 16 with blue water pattern",
                Color = EFCommon.Color.Green,
                Tags = new List<Tag> { rare, minecraft },
                Length = 16,
                Width = 16,
                Availability = new List<BrickAvailability>
                {
                    new BrickAvailability {Vendor = brickKing, AvailableAmount = 5, Price = 6.5m},
                    new BrickAvailability {Vendor = heldDerSteine, AvailableAmount = 10, Price = 6.0m},
                },
            };

            await _context.AddRangeAsync(plate1);   
            await _context.SaveChangesAsync();
        }

        public async Task Query()
        {
            var availability = await _context.BrickAvailabilities
                .Include(ba => ba.Brick)
                .Include(ba => ba.Vendor)
                .ToListAsync();

            var brick = await _context.Bricks
                .Include(nameof(Brick.Availability) + "." + nameof(BrickAvailability.Vendor))
                .Include(b => b.Tags)
                .ToListAsync();

            var simpleBrick = await _context.Bricks.ToListAsync();
            foreach(var item in simpleBrick)
            {
                // You can query associated table later on
                await _context.Entry(item).Collection(i => i.Tags).LoadAsync();

                Console.WriteLine($"Brick {item.Title} ");
                if (item.Tags.Any()) Console.WriteLine($"({string.Join(',', item.Tags.Select(t => t.Title))})");
            }
        }
    }
}
