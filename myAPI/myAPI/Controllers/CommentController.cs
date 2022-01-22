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
    public class CommentController : Controller
    {
        CommentManager commentManager;
        public CommentController(CommentManager commentManager)
        {
            this.commentManager = commentManager;
        }
        [HttpGet("{pageNumber:int}")]
        public async Task<IActionResult> Get(int pageNumber)
        {
            var res = await commentManager.GetAllAsync(pageNumber);
            return Json(
            new
            {
                data = res,
                offset = commentManager.PaginationCount
            });
        }
    }
}
