using kol2.Models;
using kol2.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Services
{
    public class XService : IXService
    {
        private readonly KolDbContext _context;
        public XService(KolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DoesAlbumExist(int id)
        {
            var result = await _context.Albums.Where(e => e.IdAlbum == id).FirstOrDefaultAsync();
            if (result is null)
                return false;
            else
                return true;
        }

        public async Task<AlbumFull> GetAlbumInfo(int id)
        {
            var Album = await _context.Albums.Select(e => e).Where(e => e.IdAlbum == id).FirstOrDefaultAsync();
            var Tracks = await _context.Tracks.Where(e => e.IdMusicAlbum == Album.IdAlbum).OrderBy(e => e.Duration).Select(e => new TrackDTO
            {
                IdTrack = e.IdTrack,
                TrackName = e.TrackName,
                Duration = e.Duration
            }).ToListAsync();
            var FullAlbum = new AlbumFull
            {
                IdAlbum = Album.IdAlbum,
                AlbumName = Album.AlbumName,
                PublishDate = Album.PublishDate,
                MusicLabl = await _context.MusicLabels.Where(e => e.IdMusicLabel == Album.IdMusicLabel).Select(e => e.Name).FirstOrDefaultAsync(),
                Tracks = Tracks
            };
            return FullAlbum;
        }

        /*public Task DeleteMusician(Musician musician)
        {
            
        }*/

        public async Task SaveDatabase()
        {
            await _context.SaveChangesAsync();
        }
    }
}
