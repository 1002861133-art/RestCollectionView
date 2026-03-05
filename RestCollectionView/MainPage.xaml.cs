using RestCollectionView.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace RestCollectionView
{
    public partial class MainPage : ContentPage
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public MainPage()
        {
            InitializeComponent();
        }
        private async void OnFetchDogClicked(object sender, EventArgs e)
        {
            try
            {
                loader.IsVisible = true;
                loader.IsRunning = true;
                dogImage.IsVisible = false;
                // Fetch JSON from Dog API
                var response = await _httpClient.GetAsync("https://dog.ceo/api/breeds/image/random");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                await Task.Delay(1000);
                // Deserialize JSON
                Dog dogData = JsonSerializer.Deserialize<Dog>(json);

                if (dogData != null && dogData.Status == "success")
                {
                    // Set Image Source
                    dogImage.Source = ImageSource.FromUri(new Uri(dogData.Message));
                    dogImage.IsVisible = true;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                loader.IsRunning = false;
                loader.IsVisible = false;
            }
        }
       
    }
}
