using kol2.Models;
using kol2.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kol2.Services
{
    public interface IXService
    {
        public Task<bool> DoesAlbumExist(int id);
        public Task<AlbumFull> GetAlbumInfo(int id);
        //public Task DeleteMusician(Musician musician);
        public Task SaveDatabase();
    }
}
