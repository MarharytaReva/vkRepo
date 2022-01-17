using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public abstract class Media
    {
        public int Id { get; set; }
        public string Directory { get; set; }
        public string Extension { get; set; }
        public string FileName { get; set; }

        public int? UserId { get; set; }
        public int? CommunityId { get; set; }
        public int? PostId { get; set; }
    }
}
