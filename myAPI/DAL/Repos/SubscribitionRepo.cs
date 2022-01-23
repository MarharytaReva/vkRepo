using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class SubscribitionRepo : RepoBase<Subscribition>
    {
        public SubscribitionRepo(DbContext context) : base(context)
        {

        }
    }
}
