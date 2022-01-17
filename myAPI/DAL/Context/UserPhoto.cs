using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    [Table("UserPhotos")]
    public class UserPhoto : Entity
    {
        public string Directory { get; set; }
        public string Extension { get; set; }
        public string FileName { get; set; }

        public int LineNumber { get; set; }

        [ForeignKey("Visibility")]
        public int VisibilityId { get; set; }
        public Visibility Visibility { get; set; }


        
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Community")]
        public int? CommunityId { get; set; }
        public Community Community { get; set; }

        [ForeignKey("Post")]
        public int? PostId { get; set; }
        public Post Post { get; set; }
    }
}
