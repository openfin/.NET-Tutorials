
## Tutorial 01 Connecting to the runtime

### Objective

By the end of this tutorial you should be able to understand how the OpenFin .NET adapter is used to start and connect to an OpenFin Runtime instance from a .NET application.

### Where to start

Load the 'OpenFinHelloDotNet\OpenFinHelloDotNet.sln' project file in visual studio.  Select the Program.cs file from the solution explorer.

### What is happening?

A basic example .NET console application is using the OpenFin .NET adapter to create an OpenFin Runtime instance which is then connected to.

### Under the hood

- A `RuntimeOptions` Object is created to define parmeters which will be used to initialised the runtime.   Full deatils about the available options are available here: http://cdn.openfin.co/docs/csharp/latest/OpenfinDesktop/html/6A71B701.htm

In this example only the runtime version is specified:
```
var runtimeOptions = new RuntimeOptions
    {
        Version = "stable"
    };
```
In the example the OpenFin 'Stable' channel is specified ensuring the latest version of OpenFin is used.  In a production environment we recomend a static runtime version is configured to provide you with full control over when a new runtime version is used by your application, a list of OpenFin Runtime versions is available here: https://developer.openfin.co/versions/?product=Runtime.

- To start an OpenFin runtime process the `Runtime.GetRuntimeInstance(GetRuntimeInstance)` method is called (http://cdn.openfin.co/docs/csharp/latest/OpenfinDesktop/html/E80A5D83.htm), with the RuntimeOptions object created in the step above.

```
var runtime = Runtime.GetRuntimeInstance(runtimeOptions);
```

- Once the a runtime instance has been created the `Runtime.Connect()` method is used to connect the adapter to the runtime (http://cdn.openfin.co/docs/csharp/latest/OpenfinDesktop/html/F98A61F0.htm)

```
runtime.Connect(() =>
    {
        Console.WriteLine("The runtime has now connected.");
    });

```