using AutoMapper;
using CineTixx.Core.DTOs;
using CineTixx.Core.Entities;

namespace CineTixx.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CinemaRoom, CinemaRoomDto>().ReverseMap();
            CreateMap<Booking, BookingDto>().ReverseMap();
        }
    }
}
