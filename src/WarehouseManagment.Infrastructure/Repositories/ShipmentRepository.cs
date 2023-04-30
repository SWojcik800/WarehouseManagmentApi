using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using WarehouseManagment.Core.Exceptions;
using WarehouseManagment.Core.Shipment;
using WarehouseManagment.Infrastructure.Data;

namespace WarehouseManagment.Infrastructure.Repositories
{
    public sealed class ShipmentRepository : IShipmentRepository
    {
        private readonly WarehouseContext _context;
        private readonly IMapper _mapper;

        public ShipmentRepository(WarehouseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ShipmentDomain>> GetAll()
        {

            var entities =  await _context.Shipments
                .Include(x => x.Products)
                .Where(x => !x.AcceptedDate.HasValue && !x.ShipmentIssued.HasValue)
                .ToListAsync();

            var mapped = _mapper.Map<List<ShipmentDomain>>(entities);

            return mapped;
        }

        public async Task<List<AcceptedShipment>> GetAccepted()
        {
            var entities = await _context.Shipments
                .Include(x => x.Products)
                .Where(x => x.AcceptedDate.HasValue)                
                .ToListAsync();

            var mapped = _mapper.Map<List<AcceptedShipment>>(entities);

            return mapped;
        }

        public async Task<ShipmentDomain> GetById(long id)
        {
            var entity = await _context.Shipments
                .AsNoTracking()
                .Include(x => x.Products)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null)
                throw new NotFoundException($"Shipment with id: {id} not found");

            var mapped = _mapper.Map<ShipmentDomain>(entity);
            return mapped;
        }

        public async Task Save(Core.Shipment.ShipmentDomain shipment)
        {
            var entity = _mapper.Map<Entities.Shipment>(shipment);
            _context.Shipments.Add(entity);

            await _context.SaveChangesAsync();
        }

        public async Task Save(AcceptedShipment acceptedShipment)
        {
            var entity = _mapper.Map<Entities.Shipment>(acceptedShipment);
            _context.Shipments.Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task Save(IssuedShipment issuedShipment)
        {
            var entity = _mapper.Map<Entities.Shipment>(issuedShipment);
            _context.Shipments.Update(entity);

            await _context.SaveChangesAsync();
        }
    }
}
