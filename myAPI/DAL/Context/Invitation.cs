using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class Invitation
    {
       
        public int FromUserId { get; set; }
        public User FromUser { get; set; }

        
        public int ToUserId { get; set; }
        public User ToUser { get; set; }
    }
}
