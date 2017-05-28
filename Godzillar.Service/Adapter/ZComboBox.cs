using Godzillar.OSDB.Modles;
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
        public void SetAdapter(ComboBox cbo, List<string> list)
        {
            cbo.Items.Clear();
            cbo.Items.Add(new GenericControl(null, "请选择列名"));
            for (int i = 0; i < list.Count; i++)
            {
                cbo.Items.Add(new GenericControl(i.ToString(), list[i]));
            }
            cbo.DisplayMemberPath = "Content";
            cbo.SelectedIndex = 0;
        }
    }
}
