using AutoMapper;
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
    public class FriendshipManager : ManagerBase<Friendship, FriendshipDTO>
    {
        public FriendshipManager(IRepo<Friendship> repo) : base(repo, 15)
        {
            MapperConfiguration config = new MapperConfiguration(x => x.CreateMap<Friendship, FriendshipDTO>().ReverseMap());
            mapper = new Mapper(config);
        }
    }
}
