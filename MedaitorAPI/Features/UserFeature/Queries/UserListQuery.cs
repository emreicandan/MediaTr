using System;
using AutoMapper;
using MedaitorAPI.Features.UserFeature.DTOs;
using MedaitorAPI.Repositories.Abstract;
using MediatR;

namespace MedaitorAPI.Features.UserFeature.Queries;

public class UserListQuery:IRequest<IList<UserListDto>>
{

    public class UserListQueryHandler : IRequestHandler<UserListQuery,IList<UserListDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserListQueryHandler(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IList<UserListDto>> Handle(UserListQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(u => _mapper.Map<UserListDto>(u)).ToList();

        }
    }

}

