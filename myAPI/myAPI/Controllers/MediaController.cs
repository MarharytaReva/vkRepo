using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MediaController : Controller
    {
        private FileResult GetBytes(string dir, string fileName, string extension)
        {
            string path = Environment.CurrentDirectory + $"\\Files\\{dir}\\{fileName}.{extension}";//@"\Files\img.jpg";
           

            byte[] mas = System.IO.File.ReadAllBytes(path);
            string file_type = $"application/{extension}";
            string file_name = fileName + "." + extension;
            return File(mas, file_type, file_name);
        }
        [HttpGet("{dir}/{fileName}/{extension}")]
        public IActionResult Get(string dir, string fileName, string extension)
        {
            try
            {
                return GetBytes(dir, fileName, extension);
            }
           catch(Exception ex)
            {
                return NotFound();
            }
        }
    }
}
