# IDeliverable.Slides

A module for the Orchard CMS that allows editors to easily add **slideshows** to their sites. Each slide is a layout, allowing complete visual control and content flexibility, and can be added either statically or dynamically based on projections and lists. Out of the box, slideshows can be rendered using either **Bootstrap Carousel**, **Cycle2** or **jCarousel**. Developers can easily extend this list by writing their own plugins using an easy-to-use API.

A slideshow is a type of graphical element on a website, which transitions between multiple slides or "pages" of content, typically images overlaid with descriptive text. With **IDeliverable.Slides** however, a slideshow can be a lot more powerful than just a bunch of images; slides are actually based on the built-in `Orchard.Layouts` functionality (a new feature introduced in Orchard 1.9) which allows them to contain any content imaginable, laid out in any way you wish using the new interactive layout editor in Orchard.

## Features

### Easy to use

Editors can build slideshows ranging from the simplest to the most advanced, using interactive graphical tools. Quickly create slideshows by importing from existing images and other content items, or create dynamic slideshows based on projections and lists.

### Based on Orchard.Layouts

Each slide in a slideshow is actually a *layout*, allowing complete visual control and content flexibility. Editors can use the familiar graphical layout editor introduced in Orchard 1.9 to create slides.

### Integrates organically

Slideshows can be added directly to content items by adding the **Slideshow Part** to a content type. They can also be placed as **Slideshow Widgets** on widget layers. They can also be used as elements in layouts using the **Slideshow Element**.

### Extensible

Orchard is all about extensibility, and so are our Orchard modules. Developers can extend the functionality of the **IDeliverable.Slides** module with new slides providers and player engines.

## Key Concepts

### Slides

A slideshow contains one or more *slides*. A slide represents one item of the slideshow, typically visualised as one "page" of the slideshow. Each slide is essentially a layout using the built-in `Orchard.Layouts` functionality in Orchard, allowing you to use the layout editor to define the content and layout of the slide.

Slides can be added to a slideshow in one of two ways:

- *Statically* at design-time, either by manually creating one or more slides from scratch, or by using one of the provided import tools to create slides based on a set of images or content items. Either way, the editor can completely customize the look of each slide using the layout editor.
- *Dynamically* at runtime based on a *projection* of content items. In this mode you base the slideshow on a *query* and optionally a *display type*. Alternatively a *list* of content items can be used. To customize the rendering of slides in this mode, a theme developer can override the shape template for the projected content type and the selected display type.

### Slideshows

The *slideshow* is the actual component that you add to your site. This is the component that does the actual rendering. It comes in three flavors depending on the context in which you wish to use it:

1. You can attach a slideshow *part* to your content types to render a slideshow as part of any content item.
2. You can place a slideshow *widget* in any widget layer using the built-in `Orchard.Widgets` functionality in Orchard.
3. You can add a slideshow *element* to any layout using the built-in `Orchard.Layouts` functionality in Orchard.

### Players

To be rendered on the front-end of your site and made visible to visitors, a slideshow uses one of the provided *player engines*. **IDeliverable.Slides** provides player engines for three popular slideshow players out of the box:

- Bootstrap Carousel [http://getbootstrap.com/javascript/#carousel][1]
- Cycle2 [http://sorgalla.com/jcarousel][2]
- jCarousel [http://sorgalla.com/jcarousel][3]

Each player supports a wide range of configuration options. A player is selected per slideshow. To do this, a slideshow is configured with a *player profile* which is a stored set of configuration options for a particular player engine, allowing you to reuse those configuration options across slideshows. If you don't select a profile, the default player (jCarousel) will be used, with a default set of settings.


  [1]: http://getbootstrap.com/javascript/#carousel
  [2]: http://jquery.malsup.com/cycle2/
  [3]: http://sorgalla.com/jcarousel/

### Extensibility

Just as **IDeliverable.Slides** uses the extensibility of the Orchard CMS to integrate with Orchard in an organic and natural way, it also mirrors this philosophy and itself provides several extensibility points, which you as a developer can utilize to extend the functionality of the module even further:

1. Developers can create new *slides providers* by implementing the `ISlidesProvider` interface. A slides provider is a component that feeds a given slideshow with slides to render. The module provides three built-in providers (static selection, dynamic selection based on lists, and dynamic selection based on projections).
2. Developers can also create new *player engines* by implementing the `IPlayerEngine` interface. The player engine is the component that renders the slideshow to visitors using a particular slideshow player. The module provides trhee built-in player engines (targeting Bootstrap Carousel, Cycle2 and jCarousel, respectively).

## Getting Started

### Installation

To install the module from Orchard Gallery:

1. In the Orchard admin UI, navigate to **Modules -> Gallery**.
1. Search for "IDeliverable.Slides".
1. Click **Install** to install the module.

To install the module using the ZIP file:

1. Download the [module ZIP file][1].
1. Unzip the contents into the `Modules` folder of your Orchard installation (this creates an `IDeliverable.Slides` subfolder).

To integrate the module into your development workflow, unzip the contents into the `Orchard.Web\Modules` folder of your local repository and add it to source control (if any).


  [1]: https://github.com/IDeliverable/IDeliverable.Slides/archive/orchard_1.10.x.zip

### Basic configuration

1. Enable the feature **Slides**.
1. When editing a layout, drag a new **Slideshow** element from the layout editor toolbox to your layout.
1. Use the element editor dialog to configure your slideshow settings and add slides to your slideshow.

### System requirements and compatibility

**IDeliverable.Slides** is compatibility-tested and supported on **Orchard version 1.10.x**. The module might also work on older or newer versions of Orchard but this is not guaranteed.

We make a commitment that the current release of our modules should always work with the current minor release of Orchard (e.g. 1.10) and across all subsequent revision releases (e.g. 1.10.1, 1.10.2 and so on). We strive to always conduct compatibility testing (and release an updated module if necessary) within two weeks of every new Orchard release.

The module provides the following features with their respective dependencies:

- *Slides* (`IDeliverable.Slides`) depends on `Orchard.Layouts`, `Orchard.JQuery` and `Orchard.MediaLibrary`.
- *Projection Slides* (`IDeliverable.Slides.Projections`) depends on `IDeliverable.Slides`, `Orchard.Projections` and `Orchard.Forms`.
- *List Slides* (`IDeliverable.Slides.Lists`) depends on `IDeliverable.Slides` and `Orchard.Lists`.

## Documentation

### User Guide

If you want to learn more about how to install and configure `IDeliverable.Slides` as a site admin, or about how to use it to add awesome slideshows to your website as an editor, please check out our [User Guide](http://www.ideliverable.com/documentation/ideliverable-slides/user-guide).

### Developer Guide

If you want to learn more about how to extend `IDeliverable.Slides` with more functionality (such as support for other slideshow components) as a developer, please check out our [Developer Guide](http://www.ideliverable.com/documentation/ideliverable-slides/developer-guide).