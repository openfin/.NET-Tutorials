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

            var runtimeOptions = new RuntimeOptions
            {
                Version = "stable"
            };

            var runtime = Runtime.GetRuntimeInstance(runtimeOptions);

            runtime.Connect(() =>
            {

                Console.WriteLine("The runtime has now connected.");

                var appOptions = new ApplicationOptions("application-name", "application-uuid", "https://www.google.com");

                appOptions.MainWindowOptions.AutoShow = true;
                appOptions.MainWindowOptions.Frame = true;
                appOptions.MainWindowOptions.Resizable = true;
                appOptions.MainWindowOptions.Name = "Test Window";

                var application = runtime.CreateApplication(appOptions);
                application.run((a) =>
          {

                  Console.WriteLine("app started.");
              },
          (n) =>
          {
              });
            });

        

      sync.WaitOne();
    }
  }
}
