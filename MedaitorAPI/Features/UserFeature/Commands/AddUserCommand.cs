using System;
using AutoMapper;
using MedaitorAPI.Features.UserFeature.DTOs;
using MedaitorAPI.Entities;
using MedaitorAPI.Repositories.Abstract;
using MediatR;

namespace MedaitorAPI.Features.UserFeature.Commands;

public class AddUserCommand : IRequest<AddedUserDto>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }

    public class Handler : IRequestHandler<AddUserCommand, AddedUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public Handler(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<AddedUserDto> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            var addedUser = await _userRepository.AddAsync(user);

            return _mapper.Map<AddedUserDto>(addedUser);
        }
    }
}

