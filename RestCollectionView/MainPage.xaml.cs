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

        private async void OnSearchClicked(object sender, EventArgs e)
        {
            try
            {
                loader.IsVisible = true;
                loader.IsRunning = true;

                string searchText = searchEntry.Text?.ToLower() ?? "";

                // קריאה לשרת
                var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                var posts = JsonSerializer.Deserialize<List<Post>>(json);

                // סינון לפי טקסט
                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    posts = posts?.Where(p => p.Title.ToLower()
                                                    .Contains(searchText))
                                                    .ToList();
                }
                if (posts != null)
                {
                    resultsCollection.ItemsSource = new ObservableCollection<Post>(posts); ;
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
