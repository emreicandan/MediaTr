using System;
using AutoMapper;
using MedaitorAPI.Features.UserFeature.DTOs;
using MedaitorAPI.Repositories.Abstract;
using MediatR;

namespace MedaitorAPI.Features.UserFeature.Queries;

public class UserGetByIdQuery:IRequest<UserGetByIdDto>
{
    public int Id { get; set; }

    public UserGetByIdQuery(int id)
    {
        Id = id;
    }

    public class UserGetByIdQueryHandler : IRequestHandler<UserGetByIdQuery, UserGetByIdDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserGetByIdQueryHandler(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserGetByIdDto> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(u => u.Id == request.Id);
            return _mapper.Map<UserGetByIdDto>(user);
        }
    }
}

