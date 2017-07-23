using System;
using UIKit;

namespace waterPlants.iOS
{
    public partial class BrowseItemDetailViewController : UIViewController
    {
        public PlantDetailViewModel ViewModel { get; set; }
        public BrowseItemDetailViewController(IntPtr handle) : base(handle) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = ViewModel.Title;
            ItemNameLabel.Text = ViewModel.Plant.PlantName;
            ItemDescriptionLabel.Text = ViewModel.Plant.Description;
        }
    }
}
