using System.Collections.Generic;
using System.Data;
using AxGrid = AxFlexCell.AxGrid;

namespace Godzillar.Service
{
    public interface IAdapter
    {
        void SetAdapter_Title(AxGrid axGrid, DataTable dtbl);

        void SetAdapter_Value(AxGrid axGrid, List<DataTable> dtblList);
    }
}