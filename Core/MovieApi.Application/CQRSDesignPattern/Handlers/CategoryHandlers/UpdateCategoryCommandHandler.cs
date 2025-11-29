using MovieApi.Application.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly MovieContext _context;
        public UpdateCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }
         public async void Handler(UpdateCategoryCommand command)
        {
            var value = _context.Categories.Find(command.CategoryId);
            value.Name = command.CategoryName;
            await _context.SaveChangesAsync();
        }

    }
}
