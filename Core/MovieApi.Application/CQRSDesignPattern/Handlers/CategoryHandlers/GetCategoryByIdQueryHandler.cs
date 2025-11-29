using MovieApi.Application.CQRSDesignPattern.Queries.CategoryQueries;
using MovieApi.Application.CQRSDesignPattern.Results.CategoryResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly  MovieContext _context;

        public GetCategoryByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery  query)
        {
            var value = await _context.Categories.FindAsync(query.CategoryId);

            return new GetCategoryByIdQueryResult            {
                Id = value.Id,
                Name=value.Name
            };
        }
    }
}
