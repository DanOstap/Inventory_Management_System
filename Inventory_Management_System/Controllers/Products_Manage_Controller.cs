using Inventory_Management_System.DataBase;
using Inventory_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Management_System.Controllers
{
    [ApiController]
    [Route("/Products_Manage/")]
    public class Products_Manage_Controller : ControllerBase
    {
        private readonly Context _context;
        public Products_Manage_Controller(Context context)
        {
            _context = context;
        }
        [HttpGet("All")]
        public async Task<ActionResult> GetAll()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);            // Return in format JSON
        }
        [HttpGet("ByName")]
        public async Task<ActionResult> GetByName(string Name_Search) {
            try {
                var result = await _context.Products.Where(x => x.Name_Product == Name_Search).ToListAsync();
                return Ok(result);
            }
            catch {
                throw new Exception("No users with this Id");
            }
        }
        [HttpPost("/Add")]
        public async Task<IActionResult> Post([FromBody] Products _model) {
            _context.Add(_model);
            _context.SaveChangesAsync();
            return Ok("Operation Confirm");
        }
        [HttpDelete("/DeleteById{Id}")]
        public async Task<ActionResult> DeleteItemById(int Id) {
            var result = await _context.Products.SingleOrDefaultAsync(a => a.Id_Product == Id);
            if (result !=null) {
                _context.Products.Remove(result);
                _context.SaveChangesAsync();
                return Ok();

            }
            throw new Exception("No users with this Id");

        }
    }
}
