using System;
using System.IO;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using ProfilePage_Assignment.Models;
using ProfilePage_Assignment;
using Newtonsoft.Json;

public partial class ProfilePage : ContentPage
{
    private Profile currentProfile = new Profile();

    public ProfilePage()
    {
        InitializeComponent();

        LoadProfile();
    }

    private void LoadProfile()
    {
        var filePath = Path.Combine(FileSystem.AppDataDirectory, "profile.json");

        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            currentProfile = JsonConvert.DeserializeObject<Profile>(json) ?? new Profile();
        }
        else
        {
            currentProfile = new Profile();
        }

        // Pre-populate the fields
        NameEntry.Text = currentProfile.Name;
        SurnameEntry.Text = currentProfile.Surname;
        EmailEntry.Text = currentProfile.Email;
        BioEditor.Text = currentProfile.Bio;

        if (!string.IsNullOrEmpty(currentProfile.ImagePath))
        {
            ProfileImage.Source = ImageSource.FromFile(currentProfile.ImagePath);
        }
    }

    private async void OnChoosePictureClicked(object sender, EventArgs e)
    {
        var result = await MediaPicker.PickPhotoAsync();
        if (result != null)
        {
            currentProfile.ImagePath = result.FullPath;
            ProfileImage.Source = ImageSource.FromFile(result.FullPath);
        }
    }

    private void OnSaveButtonClicked(object sender, EventArgs e)
    {
        currentProfile.Name = NameEntry.Text;
        currentProfile.Surname = SurnameEntry.Text;
        currentProfile.Email = EmailEntry.Text;
        currentProfile.Bio = BioEditor.Text;

        var json = JsonConvert.SerializeObject(currentProfile);
        var filePath = Path.Combine(FileSystem.AppDataDirectory, "profile.json");
        File.WriteAllText(filePath, json);
    }
}
}
