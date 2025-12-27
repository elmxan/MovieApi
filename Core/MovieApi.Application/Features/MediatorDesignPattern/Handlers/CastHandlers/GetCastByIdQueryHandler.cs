using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers;

    public class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, GetCastByIdQueryResult>
    {
        private readonly MovieContext _context;
        public GetCastByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.Casts.FindAsync(request.CastId);
            if (value == null)
                throw new InvalidOperationException($"Cast with ID {request.CastId} not found.");

            return new GetCastByIdQueryResult
            {
                CastId = value.CastId,
                Title = value.Title,
                Name = value.Name,
                Surname = value.Surname,
                ImageUrl = value.ImageUrl,
                OverView = value.OverView,
                Biography = value.Biography
            };
        }
    }

