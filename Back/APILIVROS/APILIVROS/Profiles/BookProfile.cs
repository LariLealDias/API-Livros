using AutoMapper;
using APILIVROS.Data.Dtos;
using APILIVROS.Models;

namespace APILIVROS.Profiles;

public class BookProfile : Profile
{
	public BookProfile()
	{
        CreateMap<CreateBookDto, Book>();
        CreateMap<UpdateBookDto, Book>();
        CreateMap<Book, UpdateBookDto>();
        CreateMap<Book, ReadBookDto>();
    }
}
