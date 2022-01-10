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
    class AnswerManager : ManagerBase<Answer,AnswerDTO>
    {
        public AnswerManager(IRepo<Answer> repo) : base(repo, 50)
        {
            MapperConfiguration configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<Answer, AnswerDTO>();


                x.CreateMap<AnswerDTO, Answer>()
                .ForMember(y => y.Id, y => y.MapFrom(source => source.Comment.CommentId))
                .ForMember(y => y.FromUserId, y => y.MapFrom(source => source.FromUser.UserId))
                .ForMember(y => y.ToUserId, y => y.MapFrom(source => source.ToUser == null ? null : (int?)source.ToUser.UserId));
            });
            mapper = new Mapper(configuration);
        }
    }
}
