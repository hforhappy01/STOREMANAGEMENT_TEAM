using bookstore_project.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace bookstore_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly StoreContext _context;
        public AdminController(StoreContext context)
        {
            _context = context;
        }

        //Get:api/admin
        [HttpGet]
        public ActionResult<IEnumerable<Admin>> GetAdmin()
        {
            var admins = _context.Admins.ToList();

            if (admins.Count > 0)
            {
                return admins;
            }
            else
                return NoContent();
        }

        // GET: api/admins/1
        [HttpGet("{id}")]
   
            public async Task<ActionResult<Admin>> GetAdminAsync(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var admins = await _context.Admins
                                        .Where(x => x.adminId == id)
                                        .FirstOrDefaultAsync();

            if (admins == null)
            {
                return BadRequest("The users by given Id does not exist in the database.");
            }

            return admins;
        }

        [HttpPut]
        public IActionResult Putadmin(Admin admin)
        {
            var adminDb = _context.Admins.FirstOrDefault(x => x.adminId == admin.adminId);

            if (adminDb == null)
            {
                return BadRequest("The Id does not exist in the database.");
            }

           adminDb.adminId = admin.adminId;
            adminDb.email = admin.email;
            adminDb.passwordHash = admin.passwordHash;
           



            _context.Entry(adminDb).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
                return Ok("The changes made successfully.");
            }
            catch (Exception)
            {
                return BadRequest("Database update has failed.");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Admin>> Postadmin(Admin admin)
        {
          
            var adminDb = await _context.Admins
                                            .Where(pub => pub.adminId == admin.adminId)
                                            .FirstOrDefaultAsync();

            if (adminDb == null)
            {
                _context.Admins.Add(admin);
                _context.SaveChanges();
                return CreatedAtAction("GetUsers", new { admin.adminId }, admin);
            }
            return BadRequest("An attempt to insert failed. The user already exists in the base.");
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public ActionResult<Admin> Deleteadmin(int? id)
        {
            var admin = _context.Admins.FirstOrDefault(x => x.adminId == id);

            if (admin == null)
            {
                return BadRequest("The user by given Id does not exist in the database.");
            }

            _context.Admins.Remove(admin);
            _context.SaveChanges();

            return admin;
        }

    }


}
