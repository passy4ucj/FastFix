using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FastFixApi.Entity;
using FastFixApi.Models;

namespace FastFixApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceSubCategoriesController : ControllerBase
    {
        private readonly FastFixContext _context;

        public ServiceSubCategoriesController(FastFixContext context)
        {
            _context = context;
        }

        // GET: api/ServiceSubCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceSubCategory>>> GetServiceSubCategories()
        {
            return await _context.ServiceSubCategories
                .Include(s => s.ServiceCategory)
                .ToListAsync();
        }

        // GET: api/ServiceSubCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ServiceSubCategory>>> GetServiceSubCategory(int id)
        {
            var serviceSubCategory = await _context.ServiceSubCategories.FindAsync(id);



            if (serviceSubCategory == null)
            {
                return NotFound();
            }
            // return serviceSubCategory;


            return await _context.ServiceSubCategories
                .Include(s => s.ServiceCategory)
                .Where(s => s.Id == id)
                .ToListAsync();

        }


        // PUT: api/ServiceSubCategories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceSubCategory(int id, ServiceSubCategory serviceSubCategory)
        {
            if (id != serviceSubCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceSubCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceSubCategoryExists(id))
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

        // POST: api/ServiceSubCategories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ServiceSubCategory>> PostServiceSubCategory(ServiceSubCategory serviceSubCategory)
        {
            _context.ServiceSubCategories.Add(serviceSubCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceSubCategory", new { id = serviceSubCategory.Id }, serviceSubCategory);
        }

        // DELETE: api/ServiceSubCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceSubCategory>> DeleteServiceSubCategory(int id)
        {
            var serviceSubCategory = await _context.ServiceSubCategories.FindAsync(id);
            if (serviceSubCategory == null)
            {
                return NotFound();
            }

            _context.ServiceSubCategories.Remove(serviceSubCategory);
            await _context.SaveChangesAsync();

            return serviceSubCategory;
        }

        private bool ServiceSubCategoryExists(int id)
        {
            return _context.ServiceSubCategories.Any(e => e.Id == id);
        }
    }
}
