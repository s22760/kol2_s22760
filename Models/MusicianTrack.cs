using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Models
{
    public class MusicianTrack
    {
        public int IdMusician { get; set;  }
        public int IdTrack { get; set;  }
        public virtual Musician Musician { get; set; }
        public virtual Track Track { get; set; }
    }
}
