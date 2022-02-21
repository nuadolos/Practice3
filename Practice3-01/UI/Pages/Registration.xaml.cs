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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        #region Закрытые поля страницы Registration

        private User createUser;

        #endregion

        #region Конструктор страницы Registration

        public Registration()
        {
            InitializeComponent();

            createUser = new User();

            RoleCBox.ItemsSource = Transition.Context.Role.ToList();

            DataContext = createUser;
        }

        #endregion

        #region Создание новой учетной записи

        private void SaveUserBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(createUser.Login))
                error.AppendLine("Укажите логин");
            if (createUser.Password.Length < 6)
                error.AppendLine("Укажите корректно пароль");
            if (createUser.Password != RePasTBox.Text)
                error.AppendLine("Пароли должны совпадать");
            if (string.IsNullOrWhiteSpace(createUser.Fullname))
                error.AppendLine("Укажите ФИО");
            if (createUser.Role == null)
                error.AppendLine("Выберите роль");

            if (error.Length > 0)
            {
                MessageBox.Show($"Данные не соответствует следующим критериям:\n{error}",
                    "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Transition.Context.User.Add(createUser);

            try
            {
                Transition.Context.SaveChanges();
                MessageBox.Show("Новый пользователь создан",
                    "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
                Transition.MainFrame.GoBack();
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show($"При создании нового пользователя возникла ошибка:\n{ex.Message}",
                    "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        #region Визуальная подсказка для пользователя

        /// <summary>
        /// Отображение подсказки при введенном пароле
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasTBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PasTBox.Text.Length > 5)
            {
                PasTBox.BorderBrush = Brushes.LimeGreen;
                PasTBox.ToolTip = null;
            }
            else
            {
                PasTBox.BorderBrush = Brushes.Red;
                PasTBox.ToolTip = "Пароль должен быть не менее 6 символов";
            }

            PasTBox.Focus();
        }

        #endregion
    }
}
