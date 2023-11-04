using AutoMapper;
using IMS.Models;

namespace SampleMapper.Profiles;

public class LocationProfile : Profile
{
    public LocationProfile()
    {
        CreateMap<LocationDto, Location>();

        CreateMap<Location, LocationDto>();
    }
}