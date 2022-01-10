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
    public class GenderManager : ManagerBase<Gender, GenderDTO>
    {
        public GenderManager(IRepo<Gender> repo) : base(repo)
        {
            MapperConfiguration configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<Gender, GenderDTO>().ReverseMap();
            });
            mapper = new Mapper(configuration);
        }
    }
}
