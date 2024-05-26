using AutoMapper;
using CineTixx.Core.DTOs;
using CineTixx.Core.DTOs.Account;
using CineTixx.Core.Entities;

namespace CineTixx.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CinemaRoom, CinemaRoomDto>().ReverseMap();
            CreateMap<Seat, SeatDto>().ReverseMap();
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Screening, ScreeningDto>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
            CreateMap<Staff, StaffDto>().ReverseMap();
            CreateMap<Position, PositionDto>().ReverseMap();

        }
    }
}
