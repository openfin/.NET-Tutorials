
## Tutorial 02 Opening a New Window

### Objective

By the end of this tutorial you should be able to understand how to open a Web Application within an OpenFin process from a .NET application.

### Where to start

Load the 'OpenFinHello\OpenFinHelloDotNet.sln' project in visual studio.  Select the Program.cs file from the solution explorer.

### What is happening?

After starting and connecting to the OpenFin Runtime, the .NET application is opening the OpenFin Explorer application within the OpenFin runtime. (The OpenFin Explorer application is hosted at http://cdn.openfin.co/demos/openfin-explorer/index.html)

### Under the hood

**Step 1**

An `ApplicationOptions` object  is created with the start parmaters of the OpenFin application (For a stand-alone OpenFin application these parameters would normally be set withing the startup_app object of the Application configuration file.   

The `ApplicationOptions` class constructor requires the manditory feilds required to start an OpenFin application:

```
public ApplicationOptions(
	string name,  // The name of the applications main window, which must be unique within the context of the Application.
	string uuid,  // The UUID of the application, unique within the set of all other Applications running in OpenFin Runtime.
	string url    // The url of the application to load
)
```

The `ApplicationOptions` documenation can be found here: http://cdn.openfin.co/docs/csharp/latest/OpenfinDesktop/html/93BFF9B3.htm.

**Step 2**

Addtional settings that should be apllied to the application main window can be set after the object has been created.  If the start page of an application should be rendered, then the `AutoShow` parameter should be explicitly set to true.

```
appOptions.MainWindowOptions.AutoShow = true;
appOptions.MainWindowOptions.DefaultHeight = 850;
appOptions.MainWindowOptions.DefaultWidth = 850;
```

The `MainWindowOptions` documenation can be found here: http://cdn.openfin.co/docs/csharp/latest/OpenfinDesktop/html/BC44BFD5.htm. 

**Step 3**

Create an application object by calling the `runtime.CreateApplication` method, which takes the ApplicationOptions as a parameter.  Once the object has been created call the `application.run()` method to initialise the application:

```
var application = runtime.CreateApplication(appOptions);
                application.run((a) =>
                {

                  Console.WriteLine("app started.");
            
                }

```


