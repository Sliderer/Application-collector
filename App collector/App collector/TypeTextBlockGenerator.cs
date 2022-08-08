namespace App_collector
{
    internal class TypeTextBlockGenerator
    {
        internal static TextBlock GenerateTextBlock(string type)
        {
            TextBlock textblock = new TextBlock();
            textblock.Text = type;
            return textblock;
        }
    }
}
