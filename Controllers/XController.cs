using kol2.Models.DTOs;
using kol2.Models;
using kol2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Transactions;
using System;

namespace kol2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XController : ControllerBase
    {
        private readonly IXService _service;
        public XController(IXService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlbum(int id)
        {
            var doesExist = await _service.DoesAlbumExist(id);
            if (doesExist)
            {
                var Album = await _service.GetAlbumInfo(id);
                return Ok(Album);
            }
            else
                return NotFound("Album with given id was not found");
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteMusician(int id)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    await _service.DeleteMusician(id);
                    scope.Complete();
                }
                catch (Exception)
                {
                    return Problem("Unexpected server error");
                }
            }
            await _service.SaveDatabase();
            return Ok("Musician deleted");
        }
    }
}
