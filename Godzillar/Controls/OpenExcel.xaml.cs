using Godzillar.DAO.eyt_xt_order;
using Godzillar.Dialogs;
using Godzillar.Service;
using Godzillar.Service.GenerateExcel;
using Godzillar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using AxGrid = AxFlexCell.AxGrid;

namespace Godzillar.Excel
{
    /// <summary>
    /// OpenExcel.xaml 的交互逻辑
    /// </summary>
    public partial class OpenExcel : UserControl
    {
        private AxGrid axGrid = new AxGrid();
        private IExcelService _excelService = new ExcelService();
        private DispatcherTimer dispatcherTime;

        public OpenExcel()
        {
            InitializeComponent();
            dispatcherTime = new DispatcherTimer();
            dispatcherTime.Interval = new TimeSpan(0, 0, 3);
            dispatcherTime.Tick += DispatcherTime_Tick;
            InsteadOfAxGrid(MainGrid, axGrid);
        }

        private void DispatcherTime_Tick(object sender, EventArgs e)
        {
            _excelService.TimelySave();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            axGrid.Rows = 181;
            axGrid.Cols = 51;
            axGrid.DisplayRowIndex = true;
            axGrid.GridColor = System.Drawing.Color.Black;
            axGrid.DefaultRowHeight = Constants.GridRowHeight;
            _excelService.Excel_Loading(axGrid);
            dispatcherTime.Start();
        }

        #region AxGrid 托管 Grid
        private void InsteadOfAxGrid(Grid grid, AxGrid axGrid)
        {
            // 固定程序，不用管           
            System.Windows.Forms.Integration.WindowsFormsHost host = new System.Windows.Forms.Integration.WindowsFormsHost();
            host.Child = axGrid;
            grid.Children.Add(host);
        }
        #endregion

        private void CreateOrder_Click(object sender, RoutedEventArgs e)
        {
            string result = _excelService.CreateOrder(axGrid);
            if (result == "success")
            {
                MessageBox.Show("创建成功", "你真棒");
                _excelService.Excel_Loading(axGrid);

            }
            else if (result == "请先输入订单号")
            {
                MessageBox.Show(result, "要努力哦");
            }
            else
            {
                MessageBox.Show(result, "要努力哦");
                _excelService.Excel_Loading(axGrid);
            }
        }

        private void ExcelClose_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Grid).Children.Clear();
        }

        /// <summary>
        /// 清除内容按钮 - 点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearText_Click(object sender, RoutedEventArgs e)
        {
            axGrid.Selection.ClearText();
        }

        /// <summary>
        /// 列宽按钮 - 点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CellWidth_Click(object sender, RoutedEventArgs e)
        {
            List<string> itemCNList = new List<string>();
            for (int i = 3; i < Constants.ExcelCols; i++)
            {
                itemCNList.Add(axGrid.Cell(0, i).Text);
            }
            CellWidthDialog cellWidthDialog = new CellWidthDialog(itemCNList);
            bool dialogResult = Convert.ToBoolean(cellWidthDialog.ShowDialog());
            if (dialogResult)
            {
                string[] value = Convert.ToString(cellWidthDialog.Tag).Split(',');
                axGrid.Column(Convert.ToInt32(value[0]) + 3).Width = Convert.ToInt32(value[1]);
            }
        }

        private void FilterBorder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string content = Convert.ToString(((ComboBoxItem)FilterBorder.SelectedItem).Content);
            switch (content)
            {
                case "新建筛选":
                    FilterBorder.SelectedIndex = 0;
                    int selectedCol = axGrid.Selection.FirstCol;
                    if (selectedCol == -1 || selectedCol > Constants.ExcelCols)
                        return;

                    List<string> list = new List<string>();
                    string item = "";
                    for (int i = 1; i <= Constants.ExcelRows; i++)
                    {
                        item = axGrid.Cell(i, selectedCol).Text;
                        if (!list.Contains(item) && item != "")
                            list.Add(item);
                    }
                    FilterDialog filterDialog =  new FilterDialog(list);
                    if (Convert.ToBoolean(filterDialog.ShowDialog()))
                    {
                        List<string> filterList = (List<string>)filterDialog.Tag;
                        _excelService.FilterGrid(axGrid, filterList, selectedCol);
                    }
                    break;
                case "删除筛选":
                    FilterBorder.SelectedIndex = 0;
                    _excelService.RecoverGrid(axGrid);
                    ToolBarFoo.Focus();
                    break;
                default:
                    break;
            }
        }

    }
}
