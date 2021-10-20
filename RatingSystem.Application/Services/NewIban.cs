using RatingSystem.Data;

namespace RatingSystem.Application.Services
{
    public class NewIban
    {
        private readonly ConferenceDatabaseContext _dbContext;

        public NewIban(ConferenceDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
