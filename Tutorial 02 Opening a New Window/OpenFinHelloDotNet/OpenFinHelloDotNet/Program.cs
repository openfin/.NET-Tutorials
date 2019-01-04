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

                var appOptions = new ApplicationOptions("application-name", "application-uuid", "http://cdn.openfin.co/demos/openfin-explorer/index.html");

                appOptions.MainWindowOptions.AutoShow = true;
                appOptions.MainWindowOptions.DefaultHeight = 850;
                appOptions.MainWindowOptions.DefaultWidth = 850;

                var application = runtime.CreateApplication(appOptions);
                application.run((a) =>
                {
                    Console.WriteLine("OpenFin app started.");
                },
                (n) =>
                {
                });
            });
            Console.Read();
        }

  }
}
