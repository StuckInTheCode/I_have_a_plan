using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using I_have_a_plan.ViewModels.Services;

namespace I_have_a_plan.Views.Services
{
    class MessageService: IMessageService
    {
        public MessageService()
        {
        }

        #region IMessageServise implementation
        public async Task ShowAsync(string message)
        {
            await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Message", message, "Ok");
        }
        #endregion
    }
}
