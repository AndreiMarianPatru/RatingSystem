using FluentValidation;
using MediatR;
using RatingSystem.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RatingSystem.Application.Queries
{
    public class GetRatingQuery
    {
        public class Validator : AbstractValidator<Query>
        {
            public Validator(ConferenceDatabaseContext _dbContext)
            {
                //RuleFor(q => q).Must(query =>
                //{
                //    var person = query.PersonId.HasValue ?
                //    _dbContext.Persons.FirstOrDefault(x => x.Id == query.PersonId) :
                //    _dbContext.Persons.FirstOrDefault(x => x.Cnp == query.Cnp);

                //    return person != null;
                //}).WithMessage("Customer not found");
            }
        }


        public class Query : IRequest<Model>
        {
            public int ConferenceId { get; set; }
            
        }

        public class QueryHandler : IRequestHandler<Query, Model>
        {
            private readonly ConferenceDatabaseContext _dbContext;

            public QueryHandler(ConferenceDatabaseContext dbContext)
            {
                _dbContext = dbContext;
            }

          

            public Task<Model> Handle(Query request, CancellationToken cancellationToken)
            {
                var conference = _dbContext.Ratings.FirstOrDefault(x => x.ConferenceId == request.ConferenceId);
                var db = _dbContext.Ratings.Where(x => x.ConferenceId == conference.ConferenceId);
                var result = db.Select(x => x.RatingValue).ToArray();
                
                Model averagedRating = new Model();
                averagedRating.ConferenceId = conference.ConferenceId;
                averagedRating.Rating = (decimal)result.Average();

                return Task.FromResult(averagedRating);
               
            }

           
        }

        public class Model
        {
            public int ConferenceId { get; set; }
            public decimal Rating { get; set; }
        }
    }
}
