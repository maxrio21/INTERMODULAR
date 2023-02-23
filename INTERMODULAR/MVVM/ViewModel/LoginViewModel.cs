using INTERMODULAR.MVVM.Repositories;
using INTERMODULAR.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace INTERMODULAR.MVVM.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        private IUserRepository userRepository;

        public string Username 
        { 
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public SecureString Password 
        { 
            get => _password;
            set 
            {
                _password = value;
                OnPropertyChanged(nameof(Password));

            }
        }

        public string ErrorMessage 
        { 
            get => _errorMessage; 
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));

            }

        }

        public bool IsViewVisible 
        { 
            get => _isViewVisible; 
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));

            }
        }

        //Comandos

        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        public LoginViewModel()
        {
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand(""));
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if(string.IsNullOrEmpty(Username) || Username.Length < 3 || Password == null || Password.Length < 3
            )
            {
                validData = false;
            }
            else
            {
                validData = true;
            }
            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(Username,Password));
            if (isValidUser.Result)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username), null);

                MainView main = new MainView();
                main.Show();

                foreach (Window item in Application.Current.Windows)
                {
                    if (item.DataContext == this)
                    {
                        item.Close();
                    }
                }
            }
            else
            {
                ErrorMessage = "El nombre de usuario o contraseña son incorrectos.";
            }
        }

        private void ExecuteRecoverPassCommand(string email)
        {
            throw new NotImplementedException();
        }
    }
}
