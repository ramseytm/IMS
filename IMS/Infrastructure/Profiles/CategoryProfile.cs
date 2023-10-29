using AutoMapper;
using IMS.Models;

namespace SampleMapper.Profiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CategoryDto, Category>();

        CreateMap<Category, CategoryDto>();
    }
}