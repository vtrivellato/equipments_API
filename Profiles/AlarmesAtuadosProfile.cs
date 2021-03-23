using api.DTOs.AlarmeAtuado;
using api.Models;
using AutoMapper;

namespace api.Profiles
{
    public class AlarmesAtuadosProfile : Profile
    {
        public AlarmesAtuadosProfile()
        {
            CreateMap<AlarmeAtuado, AlarmeAtuadoReadDTO>();
            CreateMap<AlarmeAtuadoCreateDTO, AlarmeAtuado>();
            CreateMap<AlarmeAtuadoUpdateDTO, AlarmeAtuado>();
            CreateMap<AlarmeAtuado, AlarmeAtuadoUpdateDTO>();
        }
    }
}