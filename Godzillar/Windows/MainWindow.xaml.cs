using Godzillar.DAO.eyt_xt_order;
using Godzillar.Excel;
using Godzillar.Utils;
using Godzillar.Windows;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Godzillar
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private Tab_windows_version tab_windows_version = new Tab_windows_version();

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FormToolBar_Loading();
        }

        private void FormToolBar_Loading()
        {
            FormItem.Items.Clear();
            DataTable dtblFormItem = null;
            string menuItemTemp = "";
            MenuItem menuItem = null, menuItemChild = null;

            if (Constants.Power != "0")
            {
                dtblFormItem = tab_windows_version.SelectFormItem_Admin();
            } else
            {

            }

            foreach (DataRow row in dtblFormItem.Rows)
            {
                if (menuItemTemp != Convert.ToString(row[0]))
                {
                    menuItemTemp = Convert.ToString(row[0]);
                    menuItem = new MenuItem();
                    menuItem.Header = row[0];
                    FormItem.Items.Add(menuItem);
                }
                menuItemChild = new MenuItem();
                menuItemChild.Header = Convert.ToString(row[1]);
                menuItemChild.Tag = Convert.ToString(row[2]);
                menuItemChild.Click += MenuItemChild_Click;
                menuItem.Items.Add(menuItemChild);
            }
        }

        private void MenuItemChild_Click(object sender, RoutedEventArgs e)
        {
            InitExcel.Children.Clear();
            Constants.FormId = (sender as MenuItem).Tag.ToString();
            OpenExcel openExcel = new OpenExcel();
            InitExcel.Children.Add(openExcel);
        }

        #region Any shutdown
        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        #endregion


    }
}
