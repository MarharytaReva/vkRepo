using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class UserInfo
    {
        public int UserInfoId { get; set; }

        public string Status { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public string CityCurrent { get; set; }
        public string CountryCurrent { get; set; }

        public string Additional { get; set; }

        [InverseProperty("Gender")]
        public int GenderId { get; set; }
        public Gender Gender { get; set; }

        public string StudyPlace { get; set; }
        public string WorkPlace { get; set; }

       
    }
}
