using Microsoft.EntityFrameworkCore;
using SPI.Data;
using SPI.Models;

namespace SPI.Repositories
{
    public class SupplierRepository:IRepository<Supplier>
    {
        private readonly SparePartsInventoryDBContext _dbContext;
        public SupplierRepository(SparePartsInventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CountAsync()
        {
            return await _dbContext.Set<Category>().CountAsync();
        }

        // Retrieve all entity from the database
        public async Task<IEnumerable<Supplier>> GetAllAsync() => await _dbContext.Suppliers.ToArrayAsync();

        // Add or create new entity
        public async Task AddAsync(Supplier supplier)
        {
            await _dbContext.Suppliers.AddAsync(supplier);
            await _dbContext.SaveChangesAsync();
        }

        // Delete an entity
        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Suppliers.FindAsync(id);
            if (entity != null)
            {
                _dbContext.Suppliers.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        // Retrieve an entity from database using only an id
        public async Task<Supplier> GetByIDAsync(int id) => await _dbContext.Suppliers.FindAsync(id);

        // Update the entity
        public async Task UpdateAsync(Supplier supplier)
        {
            _dbContext.Entry(supplier).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateQuantityAsync(int id, int quantityDelta)
        {
        }

    }
}
