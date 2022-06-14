using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Models
{
    public class Musician
    {
        public int IdMusician { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String? Nickname { get; set; }
        public IEnumerable<MusicianTrack> Tracks { get; set; }
    }
}
