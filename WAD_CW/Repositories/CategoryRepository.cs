using Microsoft.EntityFrameworkCore;
using SPI.Data;
using SPI.Models;

namespace SPI.Repositories
{
    public class CategoryRepository: IRepository<Category>
    {
        private readonly SparePartsInventoryDBContext _dbContext;

        public CategoryRepository(SparePartsInventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CountAsync()
        {
            return await _dbContext.Set<Category>().CountAsync();
        }

        // Add or create new entity
        public async Task AddAsync(Category categories)
        {
            await _dbContext.Categories.AddAsync(categories);
            await _dbContext.SaveChangesAsync();
        }

        // Delete an entity
        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Categories.FindAsync(id);
            if (entity != null)
            {
                _dbContext.Categories.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        // Retrieve all entity from the database
        public async Task<IEnumerable<Category>> GetAllAsync() => await _dbContext.Categories.ToArrayAsync();

        // Retrieve an entity from database using only an id
        public async Task<Category> GetByIDAsync(int id) => await _dbContext.Categories.FindAsync(id);

        // Update the entity
        public async Task UpdateAsync(Category categories)
        {
            _dbContext.Entry(categories).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateQuantityAsync(int id, int quantityDelta)
        {
        }
    }
}
