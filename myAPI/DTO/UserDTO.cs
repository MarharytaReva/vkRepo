using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public string Password { get; set; }
        public string Login { get; set; }

        public List<UserAudioDTO> UserAudios { get; set; }
        public List<UserPhotoDTO> UserPhotos { get; set; }
        public List<UserVideoDTO> UserVideos { get; set; }
        public List<UserDocumentDTO> UserDocuments { get; set; }
        public List<PostDTO> Posts { get; set; }
        public List<UserDTO> Friends { get; set; }

        public int UserInfoId { get; set; }
        public UserInfoDTO UserInfo { get; set; }
        public UserPhotoDTO Ava { get; set; }

    }
}


//public int FriendCount { get; set; }
//public int VideoCount { get; set; }
//public int AudioCount { get; set; }
//public int DocumentCount { get; set; }