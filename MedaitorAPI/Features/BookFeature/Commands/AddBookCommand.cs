using System;
using AutoMapper;
using MedaitorAPI.Entities;
using MedaitorAPI.Features.BookFeature.DTOs;
using MedaitorAPI.Repositories.Abstract;
using MediatR;

namespace MedaitorAPI.Features.BookFeature.Commands;

public class AddBookCommand : IRequest<AddedBookDto>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public string Author { get; set; }

    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, AddedBookDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public AddBookCommandHandler(IBookRepository bookRepository , IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<AddedBookDto> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);
            var addedBook = await _bookRepository.AddAsync(book);

            return _mapper.Map<AddedBookDto>(addedBook);
        }
    }
}

