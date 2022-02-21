using Practice3_01.UI.Pages;
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

namespace Practice3_01
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Конструктор окна MainWindow

        public MainWindow()
        {
            InitializeComponent();

            MainFrame.Navigate(new Authorization());
            Transition.MainFrame = MainFrame;
        }

        #endregion

        #region Навигация по страницам в обратном направлении

        /// <summary>
        /// Проверка возможности перехода на предыдущую страницу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (Transition.MainFrame.CanGoBack && !Transition.MainFrame.Content.ToString().Contains("MenuUser"))
                BackBtn.Visibility = Visibility.Visible;
            else
                BackBtn.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Переход на предыдущую страницу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Transition.MainFrame.GoBack();
        }

        #endregion
    }
}
