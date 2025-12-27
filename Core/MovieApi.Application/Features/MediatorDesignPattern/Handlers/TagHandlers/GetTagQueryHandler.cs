using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;
using MovieApi.Application.Features.MediatorDesignPattern.Results.TagResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandlers;

public class GetTagQueryHandler : IRequestHandler<GetTagQuery, List<GetTagQueryResult>>
{
    private readonly MovieContext _context;
    public GetTagQueryHandler(MovieContext context)
    {
        _context = context;
    }
    public async Task<List<GetTagQueryResult>> Handle(GetTagQuery request, CancellationToken cancellationToken)
    {
        var values = await _context.Tags.ToListAsync(cancellationToken);

        return values.Select(c => new GetTagQueryResult
        {
            TagId = c.TagId,
            Title = c.Title ?? string.Empty
        }).ToList();
    }
}

