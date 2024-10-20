using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Domain.Models
{
    public class MovieModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int ReleaseYear { get; set; }
        public List<ActorModel> Actors { get; set; } = new List<ActorModel>();
        public List<MovieActors> MovieActors { get; set; } = new List<MovieActors>();
    }
}
