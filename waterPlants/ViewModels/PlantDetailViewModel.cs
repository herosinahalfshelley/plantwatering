using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using waterPlants.Models;

namespace waterPlants
{
    public class PlantDetailViewModel : BaseViewModel
    {
        public Plant Plant { get; set; }
        public PlantDetailViewModel(Plant item = null)
        {
            if (item != null)
            {
                Title = item.PlantName;
                Plant = item;
            }
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
    }
}
