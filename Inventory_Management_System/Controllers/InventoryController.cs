using Inventory_Management_System.DataBase;
using Inventory_Management_System.Models;
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
        public InventoryController(Context context)
        {
            _context = context;
        }

        [HttpGet("All")]
        public async Task<ActionResult> GetAll()
        {
            if (Request.Cookies["Role"] == "Admin")
            {
                var products = await _context.Products.ToListAsync();
                return Ok(products);
            }
            throw new Exception("Sorry, you haven't rights");
        }


        [HttpGet("GetQuantityProduct")]
        public async Task<ActionResult> GetQuantityByName(string Name_product)
        {
            if (Request.Cookies["Role"] == "Admin")
            {
                var result = await _context.Inventory.SingleOrDefaultAsync(x => x.Name_Product == Name_product);
                if (result != null)
                {
                    return Ok($"{Name_product} are:  {result.Equals}");
                }
                throw new Exception("Sorry, we haven't this product");
            }
            throw new Exception("Sorry, you haven't rights");
        }


        [HttpGet("ByName")]
        public async Task<ActionResult> GetByName(string Name_product)
        {
            if (Request.Cookies["Role"] == "Admin")
            {
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


        [HttpPost]
        public async Task<ActionResult> Post_Product_To_Inventory([FromBody] Inventory inventory)
        {
            if (Request.Cookies["Role"] == "Admin")
            {
                _context.AddAsync(inventory);
                _context.SaveChangesAsync();
            }
            throw new Exception("Sorry, you haven't rights");
        }


        [HttpDelete("ByNameProduct")]
        public async Task<ActionResult> DeleteByName(string Name_product)
        {
            if (Request.Cookies["Role"] == "Admin")
            {
                var result = await _context.Inventory.SingleOrDefaultAsync(a => a.Name_Product == Name_product);
                if (result != null)
                {
                    _context.Inventory.Remove(result);
                    _context.SaveChangesAsync();
                }
            }
            throw new Exception("No products with this name");
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] PathInventory _model)
        {
            var itemToUpdate = await _context.Inventory.FindAsync(id);
            if (itemToUpdate == null)
            {
                return NotFound();
            }
            itemToUpdate.Quantity_Products = _model.Quantity_Products;
            itemToUpdate.Storage = _model.Storage;
            _context.Update(itemToUpdate);
            _context.SaveChangesAsync();
            return Ok();
        }
    }
}
