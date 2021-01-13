using Mentalhealth.Services.Interfaces;
using Mentalhealth.Messages.Security;
using Mentalhealth.Services.Interface;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;


namespace Mentalhealth.ViewModels
{
    public class loginPageViewModel : ViewModelBase
    {
        public ClientDetails LoginClient { get; set; }
        public List<ClientDetails> MyClientList { get; set; }
        public bool passwExist { get; set; }
        private IPageDialogService _pageDialogService;
        private IDatabase _database;
        private ISecurityService _securityService;
        private IEventAggregator _eventAggregator;
        private IUserProfile _userProfile;

        private DelegateCommand _loginCommand;
        private DelegateCommand _SignUpCommand;

        public DelegateCommand LoginCommand =>
            _loginCommand ?? (_loginCommand = new DelegateCommand(ExecuteLoginCommand));

        public ClientDetails userProfileCopy { get; set; }

        public DelegateCommand SignUpCommand =>
            _SignUpCommand ?? (_SignUpCommand = new DelegateCommand(ExecuteSignUpCommand));

        public loginPageViewModel(INavigationService navigation, ISecurityService securityService, IEventAggregator eventAggregator, IPageDialogService pageDialogService, IDatabase database, IUserProfile userProfile) : base(navigation)
        {
            _securityService = securityService;
            _database = database;
            _eventAggregator = eventAggregator;
            _userProfile = userProfile;
            _pageDialogService = pageDialogService;

            var LoginInfor = new ClientDetails();
            LoginClient = LoginInfor;

            var ClientDetails = new ClientDetails();
            LoginClient = ClientDetails;
        }

        async void ExecuteLoginCommand()
            {
                try
                {
                    var clientDetail = await _database.GetClientDetailsByUserName(LoginClient.UserName.ToLower());


                    if (LoginClient.UserName.ToLower() == null)
                    {
                        await _pageDialogService.DisplayAlertAsync("Alert", "Username is required!", "ok");
                    }
                    else if (LoginClient.UserName.ToLower() != clientDetail.UserName.ToLower() || LoginClient.Passrd != clientDetail.Passrd)
                    {
                        await _pageDialogService.DisplayAlertAsync("Alert", "Wrong Password or Username!", "ok");
                    }
                    else if (LoginClient.UserName.ToLower() != clientDetail.UserName.ToLower() && LoginClient.Passrd != clientDetail.Passrd)
                    {
                        await _pageDialogService.DisplayAlertAsync("Alert", "Wrong Password or Username!", "ok");
                    }
                    else if (LoginClient.Passrd == null)
                    {
                        await _pageDialogService.DisplayAlertAsync("Alert", "Password is required!", "ok");
                    }
                    else
                    {
                        if (clientDetail.Passrd == LoginClient.Passrd)
                        {
                            passwExist = true;

                            var loginResult = _securityService.LogIn("Test User", "Password");

                         

                            if (loginResult)
                            {

                                _userProfile.SetLoggedInUser(clientDetail);

                                _eventAggregator.GetEvent<LoginMessage>().Publish();
                            }

                            await NavigationService.NavigateAsync("MasterDetail/NavigationPage/DashBoardPage");
                           //await NavigationService.NavigateAsync("MasterDetail/NavigationPage/DashBoardPage", useModalNavigation: true);
                            return;
                        }
                        else
                        {
                            passwExist = false;
                        }


                        if (passwExist == false)
                        {
                            await _pageDialogService.DisplayAlertAsync("Alert", "Incorrect Password Please try again", "ok");
                        }
                    }
                }

                catch (Exception ex)
                {
                    await _pageDialogService.DisplayAlertAsync("Alert", "This User Does not Exist", "ok");
                }


        }

            void ExecuteSignUpCommand()
            {
                NavigationService.NavigateAsync("RegPage");
            }

    }

}
    

