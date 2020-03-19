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
                Version = "10.66.39.43"
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
                appOptions.MainWindowOptions.ContextMenu = true;
                appOptions.MainWindowOptions.AcceleratorKeys = new AcceleratorKeyOptions
                {
                   Zoom = true
                };
             

                var application = runtime.CreateApplication(appOptions);
                application.run((a) =>
                {

                 Console.WriteLine("app started.");
            
                },
                (n) =>
                {
                });
            });
                 Console.Read();
        }

  }
}
