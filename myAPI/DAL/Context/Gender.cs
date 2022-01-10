using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class Gender
    {
        public int GenderId { get; set; }
        public string GenderName { get; set; }


        [InverseProperty("Gender")]
        public List<UserInfo> UserInfos { get; set; }
    }
}
