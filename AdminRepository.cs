using Microsoft.EntityFrameworkCore;
using CargoApi.Models;
using CargoApi.Data;
namespace CargoApi.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _context;

        public AdminRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Admin>> GetAllAdminAsync()
        {
            return await _context.Admins.ToListAsync();
        }

        public async Task<Admin> GetAdminByIdAsync(int id)
        {
            return await _context.Admins.FirstOrDefaultAsync(a => a.AdminId == id);
        }

        public async Task<Admin> AddAdminAsync(Admin admin)
        {
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();
            return admin;
        }

        public async Task<Admin> UpdateAdminAsync(Admin admin)
        {
            _context.Admins.Update(admin);
            await _context.SaveChangesAsync();
            return admin;
        }

        public async Task<Admin> DeleteAdminAsync(int id)
        {
            var admin = await _context.Admins.FindAsync(id);
            if(admin != null)
            {
                _context.Admins.Remove(admin);
                await _context.SaveChangesAsync();
                return admin;
            }
            return null;
        }
    }
}
