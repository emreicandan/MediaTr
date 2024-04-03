using System;
using AutoMapper;
using MedaitorAPI.Entities;
using MedaitorAPI.Features.BookFeature.Commands;
using MedaitorAPI.Features.BookFeature.DTOs;

namespace MedaitorAPI.Features.BookFeature.Profiles;

public class MappingProfile:Profile
{
	public MappingProfile()
	{
		CreateMap<Book,AddedBookDto> ();
		CreateMap<Book, UpdatedBookDto>();
		CreateMap<Book, ListBookDto>();
		CreateMap<Book, GetByIdBookDto>();

		CreateMap<AddBookCommand, Book>();
		CreateMap<UpdateBookCommand, Book>();
	}
}

