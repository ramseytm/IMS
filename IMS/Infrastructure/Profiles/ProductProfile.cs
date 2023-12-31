﻿using AutoMapper;
using IMS.Models;

namespace SampleMapper.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductDto, Product>();

        CreateMap<Product, ProductDto>();
    }
}