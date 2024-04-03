using System;
using AutoMapper;
using MedaitorAPI.Features.UserFeature.DTOs;
using MedaitorAPI.Repositories.Abstract;
using MediatR;

namespace MedaitorAPI.Features.UserFeature.Commands;

public class UpdateUserCommand:IRequest<UpdatedUserDto>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public class Handler : IRequestHandler<UpdateUserCommand, UpdatedUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public Handler(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.Get(u => u.Id == request.Id);
            var updatedUser = await _userRepository.UpdateAsync(user);

            return new UpdatedUserDto()
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName
            };
        }
    }
}

