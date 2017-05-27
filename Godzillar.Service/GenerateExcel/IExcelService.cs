using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using AxGrid = AxFlexCell.AxGrid;

namespace Godzillar.Service.GenerateExcel
{
    public interface IExcelService
    {
        void Excel_Loading(AxGrid axGrid);

        void TimelySave();

        string CreateOrder(AxGrid axGrid);
    }
}
