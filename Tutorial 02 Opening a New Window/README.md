
## Tutorial 03 Opening a New Window


This tutorial will guide you through on how to open a new OpenFin window via the .NET adapter.  Below are the steps required to achieve this:

**1st Step**

Use the `ApplicationOptions` class to construct an instance configuring a new JObject with the passed values.

>

This consists of the following:

```
public ApplicationOptions(
	string name,  // the name of the application
	string uuid,  // the UUID of the application
	string url    // the url of the application to load
)
```
**2nd Step**

The next step is to add the specific window options we would like the to window to load up with.  We will now use the `WindowOptions` class that represents the options for the window.

To add your chosen options, simply include them within the `runtime.Connect` call.  This would look something like this in your code:

```
runtime.Connect(() =>
    {

        Console.WriteLine("The runtime has now connected.");

        var appOptions = new ApplicationOptions("application-name", "application-uuid", "https://www.google.com");

        appOptions.MainWindowOptions.AutoShow = true;
        appOptions.MainWindowOptions.Frame = true;
        appOptions.MainWindowOptions.Resizable = true;
        appOptions.MainWindowOptions.Name = "Test Window";                            
.....

```

>Experiment by adding further window options, a list of these properties can be found [here](http://cdn.openfin.co/docs/csharp/latest/OpenfinDesktop/html/BC44BFD5.htm). 

**3rd Step**

The next step is to create your application using the specified options as set above.  This is achieved by using the `runtime.CreateApplication` Method.  Lastly to run the application, we use the `application.run` method, this could look something like this:

```
var application = runtime.CreateApplication(appOptions);
                application.run((a) =>
                {

                  Console.WriteLine("app started.");
            
                }

```

>As this is a console application, remember to include `Console.Read()` to keep the console window open and to allow the application to run.


