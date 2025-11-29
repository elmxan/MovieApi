using MovieApi.Application.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class UpdateMovieCommandHandler
    {
        private readonly MovieContext _context;
        public UpdateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }
         public async Task Handle(UpdateMovieCommand command)
        {
          var value = _context.Movies.Find(command.Id);
          value.Name = command.Name;
          value.CoverImageUrl = command.CoverImageUrl;
          value.Rating = command.Rating;
          value.Description = command.Description;
          value.Duration = command.Duration;
          value.ReleaseDate = command.ReleaseDate;
          value.CreatedYear = command.CreatedYear;
          value.Status = command.Status;
            await _context.SaveChangesAsync();

        }
    }
}
