using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Openfin.Desktop;
using Openfin.Desktop.Messaging;

namespace EmbeddedView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window, INotifyPropertyChanged
    {
        private RuntimeOptions runtimeOptions;
        private Runtime runtime;
        private ChannelClient connectedClient;
        private ChannelProvider channel;
        private string startingUrl;
        private bool embededViewLoaded;
        private string uniqueChannelId;

        public event PropertyChangedEventHandler PropertyChanged;

        public string StartingUrl
        {
            get
            {
                return this.startingUrl;
            }
            set {
                this.startingUrl = value;
                OnPropertyChanged();
            }
        }

        public bool EmbededViewLoaded
        {
            get
            {
                return this.embededViewLoaded;
            }
            set
            {
                this.embededViewLoaded = value;
                OnPropertyChanged();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            this.EmbededViewLoaded = false;
            InitialiseOpenFin();
            InitialiseEmbeddedView();
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void InitialiseEmbeddedView()
        {
            this.StartingUrl = "http://www.google.com";
            var appOptions = new ApplicationOptions("channel-api-wpf-demo",
                "embedded-react-app",
                this.startingUrl);
            appOptions.MainWindowOptions.PreloadScripts = new List<PreloadScript>();
            var preloadScript = Path.Combine(Environment.CurrentDirectory, "preload-scripts", "navigator.js");
            appOptions.MainWindowOptions.PreloadScripts.Add(new PreloadScript(preloadScript, false));
            this.OpenFinEmbeddedView.Initialize(this.runtimeOptions, appOptions);
            this.OpenFinEmbeddedView.Ready += OpenFinEmbeddedView_Ready;
        }

        private void OpenFinEmbeddedView_Ready(object sender, EventArgs e)
        {
            this.EmbededViewLoaded = true;
        }

        private void InitialiseOpenFin()
        {
            this.uniqueChannelId = $"NavigationDriver{10}";
            this.runtimeOptions = new RuntimeOptions
            {
                Version = "18.87.55.19"
            };

            this.runtime = Runtime.GetRuntimeInstance(runtimeOptions);
            runtime.Connect(async () =>
            {
                // Enable our buttons now that we're connected to the runtime
                this.Dispatcher.Invoke(() =>
                {
                    this.backButton.IsEnabled = true;
                    this.forwardButton.IsEnabled = true;
                    this.addressInput.IsEnabled = true;
                });

                try
                {
                    this.channel = runtime.InterApplicationBus.Channel.CreateProvider(this.uniqueChannelId);
                    channel.ClientConnected += Channel_ClientConnected;
                    channel.ClientDisconnected += Channel_ClientDisconnected; ;
                    await this.channel.OpenAsync();
                    Console.WriteLine("Client channel connected");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });
        }

        private void Channel_ClientConnected(object sender, ChannelConnectedEventArgs e)
        {
            this.connectedClient = e.Client;
            this.StartingUrl = e.Payload.Value<string>("href");
        }

        private void Channel_ClientDisconnected(object sender, ChannelDisconnectedEventArgs e)
        {
            this.connectedClient = null;
        }        

        private async void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.connectedClient != null)
            {
                await this.channel.DispatchAsync(this.connectedClient.RemoteEndpoint, "navigate", new { directionIsForward = false });
            }
        }
        
        private async void forwardButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.connectedClient != null)
            {
                await this.channel.DispatchAsync(this.connectedClient.RemoteEndpoint, "navigate", new { directionIsForward = true });
            }
        }

        private async void addressInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (this.connectedClient != null)
                {
                    await this.channel.DispatchAsync(this.connectedClient.RemoteEndpoint, "navigateTo", new { newUrl = this.addressInput.Text});
                }
            }
        }
    }
}
