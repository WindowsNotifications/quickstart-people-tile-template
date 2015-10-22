using NotificationsExtensions.Tiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Quickstart_People_Tile_Template
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ButtonUpdatePrimary_Click(object sender, RoutedEventArgs e)
        {
            // Create the notification content
            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    // Recommended to use 9 photos on Medium
                    TileMedium = GeneratePeopleBinding(9),

                    // Recommended to use 15 photos on Wide
                    TileWide = GeneratePeopleBinding(15),

                    // Recommended to use 20 photos on Large
                    TileLarge = GeneratePeopleBinding(20)
                }
            };

            // And then update the primary tile
            TileUpdateManager.CreateTileUpdaterForApplication().Update(new TileNotification(content.GetXml()));
        }

        /// <summary>
        /// Generate People tile binding
        /// </summary>
        /// <param name="countOfPhotos">The number of photos you want to have on the tile.</param>
        /// <returns></returns>
        private TileBinding GeneratePeopleBinding(int countOfPhotos)
        {
            // We only have 25 photos available to use
            if (countOfPhotos > 25)
                countOfPhotos = 25;

            // Create the People content
            var content = new TileBindingContentPeople();

            // Add the photos
            for (int i = 1; i <= countOfPhotos; i++)
                content.Images.Add(new TileImageSource($"Assets/ProfilePics/{i}.jpg"));

            // And generate the binding, using the People content
            return new TileBinding()
            {
                Content = content
            };
        }
    }
}
