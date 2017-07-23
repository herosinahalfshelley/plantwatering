using System;
using waterPlants.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace waterPlants.ViewModels
{
    public class PlantViewModel : BaseViewModel
    {
		public ObservableRangeCollection<Plant> Plants { get; set; }
		public Command LoadPlantsCommand { get; set; }

		public PlantViewModel()
		{
			Title = "Browse";
			Plants = new ObservableRangeCollection<Plant>();
			LoadPlantsCommand = new Command(async () => await ExecuteLoadPlantsCommand());

#if __IOS__
			MessagingCenter.Subscribe<iOS.PlantNewViewController, Plant>(this, "AddPlant", async (obj, item) =>
			{
				var _item = item as Plant;
				Plants.Add(_item);
				await DataStore.AddPlantAsync(_item);
			});
#elif __ANDROID__
            MessagingCenter.Subscribe<Android.App.Activity, Plant>(this, "AddPlant", async (obj, item) =>
            {
                var _item = item as Plant;
                Plants.Add(_item);
                await DataStore.AddPlantAsync(_item);
            });
#else
            MessagingCenter.Subscribe<AddPlants, Plant>(this, "AddPlant", async (obj, item) =>
            {
                var _item = item as Plant;
                Plants.Add(_item);
                await DataStore.AddPlantAsync(_item);
            });
#endif
		}

		async Task ExecuteLoadPlantsCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;

			try
			{
				Plants.Clear();
				var items = await DataStore.GetPlantsAsync(true);
				Plants.ReplaceRange(items);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				// MessageDialog.SendMessage("Unable to load items.", "Error");
			}
			finally
			{
				IsBusy = false;
			}
		}

		public Command<string> GoToDetailsCommand { get; }
		//PlantDetailViewModel detailsViewModel;
	}
}
