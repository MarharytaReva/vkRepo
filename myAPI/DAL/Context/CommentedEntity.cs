using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class CommentedEntity
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Entity")]
        public int EntityId { get; set; }
        public Entity Entity { get; set; }

        [ForeignKey("Comment")]
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
