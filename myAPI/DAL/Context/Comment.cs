using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    [Table("Comments")]
    public class Comment : Entity
    {
        public string Text { get; set; }
        [InverseProperty("Comment")]
        public List<CommentMedia> CommentMedias { get; set; }

       
        [InverseProperty("Comment")]
        public CommentedEntity CommentedEntity { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [InverseProperty("Comment")]
        public List<Answer> Answers { get; set; }
    }
}
