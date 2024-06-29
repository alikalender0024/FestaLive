using FestaLive.Entities.Concrete;

namespace FestaLive.WebUI.Models
{
    public class FeatureAndSocialMediaViewModel
    {
        public IEnumerable<Feature> Features { get; set; }
        public IEnumerable<SocialMedia> SocialMedias { get; set; }
    }

}
