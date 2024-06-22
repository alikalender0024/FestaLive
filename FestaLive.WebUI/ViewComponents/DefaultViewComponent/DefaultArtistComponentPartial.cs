using FestaLive.Business.Abstract;
using FestaLive.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestaLive.WebUI.ViewComponents.DefaultViewComponent
{
    public class DefaultArtistComponentPartial : ViewComponent
    {
        private readonly IArtistService _artistService;
        private readonly IEventService _eventService;

        public DefaultArtistComponentPartial(IArtistService artistService, IEventService eventService)
        {
            _artistService = artistService;
            _eventService = eventService;
        }

        public IViewComponentResult Invoke()
        {
            var artists = _artistService.GetAll().Data;
            var events = _eventService.GetAll().Data;

            var artistEventViewModels = new List<ArtistEventViewModel>();

            foreach (var artist in artists)
            {
                var artistEvent = events.FirstOrDefault(e => e.Artist == artist.Name);
                if (artistEvent != null)
                {
                    artistEventViewModels.Add(new ArtistEventViewModel
                    {
                        ArtistId = artist.Id,
                        ArtistName = artist.Name,
                        MusicGenre = artist.MusicGenre,
                        ImageUrl = artist.ImageUrl,
                        YoutubeChannel = artist.YoutubeChannel,
                        EventTitle = artistEvent.Title,
                        EventTime = artistEvent.Time,
                        EventDescription = artistEvent.Title
                    });
                }
            }

            return View(artistEventViewModels);
        }
    }
}