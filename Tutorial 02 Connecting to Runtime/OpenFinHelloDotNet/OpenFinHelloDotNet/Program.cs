using System;
using Openfin.Desktop;

namespace OpenFinHelloDotNet
{
  class Program
  {
    static void Main(string[] args)
    {

      Console.WriteLine("Hello welcome to Tutorial 2");
           
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
