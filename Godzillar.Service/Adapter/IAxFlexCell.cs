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
        private List<string> taskList = new List<string>();
        private List<string> itemList = new List<string>();
        private int excelRows = 1;
        private int excelCols = 1;
        private Tab_task_form_value task_form_value = new Tab_task_form_value();

        public void SetAdapter_Title(AxGrid axGrid, DataTable dtbl)
        {
            axGrid.Column(1).Width = 100;
            axGrid.Column(2).Width = 170;
            axGrid.Cell(0, 1).Text = "订单 ID";
            axGrid.Cell(0, 2).Text = "创建时间";
            for (int i = 0; i < dtbl.Rows.Count; i++)
            {
                axGrid.Column(i + 3).Width = Convert.ToInt32(dtbl.Rows[i][2]);
                axGrid.Cell(0, i + 3).Text = Convert.ToString(dtbl.Rows[i][1]);
                itemList.Add(Convert.ToString(dtbl.Rows[i][1]));
            }
            excelCols = itemList.Count;
        }

        public void SetAdapter_Value(AxGrid axGrid, DataTable dtbl)
        {
            if (dtbl.Rows.Count == 0)
                return;

            string taskId = "", foreColor = "", backColor = "";
            int initCol = 3, initRow = 0;

            foreach (DataRow row in dtbl.Rows)
            {
                if (taskId != Convert.ToString(row[0]))
                {
                    ++initRow;
                    taskId = Convert.ToString(row[0]);
                    axGrid.Cell(initRow, 1).Text = Convert.ToString(row[1]);
                    axGrid.Cell(initRow, 2).Text = Convert.ToString(row[2]);
                    axGrid.Cell(initRow, 1).Locked = true;
                    axGrid.Cell(initRow, 2).Locked = true;
                    initCol = 3;
                    taskList.Add(taskId);
                }
                axGrid.Cell(initRow, initCol).Text = Convert.ToString(row[4]);

                foreColor = Convert.ToString(row["forecolor"]);
                backColor = Convert.ToString(row["backcolor"]);
                if (!foreColor.Equals(""))
                    axGrid.Cell(initRow, initCol).ForeColor = Convert.ToUInt32(foreColor);
                if (!backColor.Equals(""))
                    axGrid.Cell(initRow, initCol).BackColor = Convert.ToUInt32(backColor);
                ++initCol;
            }
            excelRows = taskList.Count;
            axGrid.CellChange += AxGrid_CellChange;
        }

        private void AxGrid_CellChange(object sender, __Grid_CellChangeEvent e)
        {
            AxGrid axGrid = (AxGrid)sender;
            int currentRow = e.row, currentCol = e.col;
            if (currentCol < 3 || currentRow >= excelRows || currentCol >= excelCols)
                return;

            string coordinate = (currentRow.ToString() + currentCol.ToString());
            string taskId = Convert.ToString(taskList[currentRow - 1]);
            string itemId = Convert.ToString(itemList[currentCol - 3]);
            string itemValue = axGrid.Cell(currentRow, currentCol).Text;
            string sql = "UPDATE tab_task_form_value SET formitemvalue = '" + itemValue + "', foreColor=" + axGrid.Cell(currentRow, currentCol).ForeColor + ",backcolor=" + axGrid.Cell(currentRow, currentCol).BackColor + " WHERE formid = " + Constants.FormId + " AND taskid = '" + taskId + "' AND formitemid = '" + itemId + "'";
            if (Constants.SqlDictionary.ContainsKey(coordinate))
            {
                Constants.SqlDictionary[coordinate] = sql;
            }
            else
            {
                Constants.SqlDictionary.Add(coordinate, sql);
            }
        }

        public void TimelySave()
        {
            foreach (KeyValuePair<string, string> entry in Constants.SqlDictionary)
            {
                task_form_value.UpdateExcelData(entry.Value);

            }
            Constants.SqlDictionary.Clear();
        }

    }
}
