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
    public class UserInfoManager : ManagerBase<UserInfo, UserInfoDTO>
    {
        public UserInfoManager(IRepo<UserInfo> repo) : base(repo)
        {
            MapperConfiguration configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<UserInfo, UserInfoDTO>();
               
                x.CreateMap<UserInfoDTO, UserInfo>()
                .ForMember(y => y.GenderId, y => y.MapFrom(source => source.Gender.GenderId));

                x.CreateMap<Gender, GenderDTO>().ReverseMap();
            });
            mapper = new Mapper(configuration);
        }
        public new async Task<UserInfoDTO> GetItemAsync(int id, int idSecond = 0)
        {
            return await Task.Run(() =>
            {
                var infoEntity = (repo as UserInfoRepo).GetItem(id);
                if (infoEntity is null)
                    return null;
                return mapper.Map<UserInfo, UserInfoDTO>(infoEntity);
            });
        }
    }
}
