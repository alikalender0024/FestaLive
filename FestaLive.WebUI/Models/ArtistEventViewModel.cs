namespace FestaLive.WebUI.Models
{
    public class ArtistEventViewModel
    {
        public string ArtistName { get; set; }
        public string MusicGenre { get; set; }
        public string ImageUrl { get; set; }
        public string YoutubeChannel { get; set; }
        public string EventTitle { get; set; }
        public string EventTime { get; set; }
        public string EventDescription { get; set; }
        public int ArtistId { get; internal set; }
    }
}
