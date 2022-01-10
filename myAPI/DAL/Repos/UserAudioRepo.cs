using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class UserAudioRepo : RepoBase<UserAudio>
    {
        public UserAudioRepo(DbContext context) : base(context) { }
    }
}
