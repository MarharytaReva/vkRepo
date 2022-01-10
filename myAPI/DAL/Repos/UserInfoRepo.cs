using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class UserInfoRepo : RepoBase<UserInfo>
    {
        public UserInfoRepo(DbContext context) : base(context)
        {

        }
        public new UserInfo GetItem(int id, int idSecond = 0)
        {
            return (context as EnContactoContext).UserInfos.Include(x => x.Gender)
                .FirstOrDefault(x => x.UserInfoId == id);
        }
    }
}
