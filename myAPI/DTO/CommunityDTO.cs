using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CommunityDTO
    {
        public int CommunityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public UserPhotoDTO Ava { get; set; }

       
        public int CreatorId { get; set; }
        public UserDTO Creator { get; set; }

        public List<UserDTO> Members { get; set; }

        public List<UserDTO> Followers { get; set; }
        public List<UserAudioDTO> UserAudios { get; set; }
        public List<UserVideoDTO> UserVideos { get; set; }
        public List<UserPhotoDTO> UserPhotos { get; set; }
        public List<UserDocumentDTO> UserDocuments { get; set; }
        public List<PostDTO> Posts { get; set; }

        //public int MembersCount { get; set; }
        //public int FollowersCount { get; set; }
        //public int AudiosCount { get; set; }
        //public int VideosCount { get; set; }
        //public int PhotosCount { get; set; }
        //public int DocumentsCount { get; set; }
        //public int PostsCount { get; set; }
    }
}
