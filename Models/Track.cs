using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Models
{
    public class Track
    {
        public int IdTrack { get; set; }
        public String TrackName { get; set; }
        public float Duration { get; set; }
        public int? IdMusicAlbum { get; set; }
        public IEnumerable<MusicianTrack> Musicians { get; set; }
        public virtual Album Album { get; set; }
    }
}
