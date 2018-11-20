using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace I_have_a_plan
{
    public interface ILocalToastNotification
    {
        void ShowScheduledMessage(string name, string message, int id, bool silent, DateTime time);
        void ShowMessage(string name, string message, int id = 0);
        void CancelMessage(int id);
    }
}
