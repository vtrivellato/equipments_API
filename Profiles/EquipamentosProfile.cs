using api.DTOs.Equipamento;
using api.Models;
using AutoMapper;

namespace api.Profiles
{
    public class EquipamentosProfile : Profile
    {
        public EquipamentosProfile()
        {
            CreateMap<Equipamento, EquipamentoReadDTO>();
            CreateMap<EquipamentoCreateDTO, Equipamento>();
            CreateMap<EquipamentoUpdateDTO, Equipamento>();
            CreateMap<Equipamento, EquipamentoUpdateDTO>();
        }
    }
}