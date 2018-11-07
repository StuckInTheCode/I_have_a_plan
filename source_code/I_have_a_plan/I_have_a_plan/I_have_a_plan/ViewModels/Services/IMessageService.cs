using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace I_have_a_plan.ViewModels.Services
{
    interface IMessageService
    {
        Task ShowAsync(string message);
    }
}
