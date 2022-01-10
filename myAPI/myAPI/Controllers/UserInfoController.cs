using BLL;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserInfoController : Controller
    {
        private UserInfoManager userInfoManager;
        public UserInfoController(UserInfoManager userInfoManager)
        {
            this.userInfoManager = userInfoManager;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserInfoDTO>> Get(int id)
        {
            var info = await userInfoManager.GetItemAsync(id);
            if (info is null)
                return NotFound();
            return info;
        }
    }
}
