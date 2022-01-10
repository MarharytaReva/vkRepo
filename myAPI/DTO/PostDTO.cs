using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PostDTO
    {
        public List<UserDTO> Likes { get; set; }
        public List<CommentDTO> Comments { get; set; }

        public int PostId { get; set; }
       
        public UserDTO User { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }

        public List<UserAudioDTO> UserAudios { get; set; }
        public List<UserDocumentDTO> UserDocuments { get; set; }
        public int LikeCount { get; set; }
        public bool isLiked { get; set; }
        public int CommentCount { get; set; }

        public VisibilityDTO Visibility { get; set; }
    }
}
