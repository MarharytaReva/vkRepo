using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserPhotoDTO : Media
    {
        public int LineNumber { get; set; }
        public VisibilityDTO Visibility { get; set; }
        
    }
}
