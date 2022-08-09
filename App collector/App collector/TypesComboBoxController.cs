using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_collector
{
    internal class TypesComboBoxController
    {
        internal static void LoadTypes()
        {
            List<string> types = SavingController.GetTypes().ToList();
            foreach(string type in types)
            {
                MainWindow.TypesComboBoxGetter.Items.Add(ComboBoxItemGenerator.GenerateTextBlock(type));
            }
        }

        internal static bool UpdateTypes(string type)
        {
            List<string> types = SavingController.GetTypes().ToList();
            if (!types.Contains(type))
            {
                MainWindow.TypesComboBoxGetter.Items.Add(ComboBoxItemGenerator.GenerateTextBlock(type));
                return true;
            }
            return false;
        }
    }
}
