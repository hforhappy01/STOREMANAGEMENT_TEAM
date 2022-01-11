

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
    public class bookstorecontroller : ControllerBase
    {
        private readonly StoreContext _context;


        public bookstorecontroller(StoreContext context)
        {
            _context = context;
        }

        //Get:api/User
        [HttpGet]
        public ActionResult<IEnumerable<Bookstore>> Getall()
        {
            var bs = _context.bookstores.ToList();

            if (bs.Count > 0)
            {
                return bs;
            }
            else
                return NoContent();
        }

        // GET: api/Users/1
        [HttpGet("{id}")]
        public ActionResult<Bookstore> Getall(int? id)
        {
            var bs = _context.bookstores.FirstOrDefault(x => x.Id == id);

            if (bs == null)
            {
                return BadRequest("The users by given Id does not exist in the database.");
            }

            return bs;
        }

        // PUT: api/User
        [HttpPut]
        public IActionResult putbookstore(Bookstore bstore)
        {
            var bs = _context.bookstores.FirstOrDefault(x => x.Id == bstore.Id);

            if (bs == null)
            {
                return BadRequest("The Id does not exist in the database.");
            }

            bs. Name= bstore.Name;
            bs.Author = bstore.Author;
            bs.Publisher = bstore.Publisher;
            bs.Price = bstore.Price;
            bs.Edition = bstore.Edition;


            _context.Entry(bs).State = EntityState.Modified;

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
        public ActionResult<Bookstore> Postbstore(Bookstore bstore)
        {
            var bs = _context.bookstores.FirstOrDefault(x => x.Id == bstore.Id);

            if (bs == null)
            {
                _context.bookstores.Add(bstore);
                _context.SaveChanges();
                return CreatedAtAction("getall", new { bstore.Id }, bstore);
            }
            return BadRequest("An attempt to insert failed. ");
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public ActionResult<Bookstore> Deletebstore(int? id)
        {
            var bs = _context.bookstores.FirstOrDefault(x => x.Id == id);

            if (bs == null)
            {
                return BadRequest("The user by given Id does not exist in the database.");
            }

            _context.bookstores.Remove(bs);
            _context.SaveChanges();

            return bs;
        }

    }
}