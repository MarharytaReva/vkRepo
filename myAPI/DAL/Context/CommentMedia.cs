using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class CommentMedia 
    {
        [Key]
        public int MadiaId { get; set; }
        public string Directory { get; set; }
        public string Extension { get; set; }
        public string FileName { get; set; }

        [ForeignKey("Answer")]
        public int? AnswerId { get; set; }
        public Answer Answer { get; set; }

        [ForeignKey("Comment")]
        public int? CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
