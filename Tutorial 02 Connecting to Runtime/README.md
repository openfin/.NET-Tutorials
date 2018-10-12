
## Tutorial 02 Connecting to the runtime

### Tutorial 2

The latest .NET API documentation can be found [here](http://cdn.openfin.co/docs/csharp/latest/OpenfinDesktop/html/F7F260CA.htm).  We will refer to this documentation throughout these tutorials, please familiarise yourself with the different classes and methods available.

This tutorial demonstrates connecting to the OpenFin runtime via a console application using the [Runtime](http://cdn.openfin.co/docs/csharp/latest/OpenfinDesktop/html/A0E038D5.htm) class and [RuntimeOptions](http://cdn.openfin.co/docs/csharp/latest/OpenfinDesktop/html/6A71B701.htm) class.

-  The `RuntimeOptions` Class allows us to define options for the runtime such as the `version` of runtime ie "stable", "alpha" etc.

- To connect to the runtime you will need to use the `Runtime` class which is defined in the `Openfin.Desktop` namespace. In perticular we will be using the `GetRuntimeInstance` Method that gets an existing Runtime Object for the specific `version` and creates a new connection.

To connect to the runtime follow these steps:

- Define your runtime Options properties, for the simplicity of this example we will use one property named `version`.  This is defined as seen below:

```
var runtimeOptions = new RuntimeOptions
    {
        Version = "stable"
    };
```

>Experiment by adding further properties to the runtime options, a list of these properties can be found [here](http://cdn.openfin.co/docs/csharp/latest/OpenfinDesktop/html/44791028.htm). 

- To use the OpenFin runtime, you will need to connect to it.  To do this simply pass the connect method with the runtime options.  This would look something like this:

```
var runtime = Runtime.GetRuntimeInstance(runtimeOptions);

runtime.Connect(() =>
    {
        Console.WriteLine("The runtime has now connected.");
    });

```

