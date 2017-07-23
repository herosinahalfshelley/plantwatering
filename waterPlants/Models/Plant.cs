using System;
namespace waterPlants.Models
{
    public class Plant : BaseDataObject
    {
		/*
            * nickname
			* description
			* picture
			* isIndoor
		*/

		string plantName = string.Empty;
        public string PlantName
		{
			get { return plantName; }
			set { SetProperty(ref plantName, value); }
		}

		string description = string.Empty;
		public string Description
		{
			get { return description; }
			set { SetProperty(ref description, value); }
		}

        bool isIndoor = true;
        public bool IsIndoor
		{
            get { return isIndoor; }
            set { SetProperty(ref isIndoor, value); }
		}

        public Plant(): base()
        {
        }
    }
}
