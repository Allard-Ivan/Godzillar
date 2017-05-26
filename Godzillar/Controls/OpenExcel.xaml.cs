using Godzillar.DAO.eyt_xt_order;
using Godzillar.Service;
using Godzillar.Service.GenerateExcel;
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
        private IExcelService excelService = new ExcelService();
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
            excelService.TimelySave();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            axGrid.Rows = 181;
            axGrid.Cols = 51;
            axGrid.DisplayRowIndex = true;
            excelService.Excel_Loading(axGrid);
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
            string result = excelService.CreateOrder(axGrid);
            if (result == "success")
                MessageBox.Show("创建成功", "你真棒");
            else
                MessageBox.Show(result, "要努力哦");
        }

        private void ExcelClose_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Grid).Children.Clear();
        }
    }
}
