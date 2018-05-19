﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using IDeliverable.Slides.Elements;
using IDeliverable.Slides.Helpers;
using IDeliverable.Slides.Models;
using IDeliverable.Slides.Services;
using IDeliverable.Slides.ViewModels;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Layouts.Framework.Display;
using Orchard.Layouts.Framework.Drivers;
using Orchard.Layouts.Helpers;
using Orchard.Services;

namespace IDeliverable.Slides.Drivers
{
    public class SlideshowElementDriver : ElementDriver<Slideshow>
    {
        private readonly IOrchardServices _services;
        private readonly ISlideshowPlayerEngineManager _engineManager;
        private readonly IClock _clock;
        private readonly ISlidesProviderService _providerService;
        private readonly ISlideshowProfileService _slideShowProfileService;

        public SlideshowElementDriver(
            IOrchardServices services,
            ISlideshowPlayerEngineManager engineManager,
            IClock clock,
            ISlidesProviderService providerService,
            ISlideshowProfileService slideShowProfileService)
        {
            _services = services;
            _engineManager = engineManager;
            _clock = clock;
            _providerService = providerService;
            _slideShowProfileService = slideShowProfileService;
        }

        public string Prefix
        {
            get { return "SlideshowElement"; }
        }

        protected override EditorResult OnBuildEditor(Slideshow element, ElementEditorContext context)
        {
            var storage = new ElementStorage(element);
            var slidesProvidercontext = new SlidesProviderContext(context.Content, element, storage, context.Session);
            var providerShapes = Enumerable.ToDictionary(_providerService.BuildEditors(context.ShapeFactory, slidesProvidercontext), (Func<dynamic, string>)(x => (string)x.Provider.Name));

            var viewModel = new SlideshowElementViewModel
            {
                Element = element,
                ProfileId = element.ProfileId,
                SessionKey = context.Session,
                AvailableProfiles = _services.WorkContext.CurrentSite.As<SlideshowSettingsPart>().Profiles.ToList(),
                ProviderName = element.ProviderName,
                AvailableProviders = providerShapes,
            };

            if (context.Updater != null)
            {
                if (context.Updater.TryUpdateModel(viewModel, Prefix, new[] { "ProfileId", "ProviderName", "SlidesData" }, null))
                {
                    // The element editor only provides the posted form values (for the ValueProvider), so we need to fetch the slides data ourselves in order to not lose it.
                    if (context.ElementData.ContainsKey("SlideshowSlides"))
                        storage.StoreSlidesData(context.ElementData["SlideshowSlides"]);

                    providerShapes = Enumerable.ToDictionary(_providerService.UpdateEditors(context.ShapeFactory, slidesProvidercontext, new Updater(context.Updater, Prefix)), (Func<dynamic, string>)(x => (string)x.Provider.Name));
                    element.ProfileId = viewModel.ProfileId;
                    element.ProviderName = viewModel.ProviderName;
                    viewModel.AvailableProviders = providerShapes;
                }
            }

            var slidesEditor = context.ShapeFactory.EditorTemplate(TemplateName: "Elements.Slideshow", Prefix: Prefix, Model: viewModel);

            //viewModel.Slides = element.Slides.Select(x => _layoutManager.RenderLayout(x.LayoutData)).ToArray();
            slidesEditor.Metadata.Position = "Slides:0";
            return Editor(context, slidesEditor);
        }

        protected override void OnDisplaying(Slideshow element, ElementDisplayingContext context)
        {
            var slideShapes = GetSlides(element, context);
            var engine = _engineManager.GetEngineInstance(element.Profile);
            var engineShape = engine.BuildDisplay(_services.New);

            engineShape.Engine = engine;
            engineShape.Slides = slideShapes;
            engineShape.SlideshowId = _clock.UtcNow.Ticks + "-" + element.Index; // TODO: Come up with a better, deterministic way to determine the slide show id. Perhaps elements should have a unique ID (unique within the layout, at least).

            context.ElementShape.Slides = slideShapes;
            context.ElementShape.Engine = engineShape;
        }

        protected override void OnExporting(Slideshow element, ExportElementContext context)
        {
            context.ExportableData["Profile"] = element.Profile != null ? element.Profile.Name : null;
            context.ExportableData["Provider"] = element.ProviderName;

            var storage = new ElementStorage(element);
            var providersElement = _providerService.Export(storage, context.Layout);

            context.ExportableData["Providers"] = providersElement.ToString(SaveOptions.DisableFormatting);
        }

        protected override void OnImporting(Slideshow element, ImportElementContext context)
        {
            var profile = _slideShowProfileService.FindByName(context.ExportableData.Get("Profile"));
            var provider = _providerService.GetProvider(context.ExportableData.Get("Provider"));

            element.ProfileId = profile != null ? profile.Id : default(int?);
            element.ProviderName = provider != null ? provider.Name : null;

            var providersData = context.ExportableData.Get("Providers");

            if (String.IsNullOrWhiteSpace(providersData))
                return;

            var storage = new ElementStorage(element);
            var providersElement = XElement.Parse(providersData);

            _providerService.Import(storage, providersElement, context.Session, context.Layout);
        }

        private IList<dynamic> GetSlides(Slideshow element, ElementDisplayingContext context)
        {
            var provider = !String.IsNullOrWhiteSpace(element.ProviderName) ? _providerService.GetProvider(element.ProviderName) : default(ISlidesProvider);
            var storage = new ElementStorage(element);
            var slidesProviderContext = new SlidesProviderContext(context.Content, element, storage);
            return provider == null ? new List<dynamic>() : new List<dynamic>(provider.BuildSlides(_services.New, slidesProviderContext));
        }
    }
}