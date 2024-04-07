using AutoAssistant_Challenge.Dto;
using AutoAssistant_Challenge.Models;
using AutoMapper;

namespace AutoAssistant_Challenge.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<PessoaModel, PessoaDto>();
        }
    }
}
