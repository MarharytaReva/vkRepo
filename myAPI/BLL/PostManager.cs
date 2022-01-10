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
    public class PostManager : ManagerBase<Post, PostDTO>
    {
        public PostManager(IRepo<Post> repo) : base(repo, 10)
        {
            MapperConfiguration configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<Visibility, VisibilityDTO>().ReverseMap();

                x.CreateMap<Post, PostDTO>();
               
                x.CreateMap<PostDTO, Post>()
                .ForMember(y => y.UserId, y => y.MapFrom(source => source.User.UserId))
                .ForMember(y => y.VisibilityId, y => y.MapFrom(source => source.Visibility.VisibilityId));

                x.CreateMap<User, UserDTO>()
                .ForMember(y => y.UserInfo, y => y.Ignore());
               

                x.CreateMap<UserDTO, User>()
                .ForMember(y => y.UserInfo, y => y.Ignore());


                x.CreateMap<Comment, CommentDTO>();

                x.CreateMap<CommentDTO, Comment>()
                .ForMember(y => y.UserId, y => y.MapFrom(source => source.User.UserId));


             


                x.CreateMap<UserAudio, UserAudioDTO>();
                x.CreateMap<UserAudioDTO, UserAudio>()
                .ForMember(y => y.VisibilityId, y => y.MapFrom(source => source.Visibility.VisibilityId));

                x.CreateMap<UserDocument, UserDocumentDTO>();
                x.CreateMap<UserDocumentDTO, UserDocument>()
                .ForMember(y => y.VisibilityId, y => y.MapFrom(source => source.Visibility.VisibilityId));
            });
            mapper = new Mapper(configuration);
        }
    }
}
