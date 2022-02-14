using Practice3_01.Entities;
using Practice3_01.Utilities;
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

namespace Practice3_01.UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuUser.xaml
    /// </summary>
    public partial class MenuUser : Page
    {
        private User menuUser;

        public MenuUser(User transferUser)
        {
            InitializeComponent();

            menuUser = transferUser;

            WelcomeBlock.Text = $"Добро пожаловать, {menuUser?.Fullname}!";

            this.Title = $"Меню {menuUser?.Role.Name}";
        }

        /// <summary>
        /// Переход на страницу Registration, служабщая для регистрации новых пользователей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            Transition.MainFrame.Navigate(new Registration());
        }

        private void DataUserView_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Transition.MainFrame.GoBack();
        }
    }
}
