using System;
using AutoMapper;
using MedaitorAPI.Features.BookFeature.DTOs;
using MedaitorAPI.Repositories.Abstract;
using MediatR;

namespace MedaitorAPI.Features.BookFeature.Queries;

public class BookListQuery:IRequest<IList<ListBookDto>>
{
    public class BookListQueryHandler : IRequestHandler<BookListQuery, IList<ListBookDto>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookListQueryHandler(IBookRepository bookRepository , IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IList<ListBookDto>> Handle(BookListQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetAllAsync();
            return book.Select(u => _mapper.Map<ListBookDto>(u)).ToList();
        }
    }
}

