using bookstore_project.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace bookstore_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly StoreContext _context;
    

        public UserController(StoreContext context)
        {
            _context = context;
        }

        //Get:api/User
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var users = _context.users.ToList();

            if (users.Count > 0)
            {
                return users;
            }
            else
                return NoContent();
        }

        // GET: api/Users/1
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int? id)
        {
            var users = _context.users.FirstOrDefault(x => x.UserId == id);

            if (users == null)
            {
                return BadRequest("The users by given Id does not exist in the database.");
            }

            return users;
        }

        // PUT: api/User
        [HttpPut]
        public IActionResult PutUser(User user)
        {
            var userDB = _context.users.FirstOrDefault(x => x.UserId == user.UserId);

            if (user == null)
            {
                return BadRequest("The Id does not exist in the database.");
            }

            userDB.FirstName = user.FirstName;
            userDB.LastName = user.LastName;
            userDB.EmailAddress = user.EmailAddress;
            userDB.Password = user.Password;



            _context.Entry(userDB).State = EntityState.Modified;

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



        // POST: api/User
        [HttpPost]
        public ActionResult<User> PostUser(User user)
        {
            var userDB = _context.users.FirstOrDefault(x => x.UserId == user.UserId);

            if (userDB == null)
            {
                _context.users.Add(user);
                _context.SaveChanges();
                return CreatedAtAction("GetUsers", new { user.UserId }, user);
            }
            return BadRequest("An attempt to insert failed. The user already exists in the base.");
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public ActionResult<User> DeleteUser(int? id)
        {
            var users = _context.users.FirstOrDefault(x => x.UserId == id);

            if (users == null)
            {
                return BadRequest("The user by given Id does not exist in the database.");
            }

            _context.users.Remove(users);
            _context.SaveChanges();

            return users;
        }

    }
}