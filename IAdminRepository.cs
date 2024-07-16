using Microsoft.EntityFrameworkCore;
using CargoApi.Models;

namespace CargoApi.Repositories
{
    public interface IAdminRepository
    {
        Task<IEnumerable<Admin>> GetAllAdminAsync();
        Task<Admin> GetAdminByIdAsync(int id);
        Task<Admin> AddAdminAsync(Admin admin);
        Task<Admin> UpdateAdminAsync(Admin admin);
        Task<Admin> DeleteAdminAsync(int id);
    }    
}
