using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class Visibility
    {
        public int VisibilityId { get; set; }
        public string Name { get; set; }



        [InverseProperty("Visibility")]
        public List<Post> Posts { get; set; }

        [InverseProperty("Visibility")]
        public List<UserVideo> UserVideos { get; set; }
        [InverseProperty("Visibility")]
        public List<UserPhoto> UserPhotos { get; set; }
        [InverseProperty("Visibility")]
        public List<UserDocument> UserDocuments { get; set; }
        [InverseProperty("Visibility")]
        public List<UserAudio> UserAudios { get; set; }
    }
}
