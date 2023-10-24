using AutoMapper;
using IMS.Models;

namespace SampleMapper.Profiles;

public class LocationProfile : Profile
{
    public LocationProfile()
    {
        CreateMap<LocationDTO, Location>()
            .ForMember(
                dest => dest.LocationName,
                opt => opt.MapFrom(src => src.LocationName)
            )
            .ForMember(
                dest => dest.ParentLocation,
                opt => opt.MapFrom(src => src.ParentLocation)
            )
            .ForMember(
                dest => dest.Description,
                opt => opt.MapFrom(src => src.Description)
            )
            .ForMember(
                dest => dest.MaxCapacity,
                opt => opt.MapFrom(src => src.MaxCapacity)
            )
            .ForMember(
                dest => dest.CurrentOccupancy,
                opt => opt.MapFrom(src => src.CurrentOccupancy)
            );

        CreateMap<Location, LocationDTO>()
            .ForMember(
                dest => dest.LocationId,
                opt => opt.MapFrom(src => src.LocationId)
            )
            .ForMember(
                dest => dest.LocationName,
                opt => opt.MapFrom(src => src.LocationName)
            )
            .ForMember(
                dest => dest.ParentLocation,
                opt => opt.MapFrom(src => src.ParentLocation)
            )
            .ForMember(
                dest => dest.Description,
                opt => opt.MapFrom(src => src.Description)
            )
            .ForMember(
                dest => dest.MaxCapacity,
                opt => opt.MapFrom(src => src.MaxCapacity)
            )
            .ForMember(
                dest => dest.CurrentOccupancy,
                opt => opt.MapFrom(src => src.CurrentOccupancy)
            );
    }
}