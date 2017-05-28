using AxFlexCell;
using System.Data;

namespace Godzillar.Service.Adapter
{
    interface IAxFlexCell
    {
        void SetAdapter_Title(AxGrid axGrid, DataTable dtbl);

        void SetAdapter_Value(AxGrid axGrid, DataTable dtbl);
    }
}
