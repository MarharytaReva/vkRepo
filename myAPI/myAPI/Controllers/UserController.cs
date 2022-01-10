using BLL;
using DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

using System.IO;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;

using System.Threading.Tasks;
using DTO;

namespace myAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        UserManager userManager;

        public UserController(UserManager userManager)
        {
            this.userManager = userManager;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            var user = await userManager.GetItemAsync(id);
            if (user is null)
                return NotFound();
            return user;
        }
        [HttpGet("/getCollectionCount/{id:int}/{collectionName}")]
        public async Task<ActionResult<int>> GetCollectionCount(int id, string collectionName)
        {
            int count = await userManager.GetCollectionCountAsync(collectionName, id);
            return count;
        }
    }
}
