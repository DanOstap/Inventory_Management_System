using Inventory_Management_System.DataBase;
using Inventory_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Management_System.Controllers
{
    [ApiController]
    [Route("/Products_Manage")]
    public class Products_Manage_Controller : ControllerBase
    {
        private readonly Contex _contex;
        public Products_Manage_Controller(Contex contex)
        {
            _contex = contex;
        }
        [HttpGet("All")]
        public async Task<ActionResult<List<Products>>> GetAll()
        {
            var products = await _contex.Products.ToListAsync();
            _contex.
            return Ok(products); // Return in format JSON
        }
        [HttpGet("ByName")]
        public async Task<ActionResult<List<Products>>> GetByName(string Name_Search) {
            try {
                var result = await _contex.Products.Where(x => x.Name_Product == Name_Search).ToListAsync();
                return Ok(result);
            }
            catch {
                    return  BadRequest();
            }
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Post_Product([FromBody] Products _model) {
            _contex.Add(_model);
            _contex.SaveChangesAsync();
            return Ok("Operation Confirm");
        }
    }
}
