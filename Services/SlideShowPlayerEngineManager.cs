using System;
using System.Collections.Generic;
using System.Linq;
using IDeliverable.Slides.Models;
using Orchard;
using Orchard.Layouts.Framework.Elements;
using Orchard.Layouts.Helpers;

namespace IDeliverable.Slides.Services
{
    public class SlideshowPlayerEngineManager : ISlideshowPlayerEngineManager
    {
        private readonly Lazy<IEnumerable<ISlideshowPlayerEngine>> _engines;
        private readonly IWorkContextAccessor _wca;

        public SlideshowPlayerEngineManager(Lazy<IEnumerable<ISlideshowPlayerEngine>> engines, IWorkContextAccessor wca) {
            _engines = engines;
            _wca = wca;
        }

        public IEnumerable<ISlideshowPlayerEngine> GetEngines()
        {
            return _engines.Value;
        }

        public ISlideshowPlayerEngine GetEngineBlueprint(string name)
        {
            return GetEngines().SingleOrDefault(x => x.Name == name);
        }

        public ISlideshowPlayerEngine GetEngineInstance(SlideshowProfile profile)
        {
            var blueprint = profile != null ? GetEngineBlueprint(profile.SelectedEngine) : GetEngines().First();
            var engine = (ISlideshowPlayerEngine)_wca.GetContext().Resolve(blueprint.GetType());
            engine.Data = profile != null ? ElementDataHelper.Deserialize(profile.EngineStates[profile.SelectedEngine]) : new ElementDataDictionary();
            return engine;
        }
    }
}