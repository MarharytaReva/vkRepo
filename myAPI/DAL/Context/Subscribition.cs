using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class Subscribition
    {
        [ForeignKey("Subscriber")]
        public int SubscriberId { get; set; }
        public User Subscriber { get; set; }

        [ForeignKey("Community")]
        public int CommunityId { get; set; }
        public Community Community { get; set; }
    }
}
