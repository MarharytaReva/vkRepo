using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class Community
    {
        public int CommunityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }



        
        public int AvaId { get; set; }
        public UserPhoto Ava { get; set; }


        [ForeignKey("Creator")]
        public int CreatorId { get; set; }
        public User Creator { get; set; }
        
        [InverseProperty("Community")]
        public List<Membership> Memberships { get; set; }
       
        [InverseProperty("Community")]
        public List<Subscribition> Subscribitions { get; set; }



        [InverseProperty("Community")]
        public List<UserAudio> UserAudios { get; set; }
        [InverseProperty("Community")]
        public List<UserVideo> UserVideos { get; set; }
        [InverseProperty("Community")]
        public List<UserPhoto> UserPhotos { get; set; }
        [InverseProperty("Community")]
        public List<UserDocument> UserDocuments { get; set; }


        [InverseProperty("Community")]
        public List<Post> Posts { get; set; }
    }
}
