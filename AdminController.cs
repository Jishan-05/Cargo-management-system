using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using CargoApi.Repositories;
using CargoApi.Models;
using CargoApi.Data;

namespace CargoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;

        public AdminController(IAdminRepository adminrepository)
        {
            _adminRepository = adminrepository;
        }

        [Route("GetAdminlist")]   
        [HttpGet]
        public async Task<IActionResult> GetAdmins()
        {
            var admin = await _adminRepository.GetAllAdminAsync();
            return Ok();
        }

        [Route("GetAdminById/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAdmin(int id )
        {
            var admin = await _adminRepository.GetAdminByIdAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin);
        }

        [Route("AddAdmin")]
        [HttpPost]     
        public async Task<IActionResult> AddAdmin([FromBody] Admin admin)    
        {
            var addadmin = await _adminRepository.AddAdminAsync(admin);
            return CreatedAtAction(nameof(GetAdmin),new { id = addadmin.AdminId } , addadmin);
        }

        [Route("UpdateAdminById/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateAdmin(int id,[FromBody] Admin admin)
        {
            if (id != admin.AdminId)
            {
                return BadRequest();
            }
            var updateadmin = await _adminRepository.UpdateAdminAsync(admin);
            return Ok(updateadmin);
        }

        [Route("DeleteAdminById/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            await _adminRepository.DeleteAdminAsync(id);
            return NoContent();
            
        }
    }
}