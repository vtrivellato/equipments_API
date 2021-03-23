using api.DTOs.Alarme;
using api.Models;
using AutoMapper;

namespace api.Profiles
{
    public class AlarmesProfile : Profile
    {
        public AlarmesProfile()
        {
            CreateMap<Alarme, AlarmeReadDTO>();
            CreateMap<AlarmeCreateDTO, Alarme>();
            CreateMap<AlarmeUpdateDTO, Alarme>();
            CreateMap<Alarme, AlarmeUpdateDTO>();
        }
    }
}