using Godzillar.DAO.eyt_xt_order;
using Godzillar.Service.Adapter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using AxGird = AxFlexCell.AxGrid;

namespace Godzillar.Service.GenerateExcel
{
    public class ExcelService : IExcelService
    {
        private Tab_task_form_value task_form_value = new Tab_task_form_value();
        private Tab_form_item form_item = new Tab_form_item();
        private Tab_task task = new Tab_task();
        private IAdapter adapter = new IAxFlexCell();

        public async void Excel_Loading(AxGird axGrid)
        {
            DataTable dtblItem = form_item.SelectItemByFormId();
            if (dtblItem.Rows.Count == 0)
                return;

            adapter.SetAdapter_Title(axGrid, dtblItem);

            DataTable dtblExcelValue = await SampleMethodTaskAsync();
            adapter.SetAdapter_Value(axGrid, dtblExcelValue);
        }

        private async Task<DataTable> SampleMethodTaskAsync()
        {
            return await Task<DataTable>.Factory.StartNew(() =>
            {
                return task_form_value.SelectExcelDataByFormId();
            });
        }

    }
}
