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
    public class UserAudioManager : ManagerBase<UserAudio, UserAudioDTO>
    {
        public UserAudioManager(IRepo<UserAudio> repo) : base(repo, 20)
        {
            MapperConfiguration configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<UserAudio, UserAudioDTO>();

                x.CreateMap<UserAudioDTO, UserAudio>()
                .ForMember(y => y.VisibilityId, y => y.MapFrom(source => source.Visibility.VisibilityId));
            });
            mapper = new Mapper(configuration);
        }
    }
}
