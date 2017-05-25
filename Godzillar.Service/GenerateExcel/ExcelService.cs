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
        private Tab_form_item form_item = new Tab_form_item();
        private Tab_task task = new Tab_task();
        private IAdapter adapter = new IAxFlexCell();

        public async void Excel_Loading(AxGird axGrid)
        {
            DataTable dtblItem = form_item.SelectItemByFormId();
            if (dtblItem.Rows.Count == 0)
                return;

            adapter.SetAdapter_Title(axGrid, dtblItem);

            List<DataTable> dtblList = await SampleMethodTaskAsync();
            adapter.SetAdapter_Value(axGrid, dtblList);
        }

        private async Task<List<DataTable>> SampleMethodTaskAsync()
        {
            return await Task<List<DataTable>>.Factory.StartNew(() =>
            {
                List<DataTable> list = new List<DataTable>();
                list.Add(task.SelectOrderTaskByFormId());
                list.Add(form_item.SelectValueByFormId());
                return list;
            });
        }

    }
}
