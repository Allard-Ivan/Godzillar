using Godzillar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Godzillar.Service.Adapter
{
    public class ZComboBox : IComboBox
    {
        public void SetAdapter(ComboBox cbo)
        {
            cbo.Items.Clear();
            if (Constants.ItemList.Count > 0)
            {
                
            }
        }
    }
}
