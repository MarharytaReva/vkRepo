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
    public class SubscribitionManager : ManagerBase<Subscribition, SubscribitionDTO>
    {
        public SubscribitionManager(IRepo<Subscribition> repo) : base(repo)
        {

        }
    }
}
