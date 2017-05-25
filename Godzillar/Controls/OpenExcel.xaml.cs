using Godzillar.DAO.eyt_xt_order;
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
using AxGrid = AxFlexCell.AxGrid;

namespace Godzillar.Excel
{
    /// <summary>
    /// OpenExcel.xaml 的交互逻辑
    /// </summary>
    public partial class OpenExcel : UserControl
    {
        private readonly string formId;
        private AxGrid axGrid = new AxGrid();
        private IExcelService excelService = new ExcelService();

        public OpenExcel()
        {
            InitializeComponent();
            InsteadOfAxGrid(MainGrid, axGrid);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            axGrid.Rows = 201;
            axGrid.Cols = 51;
            axGrid.DisplayRowIndex = true;
            excelService.Excel_Loading(axGrid);
        }

        /// <summary>
        /// 用 AxGrid 托管 Grid
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="axGrid"></param>
        private void InsteadOfAxGrid(Grid grid, AxGrid axGrid)
        {
            // 固定程序，不用管           
            System.Windows.Forms.Integration.WindowsFormsHost host = new System.Windows.Forms.Integration.WindowsFormsHost();
            host.Child = axGrid;
            grid.Children.Add(host);
        }
    }
}
