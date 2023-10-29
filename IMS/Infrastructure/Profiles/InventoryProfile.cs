using AutoMapper;
using IMS.Models;

namespace SampleMapper.Profiles;

public class InventoryProfile : Profile
{
    public InventoryProfile()
    {
        CreateMap<InventoryDto, Inventory>();

        CreateMap<Inventory, InventoryDto>();
    }
}