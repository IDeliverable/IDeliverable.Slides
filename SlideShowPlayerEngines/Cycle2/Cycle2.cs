using IDeliverable.Slides.Helpers;
using IDeliverable.Slides.Services;
using IUpdateModel = Orchard.ContentManagement.IUpdateModel;

namespace IDeliverable.Slides.SlideshowPlayerEngines.Cycle2
{
    public class Cycle2 : SlideshowPlayerEngine
    {
        public int Speed
        {
            get { return this.Retrieve(x => x.Speed, () => 500); }
            set { this.Store(x => x.Speed, value); }
        }

        public int? ManualSpeed
        {
            get { return this.Retrieve(x => x.ManualSpeed); }
            set { this.Store(x => x.ManualSpeed, value); }
        }

        public int Timeout
        {
            get { return this.Retrieve(x => x.Timeout, () => 4000); }
            set { this.Store(x => x.Timeout, value); }
        }

        public bool AllowWrap
        {
            get { return this.Retrieve(x => x.AllowWrap, () => true); }
            set { this.Store(x => x.AllowWrap, value); }
        }

        public string AutoHeight
        {
            get { return this.Retrieve(x => x.AutoHeight, () => "0"); }
            set { this.Store(x => x.AutoHeight, value); }
        }

        public int Loop
        {
            get { return this.Retrieve(x => x.Loop, () => 0); }
            set { this.Store(x => x.Loop, value); }
        }

        public bool Paused
        {
            get { return this.Retrieve(x => x.Paused); }
            set { this.Store(x => x.Paused, value); }
        }

        public bool PauseOnHover
        {
            get { return this.Retrieve(x => x.PauseOnHover); }
            set { this.Store(x => x.PauseOnHover, value); }
        }

        public bool Random
        {
            get { return this.Retrieve(x => x.Random); }
            set { this.Store(x => x.Random, value); }
        }

        public bool Reverse
        {
            get { return this.Retrieve(x => x.Reverse); }
            set { this.Store(x => x.Reverse, value); }
        }

        public string Fx
        {
            get { return this.Retrieve(x => x.Fx); }
            set { this.Store(x => x.Fx, value); }
        }

        public string ManualFx
        {
            get { return this.Retrieve(x => x.ManualFx); }
            set { this.Store(x => x.ManualFx, value); }
        }

        public string Easing
        {
            get { return this.Retrieve(x => x.Easing); }
            set { this.Store(x => x.Easing, value); }
        }

        public bool Controls
        {
            get { return this.Retrieve(x => x.Controls, () => true); }
            set { this.Store(x => x.Controls, value); }
        }

        public bool Pagination
        {
            get { return this.Retrieve(x => x.Pagination, () => true); }
            set { this.Store(x => x.Pagination, value); }
        }

        public bool Swipe
        {
            get { return this.Retrieve(x => x.Swipe); }
            set { this.Store(x => x.Swipe, value); }
        }

        public string SwipeFx
        {
            get { return this.Retrieve(x => x.SwipeFx); }
            set { this.Store(x => x.SwipeFx, value); }
        }

        public int? CarouselVisible
        {
            get { return this.Retrieve(x => x.CarouselVisible, () => 1); }
            set { this.Store(x => x.CarouselVisible, value); }
        }

        public bool CarouselFluid
        {
            get { return this.Retrieve(x => x.CarouselFluid, () => true); }
            set { this.Store(x => x.CarouselFluid, value); }
        }

        public bool CarouselVertical
        {
            get { return this.Retrieve(x => x.CarouselVertical); }
            set { this.Store(x => x.CarouselVertical, value); }
        }

        public bool CarouselThrottleSpeed
        {
            get { return this.Retrieve(x => x.CarouselThrottleSpeed, () => true); }
            set { this.Store(x => x.CarouselThrottleSpeed, value); }
        }

        public int ShuffleLeft
        {
            get { return this.Retrieve(x => x.ShuffleLeft); }
            set { this.Store(x => x.ShuffleLeft, value); }
        }

        public int ShuffleRight
        {
            get { return this.Retrieve(x => x.ShuffleRight); }
            set { this.Store(x => x.ShuffleRight, value); }
        }

        public int ShuffleTop
        {
            get { return this.Retrieve(x => x.ShuffleTop, () => 15); }
            set { this.Store(x => x.ShuffleTop, value); }
        }

        public int TileCount
        {
            get { return this.Retrieve(x => x.TileCount, () => 7); }
            set { this.Store(x => x.TileCount, value); }
        }

        public int TileDelay
        {
            get { return this.Retrieve(x => x.TileDelay, () => 100); }
            set { this.Store(x => x.TileDelay, value); }
        }

        public bool TileVertical
        {
            get { return this.Retrieve(x => x.TileVertical, () => true); }
            set { this.Store(x => x.TileVertical, value); }
        }

        public override dynamic BuildEditor(dynamic shapeFactory)
        {
            return UpdateEditor(shapeFactory, null);
        }

        public override dynamic UpdateEditor(dynamic shapeFactory, IUpdateModel updater)
        {
            if (updater != null)
                updater.TryUpdateModel(this, Prefix, null, null);

            return shapeFactory.EditorTemplate(TemplateName: "SlideshowPlayerEngines.Cycle2", Model: this, Prefix: Prefix);
        }

        public override dynamic BuildDisplay(dynamic shapeFactory)
        {
            return shapeFactory.SlideshowPlayerEngines_Cycle2();
        }
    }
}