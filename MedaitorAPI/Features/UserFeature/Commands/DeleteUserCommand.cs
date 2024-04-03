using System;
using AutoMapper;
using MedaitorAPI.Repositories.Abstract;
using MediatR;

namespace MedaitorAPI.Features.UserFeature.Commands;

public class DeleteUserCommand:IRequest<bool>
{
	public int Id { get; set; }
	
	public DeleteUserCommand(int id)
	{
		Id = id;
	}

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IUserRepository userRepository , IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(u => u.Id == request.Id);
            await _userRepository.DeleteAsync(user);
            return true;
        }
    }
}

