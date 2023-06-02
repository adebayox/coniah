using System;
using AutoMapper;
using Invoice.Dtos;
using Invoice.Models;

namespace Invoice
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
            CreateMap<Debt, GetDebtorDto>();

            CreateMap<AddDebtorDto, Debt>();

            CreateMap<UpdateDebtDto, Debt>();
        }
	}
}

