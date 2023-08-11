using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace MiniStore.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterRecord, Account>()
                .ForMember(des => des.CreateDate, op => op.MapFrom(o => DateTime.Now));
        }
    }
}
