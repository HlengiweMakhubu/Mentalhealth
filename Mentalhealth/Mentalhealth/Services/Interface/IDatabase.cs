
using Mentalhealth.Model;
using Mentalhealth.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mentalhealth.Services.Interface
{
    public interface IDatabase
    {
        Task<int> SaveItemAsync(ClientDetails clientDetails);
        Task<int> SaveItemAsync(Appointment appointment);
        Task<ClientDetails> GetClientDetailsByUserName(string userName);
        Task<List<Appointment>> GetAppointmentsByClientDetailId(int id);

    }
}
