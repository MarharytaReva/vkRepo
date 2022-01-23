using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class LikedEntityRepo : RepoBase<LikedEntity>
    {
        public LikedEntityRepo(DbContext context) : base(context)
        {

        }
    }
}
