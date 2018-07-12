
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Newtonsoft.Json.Linq;
using Openfin.Desktop;


namespace HelloWorld
{
   public class Program
    {
  
            static void Main(string[] args)
             {

                Console.WriteLine("Hello World!");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();

            /*
            var runtimeOptions = new Openfin.Desktop.RuntimeOptions
            {
                Version = "stable",
                EnableRemoteDevTools = true,
                RemoteDevToolsPort = 9090
            };

            var runtime = Openfin.Desktop.Runtime.GetRuntimeInstance(runtimeOptions);

            runtime.Error += (sender, e) =>
            {
                Console.Write(e);
            };

            var openFinRuntime = Runtime.GetRuntimeInstance(runtimeOptions);
            openFinRuntime.Connect(() =>
            {
                Utils.InvokeOnUiThreadIfRequired(this, () =>
                Console.WriteLine("OpenFin Runtime is connected");

           
            });
            */

        }
    }

}

 