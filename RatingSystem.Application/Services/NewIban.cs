using RatingSystem.Data;
using RatingSystem.Models;
using System.Collections.Generic;
using System.Linq;

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
