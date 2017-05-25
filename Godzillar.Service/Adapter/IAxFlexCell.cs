using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxFlexCell;

namespace Godzillar.Service.Adapter
{
    public class IAxFlexCell : IAdapter
    {
        public void SetAdapter_Title(AxGrid axGrid, DataTable dtbl)
        {
            axGrid.Column(1).Width = 100;
            axGrid.Column(2).Width = 100;
            axGrid.Cell(0, 1).Text = "订单 ID";
            axGrid.Cell(0, 2).Text = "创建时间";
            for (int i = 0; i < dtbl.Rows.Count; i++)
            {
                axGrid.Column(i + 3).Width = Convert.ToInt32(dtbl.Rows[i][2]);
                axGrid.Cell(0, i + 3).Text = Convert.ToString(dtbl.Rows[i][1]);
            }
        }

        public void SetAdapter_Value(AxGrid axGrid, List<DataTable> dtblList)
        {
            DataTable dtblOrderTask = dtblList[0];
            DataTable dtblValue = dtblList[1];

            if (dtblOrderTask.Rows.Count == 0)
                return;

            string taskId = "", foreColor = "", backColor = "";
            int coCo = 0;

            for (int i = 0; i < dtblOrderTask.Rows.Count; i++)
            {
                taskId = Convert.ToString(dtblOrderTask.Rows[0][0]);
                axGrid.Cell(i + 1, 1).Text = Convert.ToString(dtblOrderTask.Rows[i][1]);
                axGrid.Cell(i + 1, 2).Text = Convert.ToString(dtblOrderTask.Rows[i][2]);
                axGrid.Cell(i + 1, 1).Locked = true;
                axGrid.Cell(i + 1, 2).Locked = true;
                for (int j = 0; j < dtblValue.Rows.Count; j++)
                {
                    if (Convert.ToString(dtblValue.Rows[j][2]).Equals(taskId))
                    {
                        axGrid.Cell(i + 1, j + 3).Text = Convert.ToString(dtblValue.Rows[coCo][1]);

                        foreColor = Convert.ToString(dtblValue.Rows[coCo]["forecolor"]);
                        backColor = Convert.ToString(dtblValue.Rows[coCo]["backcolor"]);
                        if (!foreColor.Equals(""))
                        {
                            axGrid.Cell(i + 1, j + 3).ForeColor = Convert.ToUInt32(foreColor);
                        }
                        if (!backColor.Equals(""))
                        {
                            axGrid.Cell(i + 1, j + 3).BackColor = Convert.ToUInt32(backColor);
                        }
                        ++coCo;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
