
## Tutorial 01 Connecting to the runtime

### Tutorial 1

#### Objective

By the end of this tutorial you should be able to understand how the .NET adapter is used to start and connect to OpenFin Runtime instance, which is the basis of the interaction between a .NET application and OpenFin.

#### Where to start

Load the 'OpenFinHello\OpenFinHelloDotNet.sln' project in visual studio.  Select the Program.cs file from the solution explorer.

#### What is happening?

The .NET application is using the OpenFin .NET adapter to create, and connect to, an OpenFin Runtime instance.

- The `RuntimeOptions` Class allows us to define parmeters which will be used to initialised the runtime http://cdn.openfin.co/docs/csharp/latest/OpenfinDesktop/html/6A71B701.htm

In this example only the runtime version is specified (Which results in the runtime running as a headless application)
```
var runtimeOptions = new RuntimeOptions
    {
        Version = "stable"
    };
```

- To create a runtime instance, `Runtime.GetRuntimeInstance(GetRuntimeInstance)` class is called (http://cdn.openfin.co/docs/csharp/latest/OpenfinDesktop/html/E80A5D83.htm)

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