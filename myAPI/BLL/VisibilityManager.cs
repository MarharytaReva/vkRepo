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
    public class VisibilityManager : ManagerBase<Visibility, VisibilityDTO>
    {
        public VisibilityManager(IRepo<Visibility> repo) : base(repo)
        {
            MapperConfiguration configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<Visibility, VisibilityDTO>().ReverseMap();
            });
            mapper = new Mapper(configuration);
        }
    }
}
