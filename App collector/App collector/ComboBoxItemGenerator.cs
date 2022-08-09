namespace App_collector
{
    internal class ComboBoxItemGenerator
    {
        internal static ComboBoxItem GenerateTextBlock(string type)
        {
            ComboBoxItem item = new ComboBoxItem();
            item.Content = type;
            return item;
        }
    }
}
