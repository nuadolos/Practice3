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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        private int tryEntry;
        private TimerUpdate timer;

        /// <summary>
        /// Конструктор страницы Authorization
        /// </summary>
        public Authorization()
        {
            InitializeComponent();

            timer = new TimerUpdate();
            timer.TimerMethod(InputBlocking);

            tryEntry = 3;
        }

        #region Авторизация пользователя

        /// <summary>
        /// Переход на страницу MenuUser при правильно введенных данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EntryBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(LogTBox.Text))
                error.AppendLine("Укажите логин");
            if (string.IsNullOrWhiteSpace(PasPBox.Password))
                error.AppendLine("Укажите пароль");

            if (error.Length > 0)
            {
                MessageBox.Show($"Вход не может быть реализован:\n{error}",
                    "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            User user = Transition.Context.User.FirstOrDefault(u => u.Login == LogTBox.Text && u.Password == PasPBox.Password);

            if (user != null)
            {
                Transition.MainFrame.Navigate(new MenuUser(user));
            }
            else
            {
                MessageBox.Show($"Логин или пароль введены неверно\nКоличество оставшихся попыток: {--tryEntry}",
                   "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                if (tryEntry == 0)
                {
                    timer.StartUpdate();

                    TimerBlocking.Visibility = Visibility.Visible;
                    LogTBox.IsEnabled = false;
                    PasPBox.IsEnabled = false;
                    EntryBtn.IsEnabled = false;
                }
            }
        }

        /// <summary>
        /// Метод, блокирующий на 5 секунд повторную авторизацию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputBlocking(object sender, EventArgs e)
        {
            TimerBlocking.Text = $"Осталось {(timer.TimeStartBlock - DateTime.Now).Seconds} секунд!";

            if (timer.TimeStartBlock < DateTime.Now)
            {
                LogTBox.IsEnabled = true;
                PasPBox.IsEnabled = true;
                EntryBtn.IsEnabled = true;

                TimerBlocking.Visibility = Visibility.Collapsed;
                tryEntry = 3;
                timer.StopUpdate();
            }
        }

        #endregion

        /// <summary>
        /// Закрытие приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseAppBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
