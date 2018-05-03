using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Navigation.Pages.Help;
using Navigation.Pages.Home;
using Navigation.Pages.Login;

namespace Navigation
{
    public class MainViewModel : ViewModelBase
    {
        private readonly HomeViewModel _homeViewModel = new HomeViewModel();
        private readonly LoginViewModel _loginViewModel = new LoginViewModel();
        private readonly HelpViewModel _helpViewModel = new HelpViewModel();

        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                RaisePropertyChanged(nameof(CurrentViewModel));
            }
        }

        #region Go to Home

        private ICommand _goToHomeCommandCommand;
        public ICommand GoToHomeCommand => _goToHomeCommandCommand ?? (_goToHomeCommandCommand = new RelayCommand(GoToHomeCommandCommandExecute, GoToHomeCommandCommandCanExecute));

        private bool GoToHomeCommandCommandCanExecute() => CurrentViewModel != _homeViewModel;
        private void GoToHomeCommandCommandExecute() => CurrentViewModel = _homeViewModel;

        #endregion
        
        #region Go to Help

        private ICommand _goToHelpCommandCommand;
        public ICommand GoToHelpCommand => _goToHelpCommandCommand ?? (_goToHelpCommandCommand = new RelayCommand(GoToHelpCommandCommandExecute, GoToHelpCommandCommandCanExecute));

        private bool GoToHelpCommandCommandCanExecute() => CurrentViewModel != _helpViewModel;
        private void GoToHelpCommandCommandExecute() => CurrentViewModel = _helpViewModel;

        #endregion
        
        #region Go to Login

        private ICommand _goToLoginCommandCommand;
        public ICommand GoToLoginCommand => _goToLoginCommandCommand ?? (_goToLoginCommandCommand = new RelayCommand(GoToLoginCommandCommandExecute, GoToLoginCommandCommandCanExecute));

        private bool GoToLoginCommandCommandCanExecute() => CurrentViewModel != _loginViewModel;
        private void GoToLoginCommandCommandExecute() => CurrentViewModel = _loginViewModel;

        #endregion
    }
}