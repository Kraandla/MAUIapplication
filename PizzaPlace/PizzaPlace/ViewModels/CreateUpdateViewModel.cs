using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PizzaPlace.Data;
using PizzaPlace.Models;

namespace PizzaPlace.ViewModels
{
    public partial class CreateUpdateViewModel : ObservableObject
    {
        private readonly DatabaseContext _dbContext;

        [ObservableProperty]
        private Pizza pizza;

        public CreateUpdateViewModel()
        {
            _dbContext = new DatabaseContext();
            Pizza = new Pizza { CreatedAt = DateTime.Now }; // default for create
        }

        public CreateUpdateViewModel(Pizza pizza)
        {
            _dbContext = new DatabaseContext();
            Pizza = pizza ?? new Pizza { CreatedAt = DateTime.Now };
        }

        [RelayCommand]
        private async Task SavePizza()
        {
            // Validate pizza
            var (isValid, errorMessage) = Pizza.Validate();
            if (!isValid)
            {
                await Application.Current.MainPage.DisplayAlert("Validation Error", errorMessage, "OK");
                return;
            }

            bool success;
            if (Pizza.Id == 0)
            {
                // Create
                success = await _dbContext.AddItemAsync(Pizza);
            }
            else
            {
                // Update
                success = await _dbContext.UpdateItemAsync(Pizza);
            }

            if (success)
            {
                await Application.Current.MainPage.DisplayAlert("Success", "Pizza saved successfully!", "OK");
                await Application.Current.MainPage.Navigation.PopAsync();

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to save pizza.", "OK");
            }
        }


        public string PizzaImageName => Path.GetFileName(Pizza.Image ?? "");

        [RelayCommand]
        private async Task PickImage()
        {
            try
            {
                var photo = await MediaPicker.Default.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Select a pizza image"
                });

                if (photo != null)
                {
                    Pizza.Image = photo.FullPath;
                    OnPropertyChanged(nameof(Pizza));
                    OnPropertyChanged(nameof(PizzaImageName));
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        [RelayCommand]
        private void DeleteImage()
        {
            Pizza.Image = null;
            OnPropertyChanged(nameof(Pizza));
        }
    }
}
