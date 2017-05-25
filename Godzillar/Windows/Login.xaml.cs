using Godzillar.Service;
using Godzillar.Service.User;
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

namespace Godzillar.Windows
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        private IUserService userService = new UserService();

        public Login()
        {
            InitializeComponent();
            Username.Focus();
        }

        private void Determine_Click(object sender, RoutedEventArgs e)
        {
            string result = userService.ValidateUser(Username.Text, Password.Password);
            if (result == "success")
            {
                this.Hide();
                new MainWindow().Show();
            }
            else
                MessageBox.Show(result, "错误提示");
        }

        #region Any shutdown
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
        #endregion
    }
}
