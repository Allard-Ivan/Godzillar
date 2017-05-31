using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Godzillar.Service.Adapter
{
    public interface IListBox
    {
        void SetAdapter(ListBox lst, List<string> list);
    }
}
