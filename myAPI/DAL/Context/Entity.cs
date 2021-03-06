using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class Entity
    {

       
        public int Id { get; set; }

        [InverseProperty("Entity")]
        public List<CommentedEntity> CommentedEntities { get; set; }

        [InverseProperty("Entity")]
        public List<LikedEntity> LikedEntities { get; set; }
    }
}
