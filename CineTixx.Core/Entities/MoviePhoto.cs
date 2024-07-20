using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CineTixx.Core.Entities
{
    public class MoviePhoto
    {
        public Guid Id { get; set; }
        public byte[] PhotoData { get; set; }
        public string ContentType { get; set; }
        public Guid MovieId { get; set; }
        [JsonIgnore]
        public Movie Movie { get; set; }
    }
}
