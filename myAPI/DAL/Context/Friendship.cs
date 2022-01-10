using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class Friendship
    {
        
        public int FirstUserId { get; set; }
        public User FirstUser { get; set; }

       
        public int SecondUserId { get; set; }
        public User SecondUser { get; set; }
    }
}
