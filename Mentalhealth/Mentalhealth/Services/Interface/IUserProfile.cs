
using Mentalhealth.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mentalhealth.Services.Interfaces
{
    public interface IUserProfile
    {
        void SetLoggedInUser(ClientDetails clientDetails);
        ClientDetails GetLoggedInUser();
    }
}
