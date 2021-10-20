using System;
using System.Collections.Generic;

#nullable disable

namespace RatingSystem.Models
{
    public partial class Rating
    {
        public int Id { get; set; }
        public int ConferenceId { get; set; }
        
        public int RatingValue { get; set; }
    }
}
