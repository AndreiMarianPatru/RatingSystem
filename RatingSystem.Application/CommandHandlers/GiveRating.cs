using MediatR;
using RatingSystem.Data;
using RatingSystem.Models;
using RatingSystem.PublishedLanguage.Commands;
using System.Linq;
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
            var conference = _dbContext.Ratings.FirstOrDefault(x => x.ConferenceId == request.ConferenceId);
            var db = _dbContext.Ratings.FirstOrDefault(x => x.ConferenceId == conference.ConferenceId);
            if (db == null)
            {
                db = new Rating
                {
                    ConferenceId = request.ConferenceId,
                    RatingValue = request.RatingValue
                };
                _dbContext.Ratings.Add(db);
                _dbContext.SaveChanges();
            }
            var ratings = _dbContext.Ratings.Select(x => x.RatingValue).ToArray();
            var result = (decimal)ratings.Average();
            var conferencedX = _dbContext.ConferenceXratings.FirstOrDefault(x => x.ConferenceId == request.ConferenceId);
            if (conferencedX == null)
            {
                ConferenceXrating cxr = new ConferenceXrating();
                cxr.ConferenceId = conference.ConferenceId;
                cxr.RatingValue = result;
                _dbContext.ConferenceXratings.Add(cxr);
            }
            else
            {
                conferencedX.RatingValue = result;

            }

            //_dbContext.ConferenceXratings.UpdateRange();
            _dbContext.SaveChanges();
            // TODO: implement logic
            return Unit.Value;
        }
    }
}