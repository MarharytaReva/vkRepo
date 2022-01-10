using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AnswerDTO
    {
        public int AnswerId { get; set; }
        public string Text { get; set; }
        public List<CommentMediaDTO> CommentMedias { get; set; }
        public CommentDTO Comment { get; set; }

        
        public UserDTO ToUser { get; set; }
       
        
        public UserDTO FromUser { get; set; }

        public List<UserDTO> Likes { get; set; }
        public int LikeCount { get; set; }
        public bool isLiked { get; set; }
    }
}
