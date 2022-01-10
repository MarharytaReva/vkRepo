using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Context;
using DAL.Repos;
using DTO;

namespace BLL
{
    public class CommunityManager : ManagerBase<Community, CommunityDTO>
    {
        public CommunityManager(IRepo<Community> repo) : base(repo, 10)
        {
            MapperConfiguration configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<Community, CommunityDTO>();
                x.CreateMap<CommunityDTO, Community>()
                .ForMember(y => y.AvaId, y => y.MapFrom(source => source.Ava.Id));
            });
            mapper = new Mapper(configuration);
        }
    }
}
