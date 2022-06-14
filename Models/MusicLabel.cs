using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Models
{
    public class MusicLabel
    {
        public int IdMusicLabel { get; set; }
        public String Name { get; set; }
        public IEnumerable<Album> Albums { get; set; }
    }
}
