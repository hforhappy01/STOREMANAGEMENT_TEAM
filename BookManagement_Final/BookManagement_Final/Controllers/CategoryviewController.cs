
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
    public class CategoryviewController : ControllerBase
    {
        private readonly StoreContext _context;


        public CategoryviewController(StoreContext context)
        {
            _context = context;
        }

        //Get:api/User
        [HttpGet]
        public ActionResult<IEnumerable<categoryviewmodel>> Getall()
        {
            var cg = _context.Category.ToList();

            if (cg.Count > 0)
            {
                return cg;
            }
            else
                return NoContent();
        }

        // GET: api/Users/1
        [HttpGet("{id}")]
        public ActionResult<categoryviewmodel> Getall(int? id)
        {
            var cg = _context.Category.FirstOrDefault(x => x.categoryID == id);

            if (cg == null)
            {
                return BadRequest("The users by given Id does not exist in the database.");
            }

            return cg;
        }

        // PUT: api/User
        [HttpPut]
        public IActionResult Putcg(categoryviewmodel cg)
        {
            var cg1 = _context.Category.FirstOrDefault(x => x.categoryID == cg.categoryID);

            if (cg1 == null)
            {
                return BadRequest("The Id does not exist in the database.");
            }

            cg1.categoryID = cg.categoryID;
            cg1.categoryName = cg.categoryName;
            cg1.categoryDescription = cg.categoryDescription;
           



            _context.Entry(cg1).State = EntityState.Modified;

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
        public ActionResult<User> Postcategory(categoryviewmodel cg)
        {
            var cgdb = _context.Category.FirstOrDefault(x => x.categoryID == cg.categoryID);

            if (cgdb == null)
            {
                _context.Category.Add(cg);
                _context.SaveChanges();
                return CreatedAtAction("GetUsers", new { cg.categoryID }, cg);
            }
            return BadRequest("An attempt to insert failed. The user already exists in the base.");
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public ActionResult<categoryviewmodel> Deletecategory(int? id)
        {
            var cg = _context.Category.FirstOrDefault(x => x.categoryID == id);

            if (cg == null)
            {
                return BadRequest("The user by given Id does not exist in the database.");
            }

            _context.Category.Remove(cg);
            _context.SaveChanges();

            return cg;
        }

    }
}