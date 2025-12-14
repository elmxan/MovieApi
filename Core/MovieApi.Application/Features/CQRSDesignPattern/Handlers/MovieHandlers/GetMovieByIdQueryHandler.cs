using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieByIdQueryHandler
    {
        private readonly MovieContext _context;

        public GetMovieByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetMovieByIdQueryResult> Handle(GetMovieByIdQuery query)
        {
            var value=  await _context.Movies.FindAsync(query.Id);

            return new GetMovieByIdQueryResult
            {
                Id = query.Id,
                CoverImageUrl = value.CoverImageUrl,
                Status = value.Status,
                Description = value.Description,
                Duration = value.Duration,
                CreatedYear = value.CreatedYear,
                ReleaseDate = value.ReleaseDate,
                Name = value.Name,
                Rating = value.Rating

            };
        }
    }
}
