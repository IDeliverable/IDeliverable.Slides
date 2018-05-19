using Orchard;
using Orchard.ContentManagement;
using Orchard.Layouts.Framework.Elements;
using Orchard.Localization;
using Orchard.Utility.Extensions;

namespace IDeliverable.Slides.Services
{
    public abstract class SlideshowPlayerEngine : Component, ISlideshowPlayerEngine
    {
        protected SlideshowPlayerEngine()
        {
            Data = new ElementDataDictionary();
        }

        public virtual string Name
        {
            get { return T(GetType().Name).ToString(); }
        }

        public virtual string Prefix
        {
            get { return GetType().Name; }
        }

        public virtual LocalizedString DisplayName
        {
            get { return T(Name.CamelFriendly()); }
        }

        public ElementDataDictionary Data { get; set; }

        public virtual dynamic BuildEditor(dynamic shapeFactory)
        {
            return null;
        }

        public virtual dynamic UpdateEditor(dynamic shapeFactory, IUpdateModel updater)
        {
            return null;
        }

        public virtual dynamic BuildDisplay(dynamic shapeFactory)
        {
            return null;
        }
    }
}