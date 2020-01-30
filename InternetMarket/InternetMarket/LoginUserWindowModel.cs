using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace InternetMarket
{
    public class LoginUserWindowModel : ViewModelBase
    {
        public ICommand RegisterCommand { get; set; }
        private InterMarketService marketService;
        public LoginUserWindowModel()
        {
            RegisterCommand = new RelayCommand(RegisterCommandExecute, RegisterCommandCanExecute);
            marketService = new InterMarketService();
        }

        private bool RegisterCommandCanExecute(object obj)
        {
            if (!string.IsNullOrEmpty(User))
                return true;
            return false;
        }

        private string _user;

        public string User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private void RegisterCommandExecute(object obj)
        {
            try
            {
                List<string> pass = marketService.GetUsers();
                if (pass.Contains(Password))
                {
                    new MainWindow(marketService).Show();
                }
                else
                {
                    MessageBox.Show("Неверный пароль", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (NotSupportedException)
            {
                MessageBoxResult result = MessageBox.Show("Выберите пользователя", "Error", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    //this.Close();
                }

            }
            catch (NullReferenceException)
            {
                MessageBoxResult result = MessageBox.Show("Ведите пароль", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    //this.Close();
                }
            }
            catch (Exception)
            {
                MessageBoxResult result = MessageBox.Show("Не удалось войти в систему", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    //this.Close();
                }
            }
        }
    }
}
