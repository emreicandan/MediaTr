using System;
using AutoMapper;
using MedaitorAPI.Entities;
using MedaitorAPI.Features.BookFeature.DTOs;
using MedaitorAPI.Repositories.Abstract;
using MediatR;

namespace MedaitorAPI.Features.BookFeature.Commands;

public class UpdateBookCommand:IRequest<UpdatedBookDto>
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Author { get; set; }

    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, UpdatedBookDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IBookRepository bookRepository , IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedBookDto> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);
            var updatedBook = await _bookRepository.UpdateAsync(book);

            return _mapper.Map<UpdatedBookDto>(updatedBook);
        }
    }
}

