﻿
using Mentalhealth.Model.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mentalhealth.Services.Interfaces
{
    public interface ISecurityService
    {
        IList<MenuItem> GetAllowedAccessItems();
        bool LogIn(string userName, string password);
        void LogOut();
    }
}
