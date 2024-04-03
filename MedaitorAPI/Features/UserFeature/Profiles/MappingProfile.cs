using System;
using AutoMapper;
using MedaitorAPI.Features.UserFeature.Commands;
using MedaitorAPI.Features.UserFeature.DTOs;
using MedaitorAPI.Entities;

namespace MedaitorAPI.Profiles;

public class MappingProfile:Profile
{
	public MappingProfile()
	{
		CreateMap<User, AddedUserDto>();
		CreateMap<User, UpdatedUserDto>();
		CreateMap<User, UserListDto>();
		CreateMap<User, UserGetByIdDto>();

        CreateMap<AddUserCommand, User>();
		CreateMap<UpdateUserCommand, User>();

	}
}

