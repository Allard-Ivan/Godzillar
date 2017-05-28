using Godzillar.DAO.eyt_xt_order;
using Godzillar.OSDB.Modles;
using Godzillar.Service.Adapter;
using Godzillar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Godzillar.Dialogs
{
    /// <summary>
    /// CellWidthDialog.xaml 的交互逻辑
    /// </summary>
    public partial class CellWidthDialog : Window
    {
        private readonly List<string> itemCNList;

        private IComboBox _iCombobox = new ZComboBox();

        private Tab_form_item _form_item = new Tab_form_item();

        public CellWidthDialog(List<string> itemCNList)
        {
            InitializeComponent();
            this.itemCNList = itemCNList;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _iCombobox.SetAdapter(ColumnName, itemCNList);
        }

        private void Determine_Click(object sender, RoutedEventArgs e)
        {
            string id = ((GenericControl)ColumnName.SelectedItem).Id;
            string width = WidthValue.Text;
            if (id == null || width == "")
                return;
            else if (!Regex.IsMatch(width, @"^[0-9]\d*$"))
            {
                MessageBox.Show("宽度只能是正整数", "Oh my God!");
                return;
            }

            _form_item.UpdateItemWidth(Constants.ItemList[Convert.ToInt32(id)], width);
            this.Tag = id + "," + width;
            this.DialogResult = true;
            this.Close();
        }

    }
}
