using AutoMapper;
using IMS.DTO;
using IMS.Models;

namespace SampleMapper.Profiles;

public class ManufacturerProfile : Profile
{
    public ManufacturerProfile()
    {
        CreateMap<ManufacturerDto, Manufacturer>();

        CreateMap<Manufacturer, ManufacturerDto>();
    }
}