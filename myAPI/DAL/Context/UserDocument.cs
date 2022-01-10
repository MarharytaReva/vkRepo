using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class UserDocument
    {
        [Key]
        public int MadiaId { get; set; }
        public string Directory { get; set; }
        public string Extension { get; set; }
        public string FileName { get; set; }
        public int VisibilityId { get; set; }
        public Visibility Visibility { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Community")]
        public int? CommunityId { get; set; }
        public Community Community { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
