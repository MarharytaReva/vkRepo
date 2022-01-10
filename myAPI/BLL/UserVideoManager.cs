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
    public class UserVideoManager : ManagerBase<UserVideo, UserVideoDTO>
    {
        public UserVideoManager(IRepo<UserVideo> repo) : base(repo, 10)
        {
            MapperConfiguration configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<UserVideo, UserVideoDTO>();
               
                x.CreateMap<UserVideoDTO, UserVideo>()
                .ForMember(y => y.VisibilityId, y => y.MapFrom(source => source.Visibility.VisibilityId));
            });
            mapper = new Mapper(configuration);
        }
    }
}
