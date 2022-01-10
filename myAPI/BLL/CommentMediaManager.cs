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
    public class CommentMediaManager : ManagerBase<CommentMedia, CommentMediaDTO>
    {
        public CommentMediaManager(IRepo<CommentMedia> repo) : base(repo)
        {
            MapperConfiguration configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<CommentMedia, CommentMediaDTO>().ReverseMap();
            });
            mapper = new Mapper(configuration);
        }
    }
}
