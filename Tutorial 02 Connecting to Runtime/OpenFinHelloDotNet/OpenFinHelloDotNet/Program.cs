using System;
using Openfin.Desktop;

namespace OpenFinHelloDotNet
{
  class Program
  {
    static void Main(string[] args)
    {

      Console.WriteLine("Hello Dot Net World");
           
      var runtimeOptions = new RuntimeOptions
      {
        Version = "stable"
      };

      var runtime = Runtime.GetRuntimeInstance(runtimeOptions);

      runtime.Connect(() =>
      {
        
      Console.WriteLine("The runtime has now connected.");

    
      });

      Console.Read();

    }
  }
}
