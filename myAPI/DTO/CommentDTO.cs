using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CommentDTO
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public List<CommentMediaDTO> CommentMedias { get; set; }
        public UserDTO User { get; set; }
        public int PostId { get; set; }
        public List<UserDTO> Likes { get; set; }
        public int LikeCount { get; set; }
        public bool isLiked { get; set; }
    }
}
