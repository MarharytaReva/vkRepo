using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class UserRepo : RepoBase<User>
    {
        public UserRepo(DbContext context) : base(context) 
        {
          
        }
        public new User GetItem(int id, int idSecond = 0)
        {
            return (context as EnContactoContext).Users.Include(x => x.Ava)
                .FirstOrDefault(x => x.UserId == id);
        }
    }
}
