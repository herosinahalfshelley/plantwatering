using System;
using System.Threading.Tasks;
using waterPlants.Models;
using waterPlants.ViewModels;
using UIKit;

namespace waterPlants.iOS
{
    public partial class PlantNewViewController : UIViewController
    {
        public Plant Plant { get; set; }
        public PlantViewModel viewModel { get; set; }
        public BaseViewModel baseModel { get; set; }

        public PlantNewViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            btnSavePlant.TouchUpInside += (sender, e) =>
            {
                var _item = new Plant();
                _item.PlantName = txtTitle.Text;
                _item.Description = txtDesc.Text;
                MessagingCenter.Send(this, "AddPlant", _item);
                NavigationController.PopToRootViewController(true);
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
