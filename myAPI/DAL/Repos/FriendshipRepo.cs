﻿using DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class FriendshipRepo : RepoBase<Friendship>
    {
        public FriendshipRepo(EnContactoContext context) : base(context)
        {

        }
    }
}
