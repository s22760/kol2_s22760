using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Models.DTOs
{
    public class AlbumFull
    {
        public int IdAlbum { get; set; }
        public String AlbumName { get; set; }
        public DateTime PublishDate { get; set; }
        public String MusicLabl { get; set; }
        public IEnumerable<TrackDTO> Tracks { get; set; }
    }
}
