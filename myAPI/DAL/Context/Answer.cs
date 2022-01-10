using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    [Table("Answers")]
    public class Answer : Entity
    {
        
        public string Text { get; set; }

        [InverseProperty("Answer")]
        public List<CommentMedia> CommentMedias { get; set; }

        [ForeignKey("Comment")]
        public int Id { get; set; }
        public Comment Comment { get; set; }

        [ForeignKey("ToUser")]
        public int? ToUserId { get; set; }
        public User ToUser { get; set; }

        [ForeignKey("FromUser")]
        public int FromUserId { get; set; }
        public User FromUser { get; set; }
    }
}
