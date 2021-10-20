using MediatR;
using RatingSystem.Data;
using RatingSystem.Models;
using RatingSystem.PublishedLanguage.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace RatingSystem.Application.WriteOperations
{
    public class GiveRating : IRequestHandler<MakeNewRating>
    {
        private readonly IMediator _mediator;
       
        private readonly ConferenceDatabaseContext _dbContext;
       
        
        public GiveRating(IMediator mediator, ConferenceDatabaseContext dbContext)
        {
            _mediator = mediator;
          
            _dbContext = dbContext;
           
        }

        public async Task<Unit> Handle(MakeNewRating request, CancellationToken cancellationToken)
        {
            Rating rating = new Rating();
            rating.ConferenceId = 10;
            rating.RatingValue = 4;
            _dbContext.Ratings.Add(rating);
            _dbContext.SaveChanges();
            // TODO: implement logic
            return Unit.Value;
        }        
    }
}