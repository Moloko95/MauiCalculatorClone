using ProfileApp.Models;
using System.Text.Json;
using Microsoft.Maui.Controls;

namespace ProfileApp
{
    public partial class ProfilePage : ContentPage
    {
        private Profile _profile;
        private string _filePath;

        public ProfilePage()
        {
            InitializeComponent();
            _filePath = Path.Combine(FileSystem.AppDataDirectory, "profile.json");
            LoadProfile();
            BindingContext = _profile;
        }

        private void LoadProfile()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                _profile = JsonSerializer.Deserialize<Profile>(json);
            }
            else
            {
                _profile = new Profile();
            }

            if (!string.IsNullOrEmpty(_profile.ProfilePicturePath))
            {
                ProfileImage.Source = _profile.ProfilePicturePath;
            }
        }

        private async void OnSaveProfileClicked(object sender, EventArgs e)
        {
            var json = JsonSerializer.Serialize(_profile);
            File.WriteAllText(_filePath, json);
            await DisplayAlert("Success", "Profile saved successfully!", "OK");
        }

        private async void OnUploadPictureClicked(object sender, EventArgs e)
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Select a profile picture",
                FileTypes = FilePickerFileType.Images
            });

            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                ProfileImage.Source = ImageSource.FromStream(() => stream);
                _profile.ProfilePicturePath = result.FullPath;
            }
        }
    }
}