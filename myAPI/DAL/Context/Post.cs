using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Context
{
    [Table("Posts")]
    public class Post : Entity
    {
        
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public string Text { get; set; }
        public string Title { get; set; }

        [InverseProperty("Post")]
        public List<UserPhoto> UserPhotos { get; set; }
        [InverseProperty("Post")]
        public List<UserVideo> UserVideos { get; set; }
        [InverseProperty("Post")]
        public List<UserAudio> UserAudios { get; set; }
        [InverseProperty("Post")]
        public List<UserDocument> UserDocuments { get; set; }
        
        [ForeignKey("Visibility")]
        public int VisibilityId { get; set; }
        public Visibility Visibility { get; set; }


        [ForeignKey("Community")]
        public int? CommunityId { get; set; }
        public Community Community { get; set; }
    }
}
