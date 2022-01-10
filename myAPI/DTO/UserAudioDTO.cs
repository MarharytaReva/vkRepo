using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserAudioDTO : Media
    {
        public VisibilityDTO Visibility { get; set; }
    }
}
