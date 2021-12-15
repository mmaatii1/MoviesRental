using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MoviesRental.Models;

namespace MoviesRental.Dtos
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();

            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>();

            CreateMap<MemberShip, MemberShipDto>();
            CreateMap<MemberShipDto, MemberShip>();

            CreateMap<Genre, GenreDto>();
            CreateMap<GenreDto, Genre>();

            CreateMap<Rental, NewRentalDto>();
            CreateMap<NewRentalDto, Rental>();
        }
    }
}
