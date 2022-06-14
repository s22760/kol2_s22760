using kol2.Models;
using kol2.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kol2.Services
{
    public interface IXService
    {
        public Task<bool> DoesAlbumExist(int idAlbum);
        public Task<bool> AreTracksInAlbums(int idMusician);
        public Task<AlbumFull> GetAlbumInfo(int idAlbum);
        public Task DeleteMusician(int id);
        public Task SaveDatabase();
    }
}
