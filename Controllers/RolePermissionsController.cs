using ERP_user_management_sys.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Erp.UserManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolePermissionsController(UserManagementDBContext context) : ControllerBase
    {
        // GET: api/RolePermissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolePermission>>> GetRolePermissions()
        {
            return await context.RolePermissions.ToListAsync();
        }

        // GET: api/RolePermissions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RolePermission>> GetRolePermission(int id)
        {
            var rolePermission = await context.RolePermissions.FindAsync(id);

            if (rolePermission == null)
            {
                return NotFound();
            }

            return rolePermission;
        }

        // PUT: api/RolePermissions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRolePermission(int id, RolePermission rolePermission)
        {
            if (id != rolePermission.Id)
            {
                return BadRequest();
            }

            context.Entry(rolePermission).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolePermissionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RolePermissions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RolePermission>> PostRolePermission(RolePermission rolePermission)
        {
            context.RolePermissions.Add(rolePermission);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetRolePermission", new { id = rolePermission.Id }, rolePermission);
        }

        // DELETE: api/RolePermissions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRolePermission(int id)
        {
            var rolePermission = await context.RolePermissions.FindAsync(id);
            if (rolePermission == null)
            {
                return NotFound();
            }

            context.RolePermissions.Remove(rolePermission);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool RolePermissionExists(int id)
        {
            return context.RolePermissions.Any(e => e.Id == id);
        }
    }
}
