using Godzillar.DAO.eyt_erp;
using Godzillar.DAO.eyt_xt_order;
using Godzillar.Service.Adapter;
using Godzillar.Utils;
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
        private IAxFlexCell _adapter = new ZAxFlexCell();

        private Tab_dic_transport_type dic_transport_type = new Tab_dic_transport_type();
        private Tab_windows_version windows_version = new Tab_windows_version();
        private Tab_task_form_value task_form_value = new Tab_task_form_value();
        private Tab_order_cost_in order_cost_in = new Tab_order_cost_in();
        private Tab_order_cost order_cost = new Tab_order_cost();
        private Tab_task_confirm task_confirm = new Tab_task_confirm();
        private Tab_form_item form_item = new Tab_form_item();
        private Tab_order order = new Tab_order();
        private Tab_task task = new Tab_task();

        private async Task<DataTable> SampleMethodTaskAsync()
        {
            return await Task<DataTable>.Factory.StartNew(() =>
            {
                return task_form_value.SelectExcelDataByFormId();
            });
        }

        public async void Excel_Loading(AxGird axGrid)
        {
            DataTable dtblItem = form_item.SelectItemByFormId();
            if (dtblItem.Rows.Count == 0)
                return;

            _adapter.SetAdapter_Title(axGrid, dtblItem);

            DataTable dtblExcelValue = await SampleMethodTaskAsync();
            _adapter.SetAdapter_Value(axGrid, dtblExcelValue);
        }

        public void TimelySave()
        {
            foreach (KeyValuePair<string, string> entry in Constants.SqlDictionary)
            {
                task_form_value.UpdateExcelData(entry.Value);

            }
            Constants.SqlDictionary.Clear();
        }

        public string CreateOrder(AxGird axGrid)
        {
            if (axGrid.Cell(Constants.ExcelRows, 1).Text.Equals(""))
                return "请先输入订单号";

            string isOrder = Convert.ToString(windows_version.SelectIsOrder().Rows[0][0]);
            string transportId = Convert.ToString(dic_transport_type.SelectTransport().Rows[0][0]);
            string orderId = "", taskId = "";

            for (int i = Constants.ExcelRows; i < axGrid.Rows; i++)
            {
                orderId = axGrid.Cell(i, 1).Text;
                if (orderId == "")
                    break;
                if (task.GetIsOrderId(orderId).Rows.Count != 0)
                    return "订单号重复，请重新输入";
                taskId = Constants.GetTimeStamp();

                order_cost.InsertPay(orderId);
                order_cost_in.InsertIn(orderId);
                task_confirm.InsertConfirm(taskId);
                order.InsertTabOrder(orderId, transportId, isOrder);
                task.InsertTabTask(taskId, orderId);

                for (int j = 0; j < Constants.ItemList.Count; j++)
                {
                    task_form_value.InsertExcelValue(taskId, Constants.ItemList[j], axGrid.Cell(i, j + 3).Text);
                }
            }
            return "success";
        }

        public void FilterGrid(AxGird axGrid, List<string> filterList, int selectedCol)
        {
            for (int i = 1; i < Constants.ExcelRows; i++)
            {
                if (!filterList.Contains(axGrid.Cell(i, selectedCol).Text))
                {
                    axGrid.set_RowHeight(i, 0);
                }
            }
        }

        public void RecoverGrid(AxGird axGrid)
        {
            for (int i = 1; i < Constants.ExcelRows; i++)
            {
                axGrid.set_RowHeight(i, Constants.GridRowHeight);
            }
        }
    }
}
