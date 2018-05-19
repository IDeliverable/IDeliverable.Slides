﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using IDeliverable.Slides.Models;
using IDeliverable.Slides.Services;
using IDeliverable.Slides.ViewModels;
using Orchard;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Orchard.Layouts.Framework.Drivers;

namespace IDeliverable.Slides.Drivers
{
    public class SlideshowPartDriver : ContentPartDriver<SlideshowPart>
    {
        private readonly IOrchardServices _services;
        private readonly ISlideshowPlayerEngineManager _engineManager;
        private readonly ISlidesProviderService _providerService;
        private readonly ISlideshowProfileService _slideShowProfileService;

        public SlideshowPartDriver(
            IOrchardServices services,
            ISlideshowPlayerEngineManager engineManager,
            ISlidesProviderService providerService,
            ISlideshowProfileService slideShowProfileService)
        {
            _services = services;
            _engineManager = engineManager;
            _providerService = providerService;
            _slideShowProfileService = slideShowProfileService;
        }

        protected override DriverResult Editor(SlideshowPart part, dynamic shapeHelper)
        {
            return Editor(part, null, shapeHelper);
        }

        protected override DriverResult Editor(SlideshowPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            return ContentShape("Parts_Slideshow_Edit", () =>
            {
                var storage = new ContentPartStorage(part);
                var slidesProviderContext = new SlidesProviderContext(part, part, storage);
                var providerShapes = Enumerable.ToDictionary(_providerService.BuildEditors(shapeHelper, slidesProviderContext), (Func<dynamic, string>)(x => (string)x.Provider.Name));

                var viewModel = new SlideshowPartViewModel
                {
                    Part = part,
                    ProfileId = part.ProfileId,
                    AvailableProfiles = _services.WorkContext.CurrentSite.As<SlideshowSettingsPart>().Profiles.ToList(),
                    ProviderName = part.ProviderName,
                    AvailableProviders = providerShapes,
                };

                if (updater != null)
                {
                    if (updater.TryUpdateModel(viewModel, Prefix, new[] { "ProfileId", "ProviderName" }, null))
                    {
                        providerShapes = Enumerable.ToDictionary(_providerService.UpdateEditors(shapeHelper, slidesProviderContext, new Updater(updater, Prefix)), (Func<dynamic, string>)(x => (string)x.Provider.Name));
                        part.ProfileId = viewModel.ProfileId;
                        part.ProviderName = viewModel.ProviderName;
                        viewModel.AvailableProviders = providerShapes;
                    }
                }

                return shapeHelper.EditorTemplate(TemplateName: "Parts.Slideshow", Prefix: Prefix, Model: viewModel);
            });
        }

        protected override DriverResult Display(SlideshowPart part, string displayType, dynamic shapeHelper)
        {
            return Combined(
                ContentShape("Parts_Slideshow", () =>
                {
                    var slideShapes = GetSlides(part, shapeHelper);
                    var engine = _engineManager.GetEngineInstance(part.Profile);
                    var engineShape = engine.BuildDisplay(shapeHelper);

                    engineShape.Engine = engine;
                    engineShape.Slides = slideShapes;
                    engineShape.SlideshowId = part.Id.ToString(CultureInfo.InvariantCulture);

                    return shapeHelper.Parts_Slideshow(Slides: slideShapes, Engine: engineShape);
                }),
                ContentShape("Parts_Slideshow_Summary", () =>
                {
                    var slideShapes = GetSlides(part, shapeHelper);
                    return shapeHelper.Parts_Slideshow_Summary(Slides: slideShapes);
                }),
                ContentShape("Parts_Slideshow_SummaryAdmin", () =>
                {
                    var slideShapes = GetSlides(part, shapeHelper);
                    return shapeHelper.Parts_Slideshow_SummaryAdmin(Slides: slideShapes);
                }));
        }

        protected override void Exporting(SlideshowPart part, ExportContentContext context)
        {
            context.Element(part.PartDefinition.Name).SetAttributeValue("Profile", part.Profile != null ? part.Profile.Name : null);
            context.Element(part.PartDefinition.Name).SetAttributeValue("Provider", part.ProviderName);

            var storage = new ContentPartStorage(part);
            var providersElement = _providerService.Export(storage, part);

            context.Element(part.PartDefinition.Name).Add(providersElement);
        }

        protected override void Importing(SlideshowPart part, ImportContentContext context)
        {
            context.ImportAttribute(part.PartDefinition.Name, "Profile", profileName =>
            {
                var profile = _slideShowProfileService.FindByName(profileName);
                part.ProfileId = profile != null ? profile.Id : default(int?);
            });

            context.ImportAttribute(part.PartDefinition.Name, "Provider", providerName =>
            {
                var provider = _providerService.GetProvider(providerName);
                part.ProviderName = provider != null ? provider.Name : null;
            });

            var storage = new ContentPartStorage(part);
            var partDefinitionElement = context.Data.Element(part.PartDefinition.Name);
            var providersElement = partDefinitionElement != null ? partDefinitionElement.Element("Providers") : default(XElement);

            _providerService.Import(storage, providersElement, new ImportContentContextWrapper(context), part);
        }

        private IList<dynamic> GetSlides(SlideshowPart part, dynamic shapeHelper)
        {
            var provider = !String.IsNullOrWhiteSpace(part.ProviderName) ? _providerService.GetProvider(part.ProviderName) : default(ISlidesProvider);
            var storage = new ContentPartStorage(part);
            var slidesProviderContext = new SlidesProviderContext(part, part, storage);
            return provider == null ? new List<dynamic>() : new List<dynamic>(provider.BuildSlides(shapeHelper, slidesProviderContext));
        }
    }
}