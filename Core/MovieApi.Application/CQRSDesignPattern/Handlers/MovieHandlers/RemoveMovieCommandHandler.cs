using MovieApi.Application.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class RemoveMovieCommandHandler
    {
        private readonly MovieContext _context;
        public RemoveMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }
         public async void Handler(RemoveMovieCommand command)
        {
              var value = _context.Movies.Find(command.MovieId);
            _context.Movies.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}
