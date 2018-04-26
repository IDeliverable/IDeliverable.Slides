using System.Collections.Generic;
using IDeliverable.Slides.Models;
using Orchard;

namespace IDeliverable.Slides.Services
{
    public interface ISlideshowPlayerEngineManager : IDependency
    {
        IEnumerable<ISlideshowPlayerEngine> GetEngines();
        ISlideshowPlayerEngine GetEngineBlueprint(string name);
        ISlideshowPlayerEngine GetEngineInstance(SlideshowProfile profile);
    }
}