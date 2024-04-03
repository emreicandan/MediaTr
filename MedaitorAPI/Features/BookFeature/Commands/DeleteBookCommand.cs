using System;
using AutoMapper;
using MedaitorAPI.Repositories.Abstract;
using MediatR;

namespace MedaitorAPI.Features.BookFeature.Commands;

public class DeleteBookCommand:IRequest<bool>
{
	public int Id { get; set; }

	public DeleteBookCommand(int id)
	{
		Id = id;
	}

    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public DeleteBookCommandHandler(IBookRepository bookRepository , IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book =await _bookRepository.GetAsync(b => b.Id == request.Id);
            await _bookRepository.DeleteAsync(book);

            return true;
        }
    }
}

