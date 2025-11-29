using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.CQRSDesignPattern.Results.MovieResults
{
    public class GetMovieByIdQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CoverImageUrl { get; set; }

        public decimal Rating { get; set; }
        public decimal Description { get; set; }

        public int Duration { get; set; }

        public DateTime ReleaseDate { get; set; }
        public string CreatedYear { get; set; }
        public bool Status { get; set; }


    }
}
