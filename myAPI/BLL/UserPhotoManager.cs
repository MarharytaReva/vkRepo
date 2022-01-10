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
    public class UserPhotoManager : ManagerBase<UserPhoto, UserPhotoDTO>
    {
        public UserPhotoManager(IRepo<UserPhoto> repo) : base(repo, 10)
        {
            MapperConfiguration configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<UserPhoto, UserPhotoDTO>();
               
                x.CreateMap<UserPhotoDTO, UserPhoto>()
                .ForMember(y => y.VisibilityId, y => y.MapFrom(source => source.Visibility.VisibilityId));
            });
            mapper = new Mapper(configuration);
        }
    }
}
