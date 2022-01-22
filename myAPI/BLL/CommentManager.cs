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
    public class CommentManager : ManagerBase<Comment, CommentDTO>
    {
        public CommentManager(IRepo<Comment> repo) : base(repo, 5)
        {
            MapperConfiguration configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<Comment, CommentDTO>();
               
                x.CreateMap<CommentDTO, Comment>()
                .ForMember(y => y.UserId, y => y.MapFrom(source => source.User.UserId));

                x.CreateMap<CommentMedia, CommentMediaDTO>().ReverseMap();

                x.CreateMap<User, UserDTO>()
                .ForMember(y => y.UserInfo, y => y.Ignore());

                x.CreateMap<Visibility, VisibilityDTO>().ReverseMap();

                x.CreateMap<UserDTO, User>()
                .ForMember(y => y.UserInfo, y => y.Ignore())
                .ForMember(y => y.AvaId, y => y.MapFrom(source => source.Ava.Id));


                x.CreateMap<UserPhoto, UserPhotoDTO>();
              
               
                x.CreateMap<UserPhotoDTO, UserPhoto>()
                .ForMember(y => y.VisibilityId, y => y.MapFrom(source => source.Visibility.VisibilityId));

                x.CreateMap<Post, PostDTO>();
              
              
              

                x.CreateMap<PostDTO, Post>()
                .ForMember(y => y.VisibilityId, y => y.MapFrom(source => source.Visibility.VisibilityId));
                
            });
            mapper = new Mapper(configuration);
        }
    }
}
