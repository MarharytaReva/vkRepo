using DAL.Context;
using DAL.Repos;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LikedEntityManager : ManagerBase<LikedEntity, LikedEntityDTO>
    {
        public LikedEntityManager(IRepo<LikedEntity> repo) : base(repo)
        {

        }
    }
}
