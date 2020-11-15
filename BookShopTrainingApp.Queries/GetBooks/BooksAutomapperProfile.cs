using AutoMapper;
using BookShopTrainingApp.Domain;
using BookShopTrainingApp.Queries.GetBooks;

namespace BookShopTrainingApp.Queries.GetBooks
{
    public class BooksAutomapperProfile : Profile
    {
        public BooksAutomapperProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.Authors))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.Amount.ToString()+" "+src.Price.Currency.ToString()))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<BookAuthor, AuthorDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Author.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Author.Surname));
        }
    }
}