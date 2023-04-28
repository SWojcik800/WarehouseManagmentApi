using Microsoft.EntityFrameworkCore;
using System.Linq;
using WarehouseManagment.Core.Shipment;
using WarehouseManagment.Infrastructure.Data;
using WarehouseManagment.Infrastructure.Entities;

namespace WarehouseManagment.Infrastructure.Repositories
{
    public sealed class ShipmentRepository : IShipmentRepository
    {
        private readonly WarehouseContext _context;

        public ShipmentRepository(WarehouseContext context)
        {
            _context = context;
        }

        public async Task<List<Core.Shipment.Shipment>> GetAll()
        {
            return await _context.Shipments
                .Include(x => x.Products)
                .Where(x => !x.AcceptedDate.HasValue)
                .Select(x => new Core.Shipment.Shipment(x.Id, 
                    x.Products.Select(p => new ShipmentProduct(p.Id, p.Name, p.Description, p.ManufactureraName, p.Count))
                    .ToList(),
                 x.ShipmentArrived))
                .ToListAsync();
        }

        public async Task<List<AcceptedShipment>> GetAccepted()
        {
            return await _context.Shipments
                .Include(x => x.Products)
                .Where(x => x.AcceptedDate.HasValue)
                .Select(x => new AcceptedShipment(x.Id,
                    x.Products.Select(p => new ShipmentProduct(p.Id, p.Name, p.Description, p.ManufactureraName, p.Count))
                        .ToList(),
                    x.ShipmentArrived,
                    x.AcceptedDate.Value)
                )
                .ToListAsync();
        }

        public Task<List<Core.Shipment.Shipment>> GetById()
        {
            throw new NotImplementedException();
        }

        public async Task Save(Core.Shipment.Shipment shipment)
        {
            _context.Shipments.Add(
                new Entities.Shipment() 
                { Id = shipment.Id, Products = shipment.Products.Select(x => new Product()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        ManufactureraName = x.ManufactureraName,
                        Count = x.Count
                    }).ToList(), ShipmentArrived = DateTime.Now}
            );

            await _context.SaveChangesAsync();
        }

        public async Task Save(AcceptedShipment acceptedShipment)
        {
            _context.Shipments.Add(
                new Entities.Shipment()
                {
                    Id = acceptedShipment.Id,
                    Products = acceptedShipment.Products.Select(x => new Product()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        ManufactureraName = x.ManufactureraName,
                        Count = x.Count
                    }).ToList(),
                    ShipmentArrived = DateTime.Now,
                    AcceptedDate = DateTime.Now
                }
            );

            await _context.SaveChangesAsync();
        }
    }
}
