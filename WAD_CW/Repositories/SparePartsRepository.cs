using Microsoft.EntityFrameworkCore;
using SPI.Data;
using SPI.Models;

namespace SPI.Repositories
{
    public class SparePartsRepository : IRepository<SparePart>
    {
        private readonly SparePartsInventoryDBContext _dbContext;

        public SparePartsRepository(SparePartsInventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CountAsync()
        {
            return await _dbContext.Set<SparePart>().CountAsync();
        }

        public async Task<IEnumerable<SparePart>> GetAllAsync() => await _dbContext.SpareParts.Include(t => t.Category).Include(t => t.Supplier).ToArrayAsync(); //.

        public async Task<SparePart> GetByIDAsync(int id)
        {
            return await _dbContext.SpareParts.Include(t =>t.Category).Include(t=>t.Supplier).FirstOrDefaultAsync(t=>t.Id==id);
        }

        public async Task AddAsync(SparePart entity)
        {
            entity.Category = await _dbContext.Categories.FindAsync(entity.CategoryId.Value);
            entity.Supplier = await _dbContext.Suppliers.FindAsync(entity.SupplierId.Value);

            await _dbContext.SpareParts.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(SparePart entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.SpareParts.FindAsync(id);
            if (entity != null)
            {
                _dbContext.SpareParts.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }


        public async Task UpdateQuantityAsync(int id, int quantityDelta)
        {
            var sparePart = await _dbContext.SpareParts.FindAsync(id);
            if (sparePart != null)
            {
                sparePart.Quantity += quantityDelta;
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Spare part with ID {id} not found.");
            }
        }



    }
}
