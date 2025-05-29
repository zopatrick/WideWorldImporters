using Microsoft.EntityFrameworkCore;
using WideWorldImporters.Server.Models;

namespace WideWorldImporters.API.Services
{
    public class CountryManager
    {
        private readonly ApplicationDbContext _context;

        public CountryManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Country>> GetAllAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country?> GetByIdAsync(int id)
        {
            //var obj = _context.Countries.FindAsync(id);
            return await _context.Countries.FindAsync(id);
        }

        public async Task<Country> CreateAsync(Country country)
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
            return country;
        }

        public async Task<bool> UpdateAsync(int id, Country country)
        {
            var existing = await _context.Countries.FindAsync(id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(country);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null) return false;

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
