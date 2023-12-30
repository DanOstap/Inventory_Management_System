using Inventory_Management_System.DataBase;
using Inventory_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Management_System.Controllers
{
    [ApiController]
    [Route("/Login/")]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;
        public LoginController(Context contex)
        {
            _context = contex;
        }
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginUser _user)
        {
            var user = await _context.User.FirstOrDefaultAsync(a => a.User_Name == _user.Name);

            if (user != null)
            {
                if (user.User_Password == _user.Password)
                {
                    var userPosition = user.User_Position;
                    
                    CookieOptions option = new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(1),
                        Path = "/User/Role",
                        IsEssential = true
                    };

                    Response.Cookies.Append("Role", userPosition);
                    return Ok();
                }
                throw new Exception("Incorrect password, please try again.");
            }
            throw new Exception("Incorrect username. Maybe you want to register?");
        }
    }
}
