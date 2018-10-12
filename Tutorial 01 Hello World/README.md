
## Tutorial 01 Hello World


**Hello World**

You should be now able to navigate and open the solution file (OpenFinHelloDotNet.sln) for this first tutorial. Once opened hit "Start" and the hello world console application will compile and run.

**The .Net Basics from Hello World**

```
Program.cs
``` 

 This has a file extension of .cs because it contains  C# source code.  When you build the program, the `dotnet build` tool will build all of the files that end in ".cs" using the C# compiler.

&nbsp;
```
Using System;
```

 The `using` statement statement as mentioned previously allows us to refer to elements that exist in the the listed namespace (in this case System).  A namespace is a way of organising programming constructs, for instance in the hello world application the "System" namespace is used so that the `console` type (used to print "Hello OpenFin DotNet) is in that namespace. If the `using` statement were removed, the `Console.WriteLine` statement would need to include the namespace thus becoming `System.Console.Writeline`.

&nbsp;

```
namespace OpenFinHelloDotNet
```
After the using statement, the C# program declares its namespace.  In this case the OpenFinHelloDotNet namespace has only one element in it the `Program` class (this would grow in more complex programs)

&nbsp;

```
public class Program
```
Within the namespace a `class` called "Program" is created. This line includes two keywords and one identifier. The public keyword describes the class's accessibility level. This defines how the class may be accessed by other parts of the program, and public means there are no restrictions to its access. The class keyword is used to define classes in C#, one of the primary constructs used to define types you will work with. C# is a strongly typed language, meaning that most of the time you'll need to explicitly define a type in your source code before it can be referenced from a program.

&nbsp;

```
public static void Main()
```
The "Main" method is this program's entry point - the first code that runs when the application is run. Public means there are no limitations on access to this method.

The "static" keyword marks this method as global and associated with the type it's defined on, not a particular instance of that type. 

The "void" keyword indicates that this method doesn't return a value. The method is named Main.
