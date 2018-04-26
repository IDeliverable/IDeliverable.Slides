using IDeliverable.Slides.Models;
using IDeliverable.Slides.Services;
using Orchard.ContentManagement.Handlers;

namespace IDeliverable.Slides.Handlers
{
    public class SlideshowPartHandler : ContentHandler
    {
        private readonly ISlideshowProfileService _slideShowProfileService;

        public SlideshowPartHandler(ISlideshowProfileService slideShowProfileService)
        {
            _slideShowProfileService = slideShowProfileService;
            OnActivated<SlideshowPart>(SetupLazyFields);
        }

        private void SetupLazyFields(ActivatedContentContext context, SlideshowPart part)
        {
            part._profileField.Loader(() =>
            {
                var profile = _slideShowProfileService.FindById(part.ProfileId.GetValueOrDefault());
                return profile;
            });
        }
    }
}