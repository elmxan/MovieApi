using MovieApi.Application.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Application.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly MovieContext _context;
        public RemoveCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }
         public async void Handler(RemoveCategoryCommand command)
        {
              var value = _context.Movies.Find(command.CategoryId);
            _context.Movies.Remove(value);
            await _context.SaveChangesAsync();  

        }


    }
}
