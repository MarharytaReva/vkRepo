﻿using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class VisibilityRepo : RepoBase<Visibility>
    {
        public VisibilityRepo(DbContext context) : base(context)
        {

        }
    }
}