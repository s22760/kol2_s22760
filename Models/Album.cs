using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Models
{
    public class Album
    {
        public int IdAlbum { get; set; }
        public String AlbumName { get; set; } 
        public DateTime PublishDate { get; set; }
        public int IdMusicLabel { get; set; }
        public virtual MusicLabel MusicLabel { get; set; }
        public IEnumerable<Track> Tracks { get; set; }
    }
}
