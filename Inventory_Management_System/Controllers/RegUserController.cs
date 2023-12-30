using Inventory_Management_System.DataBase;
using Inventory_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Management_System.Controllers
{
    [ApiController]
    [Route("/User/")]
    public class RegUserController : ControllerBase
    {
        private readonly Context _context;
        public RegUserController(Context contex)
        {
            _context = contex;
        }

        [HttpPost]
        public ActionResult CreatNewUser([FromBody] CreateUser user) {
            if (user.User_Name != null) {
                _context.Add(user);
                _context.SaveChanges();
                CookieOptions option = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(1),
                    Path = "/User/Role",
                    IsEssential = true
                };

                Response.Cookies.Append("Role", "Worker");
            }
            return Ok();
        }
    }
}
