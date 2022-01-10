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
    public class UserManager : ManagerBase<User, UserDTO>
    {
        public UserManager(IRepo<User> repo) : base (repo, 15)
        {
            MapperConfiguration configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<UserInfo, UserInfoDTO>();

                x.CreateMap<UserInfoDTO, UserInfo>()
                .ForMember(y => y.GenderId, y => y.MapFrom(source => source.Gender.GenderId));


                x.CreateMap<UserDocument, UserDocumentDTO>();
                x.CreateMap<UserDocumentDTO, UserDocument>()
                .ForMember(y => y.VisibilityId, y => y.MapFrom(source => source.Visibility.VisibilityId));

                x.CreateMap<UserAudio, UserAudioDTO>();
                x.CreateMap<UserAudioDTO, UserAudio>()
                .ForMember(y => y.VisibilityId, y => y.MapFrom(source => source.Visibility.VisibilityId));

                x.CreateMap<UserVideo, UserVideoDTO>();
               
                x.CreateMap<UserVideoDTO, UserVideo>()
                .ForMember(y => y.VisibilityId, y => y.MapFrom(source => source.Visibility.VisibilityId));

                x.CreateMap<UserPhoto, UserPhotoDTO>();
                x.CreateMap<UserPhotoDTO, UserPhoto>()
                .ForMember(y => y.VisibilityId, y => y.MapFrom(source => source.Visibility.VisibilityId));

                x.CreateMap<User, UserDTO>();
                x.CreateMap<UserDTO, User>()
                .ForMember(y => y.AvaId, y => y.MapFrom(source => source.Ava.Id));

                x.CreateMap<Post, PostDTO>();
                x.CreateMap<PostDTO, Post>()
                .ForMember(y => y.UserId, y => y.MapFrom(source => source.User.UserId))
                .ForMember(y => y.VisibilityId, y => y.MapFrom(source => source.Visibility.VisibilityId));

               

                x.CreateMap<Gender, GenderDTO>().ReverseMap();

                x.CreateMap<Visibility, VisibilityDTO>().ReverseMap();
            });
            mapper = new Mapper(configuration);
        }
        public new async Task<UserDTO> GetItemAsync(int id, int idSecond = 0)
        {
            return await Task.Run(() =>
            {
                var userEntity = (repo as UserRepo).GetItem(id);
                if (userEntity is null)
                    return null;
                var result = mapper.Map<User, UserDTO>(userEntity);
                return result;
            });
        }
    }
}
