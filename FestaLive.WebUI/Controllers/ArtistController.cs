using FestaLive.Business.Abstract;
using FestaLive.Core.Utilities.Results;
using FestaLive.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace FestaLive.WebUI.Controllers
{
    public class ArtistController(IArtistService artistService) : Controller
    {
        private readonly IArtistService _artistService = artistService;

        public IActionResult ArtistList()
        {
            var result = _artistService.GetAll().Data;
            return View(result);
        }
        [HttpGet]
        public IActionResult CreateArtist()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateArtist(Artist artist)
        {
            _artistService.Add(artist);
            return RedirectToAction("ArtistList");
        }
        public IActionResult DeleteArtist(int id)
        {
            _artistService.Delete(id);
            return RedirectToAction("ArtistList");
        }
        [HttpGet]
        public IActionResult UpdateArtist(int id)
        {
            var entity = _artistService.GetById(id).Data;
            return View(entity);
        }

        [HttpPost]
        public IActionResult UpdateArtist(Artist artist)
        {
            _artistService.Update(artist);
            return RedirectToAction("ArtistList");
        }

        [HttpGet]
        public IActionResult FilterArtists(string? name, DateTime? birthdate, string? musicGenre, string? youtubeChannel)
        {
            return RedirectToAction("Index", new { name, birthdate, musicGenre, youtubeChannel });
        }

        [HttpGet]
        public IActionResult FilterList(string name, DateTime? birthdate, string musicGenre, string youtubeChannel)
        {
            var filteredArtists = _artistService.FilterArtists(name, birthdate, musicGenre, youtubeChannel);
            return View(filteredArtists.Data);
        }

    }
}
