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
    public class UserDocumentManager : ManagerBase<UserDocument, UserDocumentDTO>
    {
        public UserDocumentManager(IRepo<UserDocument> repo) : base(repo, 20)
        {
            MapperConfiguration configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<UserDocument, UserDocumentDTO>();
                x.CreateMap<UserDocumentDTO, UserDocument>()
                .ForMember(y => y.VisibilityId, y => y.MapFrom(source => source.Visibility.VisibilityId));
            });
            mapper = new Mapper(configuration);
        }
    }
}
