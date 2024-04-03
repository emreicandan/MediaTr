using System;
using AutoMapper;
using MedaitorAPI.Features.BookFeature.DTOs;
using MedaitorAPI.Repositories.Abstract;
using MediatR;

namespace MedaitorAPI.Features.BookFeature.Queries;

public class BookGetByIdQuery:IRequest<GetByIdBookDto>
{
	public int Id { get; set; }

	public BookGetByIdQuery(int id)
	{
		Id = id;
	}

    public class BookGetByIdQueryHandler : IRequestHandler<BookGetByIdQuery, GetByIdBookDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookGetByIdQueryHandler(IBookRepository  bookRepository,IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdBookDto> Handle(BookGetByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetAsync(b => b.Id == request.Id);

            return _mapper.Map<GetByIdBookDto>(book); 
        }
    }
}

