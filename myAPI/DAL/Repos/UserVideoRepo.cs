using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class UserVideoRepo : RepoBase<UserVideo>
    {
        public UserVideoRepo(DbContext context) : base(context) { }
    }
}
