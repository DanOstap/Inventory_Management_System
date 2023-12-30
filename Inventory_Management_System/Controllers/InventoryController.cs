using Inventory_Management_System.DataBase;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Management_System.Controllers
{
    [ApiController]
    [Route("/InventoryManage")]
    public class InventoryController : ControllerBase
    {
        private readonly Context _context;
        public InventoryController(Context context) {
            _context = context;
        }

        [HttpGet("All")]
        public async  Task<ActionResult> GetAll () {
            if (Request.Cookies["Role"]  == "Admin") {
                var products = await _context.Products.ToListAsync();
                return Ok(products);      
            } 
            throw new Exception("Sorry, you haven't rights");
        }
        [HttpGet("ByName")]
        public async Task<ActionResult> GetByName(string Name_product) {
            if (Request.Cookies["Role"] == "Admin") {
                try
                {
                    var result = await _context.Inventory.Where(x => x.Name_Product == Name_product).ToListAsync();
                    return Ok(result);
                }
                catch
                {
                    throw new Exception("No products with this name");
                }
            }
            throw new Exception("Sorry, you haven't rights");
        }
        [HttpDelete]
    }
}
