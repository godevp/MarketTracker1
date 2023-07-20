using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Diagnostics;

namespace MarketTracker1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool canAdd { get; set; } = true;
        public ObservableCollection<LineElement> LineElements { get; } = new ObservableCollection<LineElement>();
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.DataContext = this;
            //load data from json file
            LoadDataFromJson();
            Closing += MainWindow_Closing;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(canAdd)
            LineElements.Add(new LineElement { /* set properties here as needed */ });
        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            canAdd = false;
            foreach (var element in LineElements)
            {
                if (!string.IsNullOrWhiteSpace(element.HashName))
                {
                    await GetSteamPrice(element);
                }
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
            //2 - update json file
            SaveDataToJson();
            canAdd = true;
        }
        private void OpenInSteam_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is Button button && button.CommandParameter is string link)
            {
                // Open the link in the user's browser.
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = link,
                    UseShellExecute = true // Use the operating system shell to start the process
                });
            }
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is Button button && button.CommandParameter is LineElement item)
    {
        if(item != null) {
            item.IsEditMode = !item.IsEditMode;
        }
    }
        }
        private void Up_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is Button button && button.CommandParameter is LineElement item)
            {
                var index = LineElements.IndexOf(item);
                if (index > 0) // check if it's not already at the top
                {
                    LineElements.Move(index, index - 1);
                }
            }
        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is Button button && button.CommandParameter is LineElement item)
            {
                var index = LineElements.IndexOf(item);
                if (index < LineElements.Count - 1) // check if it's not already at the bottom
                {
                    LineElements.Move(index, index + 1);
                }
            }
        }
        private void SaveDataToJson()
        {
            string filePath = "data.json";
            List<LineElement> validLineElements = new List<LineElement>();

            foreach (var element in LineElements)
            {
                if (!string.IsNullOrWhiteSpace(element.Name) && !string.IsNullOrWhiteSpace(element.Link))
                {
                    validLineElements.Add(element);
                }
            }

            var dataToSave = new
            {
                BankInfo = BankTextBox.Text,
                LineElements = validLineElements
            };

            var dataToWrite = JsonConvert.SerializeObject(dataToSave);

            if (!File.Exists(filePath))
            {
                using (var file = File.Create(filePath)) { }
            }

            File.WriteAllText(filePath, dataToWrite);
        }
        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            // Call the SaveDataToJson() method here
            SaveDataToJson();
        }
        private void LoadDataFromJson()
        {
            string filePath = "data.json";

            if (File.Exists(filePath))
            {
                var jsonData = File.ReadAllText(filePath);
                var dataFromJson = JsonConvert.DeserializeObject<DataModel>(jsonData);

                if (dataFromJson != null)
                {
                    BankTextBox.Text = dataFromJson.BankInfo;

                    foreach (var lineElement in dataFromJson.LineElements)
                    {
                        LineElements.Add(lineElement);
                    }
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is LineElement item)
            {
                LineElements.Remove(item);
            }
        }

        public async Task GetSteamPrice(LineElement element)
        {
            // Create URL
            string url = "https://steamcommunity.com/market/priceoverview/?country=CA&currency=20&appid=730&market_hash_name=" + element.HashName;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    //Debug.WriteLine($"Raw JSON Response for {element.HashName} : {jsonResponse}");

                    var data = JsonConvert.DeserializeObject<ResponseData>(jsonResponse);

                    if (data != null && data.success)
                    {
                        // Get the prices
                        string lowestPrice = data.lowest_price;
                        string medianPrice = data.median_price;

                        // Debug.WriteLine($"Lowest Price: {lowestPrice}");

                        element.MedianPrice = " " + medianPrice;
                        element.LowestPrice = " " + lowestPrice;
                    }
                    else
                    {
                        Debug.WriteLine("Failed to parse JSON response!");
                    }
                }
                else
                {
                    Debug.WriteLine("Web request failed: " + response.StatusCode);
                }
            }
        }

        public class ResponseData
        {
            public bool success { get; set; }
            public string lowest_price { get; set; }
            public string median_price { get; set; }
        }
    }
    public class DataModel
    {
        public string BankInfo { get; set; }
        public List<LineElement> LineElements { get; set; }
    }
    public class LineElement : INotifyPropertyChanged
    {
        private string name;
        private string link;
        private string hashName;
        private string amount;
        private string lowPrice;
        private string medianPrice;
        private bool isEditMode;

        public event PropertyChangedEventHandler PropertyChanged;
        #region Getter/Setters
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        

        public string LowestPrice
        {
            get { return lowPrice; }
            set
            {
                lowPrice = value;
                OnPropertyChanged("LowestPrice");
            }
        }
        public string Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged("Amount");
            }
        }
        public string MedianPrice
        {
            get { return medianPrice; }
            set
            {
                medianPrice = value;
                OnPropertyChanged("MedianPrice");
            }
        }
        public string Link
        {
            get { return link; }
            set
            {
                link = value;
                OnPropertyChanged("Link");

                if (value.StartsWith("https://steamcommunity.com/market/listings/730/"))
                {
                    HashName = Uri.UnescapeDataString(value.Substring("https://steamcommunity.com/market/listings/730/".Length));
                }
            }
        }
        public string HashName
        {
            get { return hashName; }
            set
            {
                hashName = value;
                OnPropertyChanged("HashName");
            }
        }

        public bool IsEditMode
        {
            get { return isEditMode; }
            set
            {
                isEditMode = value;
                OnPropertyChanged("IsEditMode");
            }
        }
        #endregion
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


