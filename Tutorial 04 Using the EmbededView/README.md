
## Tutorial 04 Using the EmbeddedView 

This is an example of how to use the EmbeddedView. The application is pretending to be a simple browser, with the address bar, back and forward buttons rendered in the WPF application, while the main web content is rendered inside the EmbeddedView. We leverage the concept of Pre-load scripts to add the logic

1) Install the missing nuget packages.
2) Build and run the app.

**Points of interest**
Have a look at the MainWindow.xaml.cs, the 3 main points are initialising the runtime, initialising the EmbeddedView and finally the code to create a communication channel between the WPF application and the Javascript running inside the EmbeddedView. 

For the runtime initialisation, notice this is where we set the version of the OpenFin runtime that we'd like to run on top of. We also have a Connect callback, which will fire when we've established a connection.

```
    this.runtimeOptions = new RuntimeOptions
    {
        Version = "18.87.55.19"
    };

    this.runtime = Runtime.GetRuntimeInstanceruntimeOptions);
    runtime.Connect(async () =>
    {
        // More things to do once we're connected...
    });
```
Secondly, we initialise the EmbeddedView instance that's being rendered within the MainWindow.xaml file. One interesting point here is that we are leveraging the preload scripts property. 

Javascript files that are passed into this List<PreloadScript> will be downloaded and automatically run, each and every time the window is loaded inside the EmbeddedView. By loaded, I don't mean when the control is rendered inside the WPF application, I mean when the EmbeddedView, window content is loaded.

```
    this.StartingUrl = "http://www.google.com";
    var appOptions = new ApplicationOptions"channel-api-wpf-demo",
        "embedded-react-app",
        this.startingUrl);

    appOptions.MainWindowOptions.reloadScripts = new List<PreloadScript>();

    var preloadScript = Path.CombineEnvironment.CurrentDirectory, preload-scripts", "navigator.js");
    
    appOptions.MainWindowOptions.reloadScripts.Add(new PreloadScriptpreloadScript, false));
    
    this.OpenFinEmbeddedView.Initialize(this.untimeOptions, appOptions);
    
    this.OpenFinEmbeddedView.Ready += penFinEmbeddedView_Ready;
```

Finally, we create connections to the pre-load script using our channel API, which will allow us to control the loaded content of our EmbeddedView...

```
    try
    {
        this.channel = runtime.InterApplicationBus.Channel.CreateProvider(this.uniqueChannelId);
        channel.ClientConnected += Channel_ClientConnected;
        channel.ClientDisconnected += Channel_ClientDisconnected; ;
        await this.channel.OpenAsync();
        Console.WriteLine("Client channel connected");
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
```

Have a play around, see what's possible...!