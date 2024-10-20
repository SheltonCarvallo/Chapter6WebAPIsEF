using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Domain.Models
{
    public class MovieActors
    {
        public Guid MovieId { get; set; }
        public MovieModel Movie { get; set; } = null!;
        public Guid ActorId { get; set; }
        public ActorModel Actor { get; set; } = null!;
        public DateTime UpdateTime { get; set; }
    }
}
