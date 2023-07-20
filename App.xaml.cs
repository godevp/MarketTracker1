using MarketTracker1;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SteamPriceTracker
{
    public partial class App : Application
    {
        private bool isMainWindowInitialized = false;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            if (!isMainWindowInitialized)
            {
                // Create an instance of your main application window
                var mainWindow = new MainWindow();

                // Attach the event handler to the PreviewMouseDown event
                mainWindow.PreviewMouseDown += MainWindow_PreviewMouseDown;
                /*mainWindow.Left = 1080;
                mainWindow.Top = 100;*/
                // Set the MainWindow property and show the window
                MainWindow = mainWindow;
                mainWindow.Show();

                // Set the flag to true indicating that the MainWindow is initialized
                isMainWindowInitialized = true;
            }
        }

        private void MainWindow_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Get the element that was clicked
            var element = e.OriginalSource as FrameworkElement;

            // Check if the clicked element is not a text box or its parent is not a text box
            if (!(element is TextBox) && !(element.Parent is TextBox))
            {
                // Clear the focus from the selected text box
                Keyboard.ClearFocus();
            }
        }
    }
}