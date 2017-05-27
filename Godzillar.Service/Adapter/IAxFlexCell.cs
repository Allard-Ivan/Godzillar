using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxFlexCell;
using Godzillar.Utils;
using Godzillar.DAO.eyt_xt_order;

namespace Godzillar.Service.Adapter
{
    public class IAxFlexCell : IAdapter
    {
        private Tab_task_form_value task_form_value = new Tab_task_form_value();

        public void SetAdapter_Title(AxGrid axGrid, DataTable dtbl)
        {
            axGrid.CellChange -= AxGrid_CellChange;
            Constants.ItemList.Clear();
            axGrid.Column(1).Width = 100;
            axGrid.Column(2).Width = 170;
            axGrid.Cell(0, 1).Text = "订单 ID";
            axGrid.Cell(0, 2).Text = "创建时间";
            for (int i = 0; i < dtbl.Rows.Count; i++)
            {
                axGrid.Column(i + 3).Width = Convert.ToInt32(dtbl.Rows[i][2]);
                axGrid.Cell(0, i + 3).Text = Convert.ToString(dtbl.Rows[i][1]);
                Constants.ItemList.Add(Convert.ToString(dtbl.Rows[i][0]));
            }
            Constants.ExcelCols = Constants.ItemList.Count + 3;
        }

        public void SetAdapter_Value(AxGrid axGrid, DataTable dtbl)
        {
            Constants.TaskList.Clear();
            int count = dtbl.Rows.Count;
            if (count == 0)
                return;
            else if (count > 3000)
                axGrid.Rows = 251;
            else if (count > 4000)
                axGrid.Rows = 301;
            else if (count > 5000)
                axGrid.Rows = 351;
            else if (count > 6000)
                axGrid.Rows = 401;
            else if (count > 7000)
                axGrid.Rows = 451;
            else if (count > 8000)
                axGrid.Rows = 501;
            else if (count > 10000)
                axGrid.Rows = 701;
            else if (count > 15000)
                axGrid.Rows = 1000;

            string taskId = "";
            int initCol = 3, initRow = 0;

            foreach (DataRow row in dtbl.Rows)
            {
                if (taskId != Convert.ToString(row[0]))
                {
                    ++initRow;
                    taskId = Convert.ToString(row[0]);
                    axGrid.Cell(initRow, 1).Text = Convert.ToString(row[1]);
                    axGrid.Cell(initRow, 2).Text = Convert.ToString(row[2]);
                    initCol = 3;
                    Constants.TaskList.Add(taskId);
                }
                axGrid.Cell(initRow, initCol).Text = Convert.ToString(row[4]);
                ++initCol;
            }
            Constants.ExcelRows = Constants.TaskList.Count + 1;

            axGrid.CellChange += AxGrid_CellChange;
        }

        private void AxGrid_CellChange(object sender, __Grid_CellChangeEvent e)
        {
            int currentRow = e.row, currentCol = e.col;
            if (currentCol < 3 || currentRow >= Constants.ExcelRows || currentCol >= Constants.ExcelCols)
                return;

            string coordinate = (currentRow.ToString() + "," + currentCol.ToString());
            string taskId = Convert.ToString(Constants.TaskList[currentRow - 1]);
            string itemId = Convert.ToString(Constants.ItemList[currentCol - 3]);
            string itemValue = (sender as AxGrid).Cell(currentRow, currentCol).Text;
            string sql = "UPDATE tab_task_form_value SET formitemvalue = '" + itemValue + "' WHERE formid = " + Constants.FormId + " AND taskid = '" + taskId + "' AND formitemid = '" + itemId + "'";
            if (Constants.SqlDictionary.ContainsKey(coordinate))
            {
                Constants.SqlDictionary[coordinate] = sql;
            }
            else
            {
                Constants.SqlDictionary.Add(coordinate, sql);
            }
        }
    }
}
