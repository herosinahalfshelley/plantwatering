namespace waterPlants //namespace - a way to group code together
{
    public class Item : BaseDataObject //classes have data, data have different levels of access
    {
        public Item() : base()
        {
        }

        /// <summary>
        /// Private backing field to hold the text
        /// </summary>
        string text = string.Empty; //text here is a member variable, a member of the class item

        /// <summary>
        /// Public property to set and get the text of the item
        /// </summary>
        public string Text //Text here is called a property
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }

        string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }
    }
}
