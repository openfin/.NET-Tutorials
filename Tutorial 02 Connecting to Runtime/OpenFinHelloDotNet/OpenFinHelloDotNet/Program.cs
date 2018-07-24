using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Openfin.Desktop;

namespace OpenFinHelloDotNet
{
  class Program
  {
    static void Main(string[] args)
    {

       Console.WriteLine("Hello Dot Net World");
       AutoResetEvent sync = new AutoResetEvent(false);
       //Allows the program to wait, setting the initial state to false
           
      var runtimeOptions = new RuntimeOptions
      {
        Version = "stable"
      };

      var runtime = Runtime.GetRuntimeInstance(runtimeOptions);

      runtime.Connect(() =>
      {
        
        Console.WriteLine("The runtime has now connected.");

    
      });
      sync.WaitOne();

    }
  }
}
