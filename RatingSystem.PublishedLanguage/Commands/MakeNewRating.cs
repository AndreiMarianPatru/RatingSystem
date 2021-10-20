using MediatR;

namespace RatingSystem.PublishedLanguage.Commands
{
    public class MakeNewRating : IRequest
    {
        public int RatingValue { get; set; }
        public int ConferenceId { get; set; }
       
    }
}
