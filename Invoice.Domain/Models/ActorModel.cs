using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Invoice.Domain.Models
{
    public class ActorModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<MovieModel> Movies { get; set; } = new List<MovieModel>();
        [JsonIgnore]
        public List<MovieActors> MovieActors { get; set; } = new List<MovieActors>();

    }
}
