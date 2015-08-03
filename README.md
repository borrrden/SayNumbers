# SayNumbers

This is a simple app I wrote that turned out to be a nice simple real-world example of how to effectively use MvvmCross and Xamarin Forms to easily make a cross platform application.  This could be easily extended to Windows Phone later with a few simple additions.

The application is designed for people learning English as a second language to practice speaking numbers (in particular, if you look at the source or UI, it has Japanese people in particular in mind since their number system goes by units of 10,000 instead of units of 1,000).  So, for example, the number 1,234 would appear on screen.  The user should say "One Thousand Two Hundred Thirty Four."  After that, if they hit the answer (答え) button, the text will be shown and a TTS voice will speak the number for them.

## Architecture

This app makes use of the Model-View-ViewModel (MVVM) paradigm, with the assistance of the fabuluous [MvvmCross](https://github.com/MvvmCross/MvvmCross) library and [Xamarin Forms](http://xamarin.com/forms).  Lets start at the bottom of the stack with:

### Services

Services are the bread and butter of the app.  This is where all of your calculation and data manipulation goes on.  There is one service defined in this project:  `INumberConversionService`.  It is responsible for converting an integer into its textual representation, and is concretely implemented as `NumberConversionService` (a non-public class inside of the core assembly).

### Plugins

Plugins are like services, except they require platform specific functionality so only the interface is defined in the core assembly, while the implementation is registered in the platform specific app.  There is an actual plugin mechanism inside MvvmCross but I find it confusing and don't quite understand the benefit other than a few methods to make sure that it is actually implemented before trying to use it.  There is one plugin in this application:  `ITextToSpeech`.  This interface is for a class that will speak a given string.  Naturally, since this uses platform specific functionality to reach its goals it needs to be a plugin.  The service and plugin will be used in the next level up:

### View Models

There are two views in this app, and they each have their own view model.  View models handle the interaction between views and services.  `HomeViewModel` is the model for the first view in the app.  It has definitions for the lower and upper bound text that goes in the text boxes on the screen, as well as a command for the start button whih shows the view for `PracticeViewModel`.  This view model is where most of the app functionality takes place.  It contains text for the question / answer, as well as a command for the answer button.  These view models are consumed by:

### Pages

Traditionally, views (in this context, pages) were created at the platform specific level.  However, Xamarin Forms has enabled us to create platform independent pages using a similar layout system to that of Windows platforms (XAML / CS).  As of now, there is not yet designer support for XAML so I have chosen to write the pages in C# instead.  These will be bound to native view objects for the platform being targeted, and will look and behave natively.  Inside the page, I just set up some simple layout constraints, and use data binding to bind the view objects (text fields and buttons) to their respective outlets in the view model (MvvmCross takes care of setting up all the stuff in the background to ensure that everything can be resolved correctly).  This is over 90% of the app functionality taken care of here in the core assembly.  

### Platform specific stuff

The plugin needs to be implemented at the platform specific level, as stated before, as well as some housekeeping and setup to load MvvmCross for the correct platform.  However, the line count on this is very small.  I hope this demonstrates the power of MVVM and how it can be used to share as much code as possible between platforms using Xamarin.
