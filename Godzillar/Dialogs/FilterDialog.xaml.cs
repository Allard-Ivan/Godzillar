using Godzillar.Service.Adapter;
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
using System.Windows.Shapes;

namespace Godzillar.Dialogs
{
    /// <summary>
    /// FilterDialog.xaml 的交互逻辑
    /// </summary>
    public partial class FilterDialog : Window
    {
        private readonly List<string> list;

        private IListBox _iListBox = new ZListBox();

        public FilterDialog(List<string> list)
        {
            InitializeComponent();
            this.list = list;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetAdapter();
        }

        public void SetAdapter()
        {
            DistinctValueList.Items.Clear();
            if (list.Count == 0)
                return;

            int listIndex = 0;

            CheckBox chkSelectAll = new CheckBox();
            chkSelectAll.Content = "全选";
            chkSelectAll.IsChecked = true;
            chkSelectAll.Tag = listIndex;
            chkSelectAll.Click += ChkSelectAll_Click;
            DistinctValueList.Items.Add(chkSelectAll);

            foreach (string str in list)
            {
                ++listIndex;
                CheckBox chk = new CheckBox();
                chk.Content = str;
                chk.IsChecked = true;
                chk.Tag = listIndex;
                chk.Click += Chk_Click;
                DistinctValueList.Items.Add(chk);
            }
        }

        private void ChkSelectAll_Click(object sender, RoutedEventArgs e)
        {
            SelectAll(Convert.ToBoolean(((CheckBox)DistinctValueList.Items[0]).IsChecked));
        }

        private void SelectAll(bool isSelectAll)
        {
            for (int i = 1; i < DistinctValueList.Items.Count; i++)
            {
                CheckBox chk = (CheckBox)DistinctValueList.Items[i];
                chk.IsChecked = isSelectAll;
            }
        }

        private void Chk_Click(object sender, RoutedEventArgs e)
        {
            CheckBox chkCurrent = sender as CheckBox;
            ((ListBox)chkCurrent.Parent).SelectedIndex = Convert.ToInt32(chkCurrent.Tag);

            CheckBox chkSelectAll = (CheckBox)DistinctValueList.Items[0];
            bool selectAll = true;
            for (int i = 1; i < DistinctValueList.Items.Count; i++)
            {
                CheckBox chk = (CheckBox)DistinctValueList.Items[i];
                if (!Convert.ToBoolean(chk.IsChecked))
                {
                    selectAll = false;
                    break;
                }
            }
            chkSelectAll.IsChecked = selectAll;
        }

        private void Determine_Click(object sender, RoutedEventArgs e)
        {
            if (list.Count == 0)
                return;
            else if (Convert.ToBoolean(((CheckBox)DistinctValueList.Items[0]).IsChecked))
                return;

            List<string> filterList = new List<string>();
            for (int i = 1; i < DistinctValueList.Items.Count; i++)
            {
                CheckBox chk = (CheckBox)DistinctValueList.Items[i];
                if (Convert.ToBoolean((chk.IsChecked)))
                {
                    filterList.Add(chk.Content.ToString());
                }
            }
            this.Tag = filterList;
            this.DialogResult = true;
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
